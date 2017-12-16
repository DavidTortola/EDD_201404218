#include "mainwindow.h"
#include "ui_mainwindow.h"

//EJECUTAR COMANDO DE UBUNTU
#include <QProcess>

//ESCRIBIR ARCHIVO DE TEXTO
#include <QtCore/QString>
#include <QtCore/QFile>
#include <QtCore/QDebug>
#include <QtCore/QTextStream>

//MOSTRAR IMAGEN EN LABEL
#include <QPixmap>
#include <QBitmap>


#include <iostream>

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);

}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_inicio_clicked()
{


    //Limpia el contador de aviones
    contadorAviones = 1;
    contadorTurno = 1;
    ui->textEdit->setText("");


    //Obtener el número de aviones para la simulación
    if(ui->txtAviones->toPlainText()==""){
    }else{
        numeroAviones = ui->txtAviones->toPlainText().toInt();
    }


    //Inicializar la lista de escritorios
    crearLista(listaEscritorios);


    //Crear la lista de escritorios para la simulación
    if(ui->txtEscritorios->toPlainText()==""){
    }else{

        crearEscritorios(listaEscritorios,ui->txtEscritorios->toPlainText().toInt());
        listaEscritorios->numeroEscritorios = ui->txtEscritorios->toPlainText().toInt();
    }

    //Inicializar la lista doble de maletas
    crearLista(listaMaletas);

    //Inicializar la cola doble de aviones
    crearCola(cola);


    //Inicializar la lista de estaciones de servicio
    crearLista(listaMantenimiento);

    //Llenar la lista de estaciones con la cantidad ingresada
    if(ui->txtMantenimiento->toPlainText()==""){

    }else{
        crearEstaciones(listaMantenimiento,ui->txtMantenimiento->toPlainText().toInt());
    }


}

void MainWindow::on_btnTurno_clicked()
{
    if(ui->txtTurnos->toPlainText()!= ""){
        if(ui->txtTurnos->toPlainText().toInt()>0){

            //Escribe en consola el turno actual
            escribirEnConsola("/////////////////Turno " +QString::number(contadorTurno) +"////////////////\n");
            contadorTurno++;

            //Si aún no se han creado todos los aviones, crear un avión nuevo
            if(contadorAviones <= numeroAviones){
                Avion * nuevo = crearAvion(contadorAviones);
                queue(cola,nuevo);
                escribirEnConsola("Arribó el avion número " +QString::number(contadorAviones) +".\n");
                contadorAviones++;
            }


            //Aplica desabordaje a la cola de aviones
            desabordaje(cola);

            registrarPasajeros();

            atender();

            darMantenimiento();

            escribirEnConsola("Pasajeros en cola para ser atendidos: " +QString::number(colaSimple->length)+".\n");

            escribirEnConsola(escribirInformacion(listaEscritorios));

            escribirEnConsola("Cantidad de maletas en el sistema: " +QString::number(listaMaletas->length)+".\n");

            escribirEnConsola(escribirInformacion(listaMantenimiento));

            escribirEnConsola("///////////////Fin turno " +QString::number(contadorTurno-1) +"///////////////\n");


            //Revisa si auto esta checkeado para graficar
            if(ui->checkBox->isChecked()){
                graficar();
            }

            ui->txtTurnos->setText(QString::number(ui->txtTurnos->toPlainText().toInt()-1));


        }
    }

}

void MainWindow::on_btnImprimir_clicked()
{
    graficar();

}


//MÉTODOS

int MainWindow::registrarPasajeros(){

    ldNodo * aux = listaEscritorios->primero;
    while(aux != NULL){

        if(aux->escritorio->cola->length<10){
            //Enviar pasajeros hasta llegar a 10 o quedarse sin pasajeros
            while(primero(colaSimple)!=0 && aux->escritorio->cola->length<10){
                //ENVIAR PASAJERO
                //SACAR PASAJERO
                //ingresar(aux->escritorio->cola,primero(colaSimple));

                queue(aux->escritorio->cola,primero(colaSimple));

                dequeue(colaSimple);
            }
            aux = aux->siguiente;

        }else{

            aux = aux->siguiente;

        }
    }

    return 0;
}

int MainWindow::atender(){

    ldNodo * aux = listaEscritorios->primero;
    while(aux != NULL){

        if(aux->escritorio->cola->primero != NULL){
            if(aux->escritorio->cola->primero->pasajero->numeroTurnos>0){

                if(aux->escritorio->pilaDocumentos->length != aux->escritorio->cola->primero->pasajero->documentos){
                    for(int i = 0; i < aux->escritorio->cola->primero->pasajero->documentos;i++){
                        push(aux->escritorio->pilaDocumentos);
                    }
                }
                aux->escritorio->cola->primero->pasajero->numeroTurnos--;
            }else{
                for(int i = 0;i<aux->escritorio->cola->primero->pasajero->maletas;i++){
                    eliminar(listaMaletas);
                }
                for(int i = 0;i<aux->escritorio->cola->primero->pasajero->documentos;i++){
                    pop(aux->escritorio->pilaDocumentos);
                }

                dequeue(aux->escritorio->cola);
            }

        }

        aux = aux->siguiente;


    }

    return 0;
}


int MainWindow::escribirEnConsola(QString cadena){

    QString actual = ui->textEdit->toPlainText();

    actual += cadena;

    ui->textEdit->setText(actual);

    return 0;
}

int MainWindow::desabordaje(ColaDoblementeEnlazada * cola){

    if(cola->primero != NULL){
        if(cola->primero->avion->desabordaje>0){

            escribirEnConsola("Avión desbordando: " +QString::number(cola->primero->avion->id) +".\n");
            cola->primero->avion->desabordaje--;
        }else{

            //Se crean los pasajeros del avion y se meten en la cola simple
            for(int i = 1;i<=cola->primero->avion->pasajeros;i++){
                Pasajero * pasajero = crearPasajero(contadorPasajeros,cola->primero->avion->id);
                queue(colaSimple,pasajero);

                for(int i = 0; i < pasajero->maletas; i++){
                    insertar(listaMaletas);
                }

                contadorPasajeros++;
            }

            escribirEnConsola("Avión " +QString::number(cola->primero->avion->id) +" pasa a estacion de mantenimiento.\n");
            queue(colaAviones,cola->primero->avion);
            dequeue(cola);
        }
    }
    return 0;

}

int MainWindow::graficar(){

    QString texto = "digraph G { \n";
    texto += "node [shape=box,style=filled,color=black,fontcolor=white,fontname=\"Helvetica\"]; \n";

    texto += escribirDOT(cola);
    texto += escribirDOT(colaSimple);
    texto += escribirDOT(listaEscritorios);
    texto += escribirDOT(listaMaletas);
    texto += escribirDOT(colaAviones);
    texto += escribirDOT(listaMantenimiento);
    texto += "}";


    //Abrir el archivo
    QString outputFilename = "Results.txt";
    QFile outputFile(outputFilename);
    outputFile.open(QIODevice::WriteOnly);

    //Apuntar un objeto QTextStream al archivo
    QTextStream outStream(&outputFile);

    //Escribir el texto al archivo
    outStream << texto;

    //Cerrar el archivo
    outputFile.close();

    //Crear el archivo .png
    QProcess process;
    process.start("dot -Tpng Results.txt -o diag.png");
    process.waitForFinished();

    //Cargar la imagen a un label y ajustarlo
    QPixmap pic("diag.png");
    ui->label->setPixmap(pic);
    //ui->label->setMask(pic.mask());
    //this->ui->label->setPixmap(pic.scaled(ui->label->size(),Qt::IgnoreAspectRatio,Qt::SmoothTransformation));
    ui->label->adjustSize();
    ui->scrollArea->setWidget(ui->label);

    return 0;


}


int MainWindow::darMantenimiento(){


    //Recorre la lista de estaciones buscando una vacía
    sNodo * aux = listaMantenimiento->primero;
    while(aux != NULL){

        //Si hay una que no tiene avion, le asigna uno
        if(aux->avion == NULL){

            //Valida que aun haya aviones esperando
            if(colaAviones->primero != NULL){
                aux->avion = colaAviones->primero->avion;
                dequeue(colaAviones);
             }

            aux = aux->siguiente;
        //Si ya tiene un avion
        }else{

            //Si al avion le faltan turnos, le resta uno
            if(aux->avion->mantenimiento > 0){

                aux->avion->mantenimiento--;
                aux = aux->siguiente;
            //Si ya no le restan turnos, elimina al avion
            }else{
                aux->avion = NULL;
                aux = aux->siguiente;
            }
        }
    }



    return 0;
}
