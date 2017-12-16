#include "listadoblecircular.h"
#include <cstddef>
#include <QString>

int crearLista(ListaDobleCircular *lista){

    lista->primero = NULL;
    lista->ultimo = NULL;
    lista->length = 0;
    lista->contador = 1;

    return 0;
}

int insertar(ListaDobleCircular *lista){

    ldcNodo * nuevo = new ldcNodo();
    nuevo->id = lista->contador;
    lista->contador++;

    if(!esVacia(lista)){
        lista->ultimo->siguiente = nuevo;
        nuevo->anterior = lista->ultimo;
        nuevo->siguiente = lista->primero;
        lista->primero->anterior = nuevo;
        lista->ultimo = nuevo;
        lista->length++;
    }else{
        lista->primero = nuevo;
        lista->ultimo = nuevo;
        nuevo->siguiente = nuevo;
        nuevo->anterior = nuevo;
        lista->length++;
    }
    return 0;
}

int eliminar(ListaDobleCircular *lista){

    if(!esVacia(lista)){
        if(lista->length>1){

            lista->primero->anterior = lista->ultimo->anterior;
            lista->ultimo->anterior->siguiente = lista->primero;
            lista->ultimo = lista->ultimo->anterior;
            lista->length--;
            lista->contador--;
        }else{
            lista->primero = NULL;
            lista->ultimo = NULL;
            lista->length = 0;
            lista->contador = 1;
        }
    }

    return 0;
}

int esVacia(ListaDobleCircular *lista){
    if(lista->length > 0){
        return 0;
    }
    return 1;
}

QString escribirDOT(ListaDobleCircular *lista){

    QString texto = "subgraph cluster_3 { \n";
    texto += "label = \"Equipaje\";\n";

    //PARA DECLARAR LAS CABECERAS Y LABELS
    if(!esVacia(lista)){
        ldcNodo * aux = lista->primero;
        texto += "\"Maleta " +QString::number(aux->id) +"\"";
        texto += "[label=\"Maleta: " +QString::number(aux->id);
        texto += "\" shape=record];\n";
        aux = aux->siguiente;
        while (aux != lista->primero){
            texto += "\"Maleta " +QString::number(aux->id) +"\"";
            texto += "[label=\"Maleta: " +QString::number(aux->id);
            texto += "\" shape=record];\n";
            aux = aux->siguiente;
        }
    }
    texto+="{\n";

    //PARA COLOCAR LAS RELACIONES
    if(!esVacia(lista)){
        ldcNodo * aux = lista->primero;

        if(aux->siguiente != aux && lista->length>2){
            texto += "\"Maleta " +QString::number(aux->id) + "\"->\"Maleta " +QString::number(aux->siguiente->id) + "\";\n";
            texto += "\"Maleta " +QString::number(aux->siguiente->id) + "\"->\"Maleta " +QString::number(aux->id) + "\";\n";
            aux = aux->siguiente;
        }
        if(lista->length==2){
            aux = aux->siguiente;
        }

        while (aux != lista->primero){
            if(aux->siguiente !=NULL){
                texto += "\"Maleta " +QString::number(aux->id) + "\"->\"Maleta " +QString::number(aux->siguiente->id) + "\";\n";
                texto += "\"Maleta " +QString::number(aux->siguiente->id) + "\"->\"Maleta " +QString::number(aux->id) + "\";\n";
                aux = aux->siguiente;

            }else{
                aux = aux->siguiente;
            }
        }
    }
    texto += "}\n}\n";
    return texto;
}
