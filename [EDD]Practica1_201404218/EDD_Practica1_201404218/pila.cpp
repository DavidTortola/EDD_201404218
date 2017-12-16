#include "pila.h"
#include <cstddef>


int crearPila(Pila * pila){

    pila->primero = NULL;
    pila->ultimo = NULL;
    pila->length = 0;
    return 0;
}
int push(Pila * pila){
    pNodo * nuevo = new pNodo();

    if(pila->length>0){
    pila->ultimo->siguiente = nuevo;
    nuevo->anterior = pila->ultimo;
    pila->ultimo = nuevo;
    pila->length++;

    }else{
        pila->primero = nuevo;
        pila->ultimo = nuevo;
        pila->length++;
    }
    return 0;
}

int pop(Pila * pila){

    if(pila->length>0){
        if(pila->length>1){
            pila->ultimo->anterior->siguiente = NULL;
            pila->ultimo = pila->ultimo->anterior;
            pila->length--;
        }else{
            pila->ultimo = NULL;
            pila->primero = NULL;
            pila->length = 0;
        }
    }

    return 0;

}
