#ifndef PILA_H
#define PILA_H

#include <QString>

typedef struct Pila Pila;
typedef struct pNodo pNodo;

struct pNodo{

    pNodo * siguiente;
    pNodo * anterior;
};

struct Pila{

    pNodo * primero;
    pNodo * ultimo;
    int length;

};

int crearPila(Pila * pila);
int push(Pila * pila);
int pop(Pila * pila);

#endif // PILA_H
