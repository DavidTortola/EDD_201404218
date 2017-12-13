#include "coladoblementeenlazada.h"
#include <cstddef>
#include <iostream>

using namespace std;

int crearCola(ColaDoblementeEnlazada * cola){
    cola->length = 0;
    cola->primero = NULL;
    cola->ultimo = NULL;

    return 0;
}

int queue(ColaDoblementeEnlazada * cola, int valor){

    Nodo * nuevo = new Nodo();
    nuevo->valor = valor;

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

//HACE FALTA DELETE O DESTRUCTOR...
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



    }else{

    }

    return 0;

}

int esVacia(ColaDoblementeEnlazada * cola){
    if(cola->length > 0){
        return 0;
    }else{
        return 1;
    }
}

int estaLlena(ColaDoblementeEnlazada *cola){

    return 0;

}

int primero(ColaDoblementeEnlazada * cola){


    if (!esVacia(cola)){

        return cola->primero->valor;

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
            cout << aux->valor << endl;
            aux = aux->siguiente;
        }
    }
    return 0;
}


QString escribirDOT(ColaDoblementeEnlazada * cola){

    QString texto = "digraph G { ";

    texto += "node [shape=box,style=filled,color=black,fontcolor=white,fontname=\"Helvetica\"];\n";

    //PARA DECLARAR LAS CABECERAS Y LABELS
    if(!esVacia(cola)){
        Nodo * aux = cola->primero;
        int contador = 0;

        while (aux != NULL){

            texto += QString::number(aux->valor) + "[label=\"" +QString::number(aux->valor) + "\"];\n";

            //cout << aux->valor << endl;
            aux = aux->siguiente;
        }
    }

    //PARA COLOCAR LAS RELACIONES
    if(!esVacia(cola)){
        Nodo * aux = cola->primero;
        while (aux != NULL){
            if(aux->siguiente !=NULL){
                texto += QString::number(aux->valor) + "->" +QString::number(aux->siguiente->valor) + ";\n";
                //cout << aux->valor << endl;
                aux = aux->siguiente;
            }else{
                aux = aux->siguiente;
            }
        }
    }


    texto += "}";
    return texto;


}
