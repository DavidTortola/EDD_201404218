#include "colasimple.h"
#include <cstddef>
#include <iostream>
#include <ctime>

int crearCola(ColaSimple * cola){
    cola->length = 0;
    cola->primero = NULL;
    cola->ultimo = NULL;
    return 0;
}

int queue(ColaSimple * cola, Pasajero *pasajero_){

    csNodo * nuevo = new csNodo();
    nuevo->pasajero = pasajero_;

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

int dequeue(ColaSimple * cola){

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

int esVacia(ColaSimple * cola){

    if(cola->length > 0){
        return 0;
    }

    return 1;

}

Pasajero *primero(ColaSimple * cola){

    if(!esVacia(cola)){
        return cola->primero->pasajero;
    }
    return 0;
}

int getSize(ColaSimple * cola){
    return cola->length;
}

QString escribirDOT(ColaSimple * cola){
    QString texto = "subgraph cluster_1 { ";
    texto += "label = \"Desabordaje\";\n";

    //PARA DECLARAR LAS CABECERAS Y LABELS
    if(!esVacia(cola)){
        csNodo * aux = cola->primero;
        while (aux != NULL){
            texto += "\"Pasajero " +QString::number(aux->pasajero->id) +"\"";
            texto += "[label=\"{<f0>Pasajero: " +QString::number(aux->pasajero->id) +"|";
            texto += "<fi>Avion: " +QString::number(aux->pasajero->avion) + "|";
            texto += "<f2>Maletas: " +QString::number(aux->pasajero->maletas) +"|";
            texto += "<f3>Documentos: " +QString::number(aux->pasajero->documentos) +"|";
            texto += "<f4>Turnos: " +QString::number(aux->pasajero->numeroTurnos) +"";
            texto += "}\" shape=record];\n";
            aux = aux->siguiente;
        }
    }
    //PARA COLOCAR LAS RELACIONES
    if(!esVacia(cola)){
        csNodo * aux = cola->primero;
        while (aux != NULL){
            if(aux->siguiente !=NULL){
                texto += "\"Pasajero " +QString::number(aux->pasajero->id) + "\"->\"Pasajero " +QString::number(aux->siguiente->pasajero->id) + "\";\n";
                aux = aux->siguiente;
            }else{
                aux = aux->siguiente;
            }
        }
    }
    texto += "}\n";
    return texto;
}

Pasajero * crearPasajero(int id_, int avion_){

    Pasajero * nuevo = new Pasajero();

    srand((int)time(0));

    nuevo->avion = avion_;
    nuevo->id = id_;
    nuevo->maletas = rand() % 4 + 1;
    nuevo->documentos = rand()% 10 + 1;
    nuevo->numeroTurnos = rand()% 3 + 1;

    return nuevo;

}
