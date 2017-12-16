#ifndef COLASIMPLEAVIONES_H
#define COLASIMPLEAVIONES_H

#include <QString>
#include "coladoblementeenlazada.h"

typedef struct ColaSimpleAviones ColaSimpleAviones;
typedef struct lNodo lNodo;

struct ColaSimpleAviones{
    lNodo * primero;
    lNodo * ultimo;
    int length;
};

struct lNodo{

    lNodo * siguiente;
    Avion * avion;

};


int crearCola(ColaSimpleAviones * cola);
int queue(ColaSimpleAviones * cola, Avion *avion_);
int dequeue(ColaSimpleAviones * cola);
int esVacia(ColaSimpleAviones * cola);
Avion *primero(ColaSimpleAviones * cola);
int getSize(ColaSimpleAviones * cola);
QString escribirDOT(ColaSimpleAviones * cola);

#endif // COLASIMPLEAVIONES_H
