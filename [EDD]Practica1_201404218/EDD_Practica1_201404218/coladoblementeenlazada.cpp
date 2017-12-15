#include "coladoblementeenlazada.h"
#include <cstddef>
#include <iostream>
#include <ctime>

using namespace std;

int crearCola(ColaDoblementeEnlazada * cola){

    cola->length = 0;
    cola->primero = NULL;
    cola->ultimo = NULL;

    return 0;
}

int queue(ColaDoblementeEnlazada * cola, Avion *avion_){

    Nodo * nuevo = new Nodo();
    nuevo->avion = avion_;

    if(!esVacia(cola)){

        cola->ultimo->siguiente = nuevo;
        nuevo->anterior = cola->ultimo;
        cola->ultimo = nuevo;
        cola->length++;

    }else{

        cola->primero = nuevo;
        cola->ultimo = nuevo;
        cola->length++;

    }

    return 0;
}

int dequeue(ColaDoblementeEnlazada * cola){

    if(!esVacia(cola)){

        if(cola->primero->siguiente != NULL){

            cola->primero->siguiente->anterior = NULL;
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

int esVacia(ColaDoblementeEnlazada * cola){
    if(cola->length > 0){
        return 0;
    }

    return 1;

}

int estaLlena(ColaDoblementeEnlazada *cola){

    if(!esVacia(cola)){
        return 1;
    }

    return 0;

}

Avion * primero(ColaDoblementeEnlazada * cola){


    if (!esVacia(cola)){

        return cola->primero->avion;

    }

    return 0;
}

int getSize(ColaDoblementeEnlazada * cola){

    return cola->length;

}

int imprimirCola(ColaDoblementeEnlazada * cola){

    if(!esVacia(cola)){
        Nodo * aux = cola->primero;
        while (aux != NULL){
            cout << aux->avion->id << endl;
            aux = aux->siguiente;
        }
    }
    return 0;
}

QString escribirDOT(ColaDoblementeEnlazada * cola){

    QString texto = "subgraph cluster_0 { \n";
    texto += "label = \"Llegadas de aviones\";\n";
    //PARA DECLARAR LAS CABECERAS Y LABELS
    if(!esVacia(cola)){
        Nodo * aux = cola->primero;
        while (aux != NULL){
            texto += "\"Avion " +QString::number(aux->avion->id);
            texto += "\"[label=\"{<f0>Avion: " +QString::number(aux->avion->id) + "|";
            texto += "<f1>Tipo: " +aux->avion->tipo +"|";
            texto += "<f2>Desbordaje: " +QString::number(aux->avion->desabordaje) +"|";
            texto += "<f3>Pasajeros: " +QString::number(aux->avion->pasajeros);
            texto +="}\" shape=record];\n";
            aux = aux->siguiente;
        }
    }
    //PARA COLOCAR LAS RELACIONES
    if(!esVacia(cola)){
        Nodo * aux = cola->primero;
        while (aux != NULL){
            if(aux->siguiente !=NULL){
                texto += "\"Avion " +QString::number(aux->avion->id) + "\"->\"Avion " +QString::number(aux->siguiente->avion->id) + "\";\n";
                texto += "\"Avion " +QString::number(aux->siguiente->avion->id) + "\"->\"Avion " +QString::number(aux->avion->id) + "\";\n";
                aux = aux->siguiente;
            }else{
                aux = aux->siguiente;
            }
        }
    }
    texto += "}\n";
    return texto;
}

Avion * crearAvion(int id_){

    Avion * nuevo = new Avion();
    nuevo->id = id_;

    //RANDOMS

    srand((int)time(0));


    nuevo->desabordaje = rand() % 3 + 1;

    if(nuevo->desabordaje == 1){

        nuevo->tipo = "pequeño";
        nuevo->pasajeros = rand() % 5+5;
        nuevo->mantenimiento = rand()% 3 + 1;

    }else if(nuevo->desabordaje == 2){

        nuevo->tipo = "mediano";
        nuevo->pasajeros = rand() %10 + 15;
        nuevo->mantenimiento = rand()% 3 + 2;

    }else if(nuevo->desabordaje == 3){

        nuevo->tipo = "grande";
        nuevo->pasajeros = rand() %10 + 30;
        nuevo->mantenimiento = rand()% 4 + 3;

    }

    return nuevo;
}
