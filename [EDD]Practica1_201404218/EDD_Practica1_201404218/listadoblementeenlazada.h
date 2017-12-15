#ifndef LISTADOBLEMENTEENLAZADA_H
#define LISTADOBLEMENTEENLAZADA_H

#include "colasimple.h"

typedef struct ListaDoblementeEnlazada ListaDoblementeEnlazada;
typedef struct ldNodo ldNodo;
typedef struct Escritorio Escritorio;

struct ListaDoblementeEnlazada{

    ldNodo * primero;
    ldNodo * ultimo;
    int length;
    int numeroEscritorios;

};

struct ldNodo{

    ldNodo * siguiente;
    ldNodo * anterior;
    Escritorio * escritorio;

};

struct Escritorio{

    char id;
    ColaSimple * cola;


};

int crearLista(ListaDoblementeEnlazada * lista);
int insertar(ListaDoblementeEnlazada * lista, Escritorio * escritorio);
int eliminar(ListaDoblementeEnlazada * lista);
int esVacia(ListaDoblementeEnlazada * lista);
int getSize(ListaDoblementeEnlazada * lista);
QString escribirDOT(ListaDoblementeEnlazada * lista);
Escritorio * crearEscritorio(ListaDoblementeEnlazada * lista, char id_);
int crearEscritorios(ListaDoblementeEnlazada * lista, int cantidad);
int ingresar(ListaDoblementeEnlazada * lista, Pasajero * pasajero);
int espaciosVacios(ListaDoblementeEnlazada * lista);
#endif // LISTADOBLEMENTEENLAZADA_H
