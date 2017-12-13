#ifndef COLADOBLEMENTEENLAZADA_H
#define COLADOBLEMENTEENLAZADA_H

#include <QString>

typedef struct ColaDoblementeEnlazada ColaDoblementeEnlazada;
typedef struct Nodo Nodo;

struct Nodo{

    int valor;
    Nodo * siguiente;
    Nodo * anterior;

};

struct ColaDoblementeEnlazada{

    Nodo * primero;
    Nodo * ultimo;
    int length;

};

int crearCola(ColaDoblementeEnlazada * cola);
int queue(ColaDoblementeEnlazada * cola, int valor);
int dequeue(ColaDoblementeEnlazada * cola);
int esVacia(ColaDoblementeEnlazada * cola);
int estaLlena(ColaDoblementeEnlazada * cola);
int primero(ColaDoblementeEnlazada * cola);
int getSize(ColaDoblementeEnlazada * cola);
int imprimirCola(ColaDoblementeEnlazada * cola);

QString escribirDOT(ColaDoblementeEnlazada * cola);

#endif // COLADOBLEMENTEENLAZADA_H
