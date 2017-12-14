#include "listadoblementeenlazada.h"


int crearLista(ListaDoblementeEnlazada * lista){

    lista->primero = NULL;
    lista->ultimo = NULL;
    lista->length = 0;
    lista->numeroEscritorios = 0;
    return 0;
}

int insertar(ListaDoblementeEnlazada * lista, Escritorio *escritorio){

    ldNodo * nuevo = new ldNodo();
    nuevo->escritorio = escritorio;


    if(!esVacia(lista)){
        ldNodo * aux = lista->primero;

        while(aux != NULL){
            if(nuevo->escritorio->id > aux->escritorio->id){
             aux = aux->siguiente;
            }else if(nuevo->escritorio->id < aux->escritorio->id){

                nuevo->siguiente = aux;
                nuevo->anterior = aux->anterior;
                aux->anterior->siguiente = nuevo;
                aux->anterior = nuevo;
                lista->length++;
                break;
            }
        }
    }else{

        lista->primero = nuevo;
        lista->ultimo = nuevo;
        lista->length++;

    }

    return 0;
}

int eliminar(ListaDoblementeEnlazada * lista);

int esVacia(ListaDoblementeEnlazada * lista){

    if(lista->length > 0){
        return 0;
    }

    return 1;
}

int getSize(ListaDoblementeEnlazada * lista){

    return lista->length;

}

QString escribirDOT(ListaDoblementeEnlazada * lista){
    ldNodo * aux = lista->primero;
    QString texto = "";
    while(aux != NULL){
        texto+=aux->escritorio->id + "\n";
        aux = aux->siguiente;
    }
    texto += "a";
    return texto;
}

Escritorio * crearEscritorio(char id_){

    Escritorio * nuevo = new Escritorio();
    nuevo->id = id_;
    nuevo->cola = new ColaSimple();
    crearCola(nuevo->cola);

    return nuevo;

}

int crearEscritorios(ListaDoblementeEnlazada * lista){
    if(lista->numeroEscritorios>0){
        for(int i = 0; i<lista->numeroEscritorios;i++){
            char id = (i+65);
            Escritorio * escritorio_ = crearEscritorio(id);
            insertar(lista,escritorio_);
        }
    }
    return 0;
}
