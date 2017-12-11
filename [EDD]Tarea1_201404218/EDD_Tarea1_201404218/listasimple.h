#ifndef LISTASIMPLE_H
#define LISTASIMPLE_H

typedef struct ListaSimple ListaSimple;
typedef struct Nodo Nodo;

struct Nodo{

    int val;
    Nodo * siguiente;
    Nodo * anterior;

};

struct ListaSimple{

    Nodo * primero;
    Nodo * ultimo;
    int length;

};

int insertarInicio(ListaSimple * lista, int val);
int inicializarLista(ListaSimple * lista);
int eliminarUltimo(ListaSimple * lista);
int imprimirLista(ListaSimple * lista);
int eliminarPorBusqueda(ListaSimple * lista, int posicion);
#endif // LISTASIMPLE_H
