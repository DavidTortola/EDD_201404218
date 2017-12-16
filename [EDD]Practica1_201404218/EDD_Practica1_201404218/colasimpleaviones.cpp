#include "colasimpleaviones.h"

#include <cstddef>
#include <iostream>
#include <ctime>

int crearCola(ColaSimpleAviones * cola){
    cola->length = 0;
    cola->primero = NULL;
    cola->ultimo = NULL;
    return 0;
}

int queue(ColaSimpleAviones * cola, Avion *avion_){

    lNodo * nuevo = new lNodo();
    nuevo->avion = avion_;

    if(!esVacia(cola)){

        cola->ultimo->siguiente = nuevo;
        cola->ultimo = nuevo;
        cola->length++;

    }else{

        cola->primero = nuevo;
        cola->ultimo = nuevo;
        cola->length++;

    }

    return 0;
}

int dequeue(ColaSimpleAviones * cola){

    if(!esVacia(cola)){

        if(cola->primero->siguiente != NULL){

            cola->primero = cola->primero->siguiente;
            cola->length--;

        }else{

            cola->primero = NULL;
            cola->ultimo = NULL;
            cola->length = 0;
        }

    }

    return 0;
}

int esVacia(ColaSimpleAviones * cola){

    if(cola->length > 0){
        return 0;
    }

    return 1;

}

QString escribirDOT(ColaSimpleAviones * cola){
    QString texto = "subgraph cluster_5 { \n";
    texto += "label = \"Mantenimiento\";\n";
    //PARA DECLARAR LAS CABECERAS Y LABELS
    if(!esVacia(cola)){
        lNodo * aux = cola->primero;
        while (aux != NULL){
            texto += "\"Avion " +QString::number(aux->avion->id);
            texto += "\"[label=\"{<f0>Avion: " +QString::number(aux->avion->id) + "|";
            texto += "<f1>Tipo: " +aux->avion->tipo +"|";
            texto += "<f2>Mantenimiento: " +QString::number(aux->avion->mantenimiento);
            texto +="}\" shape=record];\n";
            aux = aux->siguiente;
        }
    }
    //PARA COLOCAR LAS RELACIONES
    if(!esVacia(cola)){
        lNodo * aux = cola->primero;
        while (aux != NULL){
            if(aux->siguiente !=NULL){
                texto += "\"Avion " +QString::number(aux->avion->id) + "\"->\"Avion " +QString::number(aux->siguiente->avion->id) + "\";\n";
                aux = aux->siguiente;
            }else{
                aux = aux->siguiente;
            }
        }
    }
    texto += "}\n";
    return texto;
}
