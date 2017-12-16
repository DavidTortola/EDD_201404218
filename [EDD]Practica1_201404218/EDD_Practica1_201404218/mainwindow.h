#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include "coladoblementeenlazada.h"
#include "colasimple.h"
#include "listadoblementeenlazada.h"
#include "listadoblecircular.h"
#include "colasimpleaviones.h"
#include "listasimple.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    //USER'S CODE

    //Cola de aviones en aterrizaje
    ColaDoblementeEnlazada * cola = new ColaDoblementeEnlazada();
    int contadorAviones = 1;
    int numeroAviones = 0;
    int contadorTurno = 1;

    //Cola de pasajeros desabordados
    ColaSimple * colaSimple = new ColaSimple();
    int contadorPasajeros = 1;

    //Lista de escritorios
    ListaDoblementeEnlazada * listaEscritorios = new ListaDoblementeEnlazada();

    //Lista doble circular de maletas
    ListaDobleCircular * listaMaletas =  new ListaDobleCircular();

    //Cola simple de aviones en mantenimiento
    ColaSimpleAviones * colaAviones = new ColaSimpleAviones();

    //Lista simple de estaciones de servicio
    ListaSimple * listaMantenimiento = new ListaSimple();

    //Métodos
    int graficar();
    int escribirEnConsola(QString cadena);
    int desabordaje(ColaDoblementeEnlazada * cola);
    int registrarPasajeros();
    int atender();
    int darMantenimiento();

    //END OF USER'S CODE

    explicit MainWindow(QWidget *parent = 0);
    Ui::MainWindow *ui;
    ~MainWindow();

private slots:

    void on_inicio_clicked();

    void on_btnTurno_clicked();

    void on_btnImprimir_clicked();

private:

};

#endif // MAINWINDOW_H
