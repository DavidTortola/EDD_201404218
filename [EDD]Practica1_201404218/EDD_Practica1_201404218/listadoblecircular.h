#ifndef LISTADOBLECIRCULAR_H
#define LISTADOBLECIRCULAR_H

#include <QString>

typedef struct ListaDobleCircular ListaDobleCircular;
typedef struct ldcNodo ldcNodo;

struct ListaDobleCircular{

    ldcNodo * primero;
    ldcNodo * ultimo;
    int length;
    int contador;

};

struct ldcNodo{

    ldcNodo * siguiente;
    ldcNodo * anterior;
    int id;

};

int crearLista(ListaDobleCircular * lista);
int insertar(ListaDobleCircular * lista);
int eliminar(ListaDobleCircular * lista);
int esVacia(ListaDobleCircular * lista);
QString escribirDOT(ListaDobleCircular * lista);

#endif // LISTADOBLECIRCULAR_H
