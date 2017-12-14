#ifndef COLASIMPLE_H
#define COLASIMPLE_H

#include <QString>

typedef struct ColaSimple ColaSimple;
typedef struct csNodo csNodo;
typedef struct Pasajero Pasajero;
struct ColaSimple{
    csNodo * primero;
    csNodo * ultimo;
    int length;
};
struct csNodo{

    csNodo * siguiente;
    Pasajero *pasajero;

};
struct Pasajero{

    int id;
    int maletas;
    int documentos;
    int numeroTurnos;
    int avion;

};

int crearCola(ColaSimple * cola);
int queue(ColaSimple * cola, Pasajero *pasajero_);
int dequeue(ColaSimple * cola);
int esVacia(ColaSimple * cola);
Pasajero *primero(ColaSimple * cola);
int getSize(ColaSimple * cola);
QString escribirDOT(ColaSimple * cola);
Pasajero * crearPasajero(int id_, int avion_);

#endif // COLASIMPLE_H
