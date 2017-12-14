#ifndef COLADOBLEMENTEENLAZADA_H
#define COLADOBLEMENTEENLAZADA_H

#include <QString>

typedef struct ColaDoblementeEnlazada ColaDoblementeEnlazada;
typedef struct Nodo Nodo;
typedef struct Avion Avion;

struct Nodo{

    Nodo * siguiente;
    Nodo * anterior;
    Avion *avion;

};

struct ColaDoblementeEnlazada{

    Nodo * primero;
    Nodo * ultimo;
    int length;

};

struct Avion{

    QString tipo;
    int id;
    int pasajeros;
    int desabordaje;
    int mantenimiento;

};

int crearCola(ColaDoblementeEnlazada * cola);
int queue(ColaDoblementeEnlazada * cola, Avion *avion_);
int dequeue(ColaDoblementeEnlazada * cola);
int esVacia(ColaDoblementeEnlazada * cola);
int estaLlena(ColaDoblementeEnlazada * cola);
Avion *primero(ColaDoblementeEnlazada * cola);
int getSize(ColaDoblementeEnlazada * cola);
int imprimirCola(ColaDoblementeEnlazada * cola);
QString escribirDOT(ColaDoblementeEnlazada * cola);
Avion * crearAvion(int id_);

#endif // COLADOBLEMENTEENLAZADA_H
