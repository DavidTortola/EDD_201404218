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
    //Limpia el contador de avionse
    contadorAviones = 1;
    contadorTurno = 1;
    ui->textEdit->setText("");
    //Obtener el número de aviones para la simulación
    if(ui->txtAviones->toPlainText()==""){
    }else{
        numeroAviones = ui->txtAviones->toPlainText().toInt();
    }
    //Crear la lista de escritorios para la simulación
    if(ui->txtEscritorios->toPlainText()==""){
    }else{
        crearLista(lista);
        lista->numeroEscritorios = ui->txtEscritorios->toPlainText().toInt();
        crearEscritorios(lista);
        ui->textEdit->setText(escribirDOT(lista));
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

    mantenimiento(cola);
    //graficar();
}

void MainWindow::on_btnImprimir_clicked()
{
    /*
    if(!esVacia(cola)){
        ui->textEdit->setText("");
        Nodo * aux = cola->primero;
        while (aux != NULL){
            ui->textEdit->setText(ui->textEdit->toPlainText()+ QString::number(aux->avion->id)+"\n");
            aux = aux->siguiente;
        }

    }
    ColaSimple * colasimple = new ColaSimple();
    crearCola(colasimple);
    crearCola(cola);
    ui->textEdit->setText(escribirDOT(cola));
    */
    graficar();
}


//MÉTODOS

int MainWindow::escribirEnConsola(QString cadena){

    QString actual = ui->textEdit->toPlainText();

    actual += cadena;

    ui->textEdit->setText(actual);

    return 0;
}

int MainWindow::mantenimiento(ColaDoblementeEnlazada * cola){

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
    texto += "node [shape=box,style=filled,color=black,fontcolor=white,fontname=\"Helvetica\"];\n";

    texto += escribirDOT(cola);
    texto += escribirDOT(colaSimple);

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
