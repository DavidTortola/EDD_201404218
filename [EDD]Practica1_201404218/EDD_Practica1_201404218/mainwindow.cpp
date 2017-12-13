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

void MainWindow::on_pushButton_clicked()
{
    queue(cola,contador);
    contador++;
}

void MainWindow::on_pushButton_4_clicked()
{
    if(!esVacia(cola)){
        ui->textEdit->setText("");
        Nodo * aux = cola->primero;
        while (aux != NULL){
            ui->textEdit->setText(ui->textEdit->toPlainText()+ QString::number(aux->valor)+"\n");
            aux = aux->siguiente;
        }

    }

    ui->textEdit->setText(escribirDOT(cola));

}

void MainWindow::on_pushButton_2_clicked()
{
    dequeue(cola);
}

void MainWindow::on_pushButton_3_clicked()
{
    //crearCola(cola);


    /* Try and open a file for output */
    QString outputFilename = "Results.txt";
    QFile outputFile(outputFilename);
    outputFile.open(QIODevice::WriteOnly);

    /* Check it opened OK */
    if(!outputFile.isOpen()){
        //qDebug() << argv[0] << "- Error, unable to open" << outputFilename << "for output";
        //return 1;
    }

    /* Point a QTextStream object at the file */
    QTextStream outStream(&outputFile);

    /* Write the line to the file */
    //outStream << "digraph G {start_here [label=\"it's me(start here)\"];start_here -> 2017;bloglife1 [label=\"create more blog\"];bloglife2 [label=\"make more money\"];bloglife3 [label=\"become rich\"];life_goal1[label=\"married withsomeone\"];life_goal2[label=\"have a baby\"];life_goal3[label=\"happy life\"];2017 -> bloglife1 -> bloglife2 -> bloglife3;2017 -> life_goal1 -> life_goal2;node [shape=box,style=filled,color=\".7 .3 1.0\"];life_goal2 -> life_goal3}";
    outStream << escribirDOT(cola);
    /* Close the file */
    outputFile.close();

    //CREA EL ARCHIVO PNG
    QProcess process;
    process.start("dot -Tpng Results.txt -o diag.png");
    process.waitForFinished();

    //LO CARGA A UN LABEL Y LO AJUSTA
    QPixmap pic("diag.png");
    ui->label->setPixmap(pic);
    //ui->label->setMask(pic.mask());

    //this->ui->label->setPixmap(pic.scaled(ui->label->size(),Qt::IgnoreAspectRatio,Qt::SmoothTransformation));
    ui->label->adjustSize();
    //ui->scrollArea->setBackgroundRole(QPalette::Dark);
    ui->scrollArea->setWidget(ui->label);
    //ui->scrollArea->widget()->setLayout(ui->label);
}
