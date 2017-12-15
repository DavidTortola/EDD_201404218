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
        ui->textEdit->setText(escribirDOT(listaEscritorios));

    }


    //Inicializar la cola doble de aviones
    crearCola(cola);

}

void MainWindow::on_btnTurno_clicked()
{
    //Escribe en consola el turno actual
    escribirEnConsola("///////////////Turno " +QString::number(contadorTurno) +"///////////////\n");
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

    //Revisa si auto esta checkeado para graficar
    if(ui->checkBox->isChecked()){
        graficar();
    }

}

void MainWindow::on_btnImprimir_clicked()
{
    graficar();
    registrarPasajeros();
}


//MÉTODOS

int MainWindow::registrarPasajeros(){

    ldNodo * aux = listaEscritorios->primero;
    while(aux != NULL){
        if(aux->escritorio->cola->length<10){
            //Enviar pasajeros hasta llegar a 10 o quedarse sin pasajeros
            aux = aux->siguiente;
        }else{
            aux = aux->siguiente;
        }
    }






    /*
    if(!esVacia(colaSimple)){
        if(espaciosVacios(listaEscritorios)>0){

            for(int i = 0;i<espaciosVacios(listaEscritorios);i++){

                if(primero(colaSimple)!=0){
                    ingresar(listaEscritorios, primero(colaSimple));
                }

            }

        }


    }

    */
    /*ldNodo * aux = listaEscritorios->primero;
    while(aux != NULL){

        csNodo * aux2 = aux->escritorio->cola->primero;
        while(aux2 != NULL){

            std::cout << aux2->pasajero->maletas << endl;
            aux2 = aux2->siguiente;
        }
        aux = aux->siguiente;
    }
    */


    /*
    if(listaEscritorios->primero->escritorio->cola->primero != NULL){
     std::cout << "lleno"<<std::endl;
     std::cout << listaEscritorios->primero->escritorio->cola->primero->pasajero->id<<std::endl;
     std::cout << listaEscritorios->primero->escritorio->cola->primero->pasajero->avion<<std::endl;
     std::cout << listaEscritorios->primero->escritorio->cola->primero->pasajero->numeroTurnos<<std::endl<<std::endl;
     std::cout << listaEscritorios->primero->siguiente->escritorio->cola->primero->pasajero->id<<std::endl;
     std::cout << listaEscritorios->primero->siguiente->escritorio->cola->primero->pasajero->avion<<std::endl;
     std::cout << listaEscritorios->primero->siguiente->escritorio->cola->primero->pasajero->numeroTurnos<<std::endl;
    }else{
        std::cout<<"vacio"<<std::endl;
    }

    */

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
                contadorPasajeros++;
            }

            escribirEnConsola("Avión " +QString::number(cola->primero->avion->id) +" pasa a estacion de mantenimiento.\n");
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
