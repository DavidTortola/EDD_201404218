#ifndef LISTASIMPLE_H
#define LISTASIMPLE_H

#include "coladoblementeenlazada.h"
#include <QString>

typedef struct ListaSimple ListaSimple;
typedef struct lNodo lNodo;

struct sNodo{

    int id;
    sNodo * siguiente;
    Avion *avion;

};

struct ListaSimple{

    sNodo * primero;
    sNodo * ultimo;
    int length;

};

int crearLista(ListaSimple * lista);
int insertar(ListaSimple * lista, int id);
int eliminar(ListaSimple * lista);
QString escribirDOT(ListaSimple * lista);
int crearEstaciones(ListaSimple * lista, int cantidad);

QString escribirInformacion(ListaSimple * lista);

#endif // LISTASIMPLE_H

