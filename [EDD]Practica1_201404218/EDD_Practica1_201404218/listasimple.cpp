#include "listasimple.h"

int crearLista(ListaSimple * lista){

    lista->primero = NULL;
    lista->ultimo = NULL;
    lista->length = 0;
    return 0;

}

int insertar(ListaSimple * lista, int id){

    sNodo * nuevo = new sNodo();
    nuevo->id = id;

    if(lista->length>0){
            lista->ultimo->siguiente = nuevo;
            lista->ultimo = nuevo;
            lista->length++;

    }else{
        lista->primero = nuevo;
        lista->ultimo = nuevo;
        lista->length++;
    }

    return 0;


}


QString escribirDOT(ListaSimple * lista){

    QString texto = "subgraph cluster_6 { ";
    texto += "label = \"Estaciones de mantenimiento\";\n";

    //PARA DECLARAR LAS CABECERAS Y LABELS
    if(lista->length>0){
        sNodo * aux = lista->primero;
        while (aux != NULL){
            texto += "\"Estacion " +QString::number(aux->id) +"\"";
            texto += "[label=\"{<f0>Estacion: " +QString::number(aux->id) +"|";

            if(aux->avion != NULL){

                texto += "<f1>Ocupado? Si|";
                texto += "<f2>Avion atendido: " +QString::number(aux->avion->id) +"|";
                texto += "<f3>Turnos: " +QString::number(aux->avion->mantenimiento);

            }else{
                texto += "<f1>Ocupado? No|";
                texto += "<f3>Turnos: 0";
            }

            texto += "}\" shape=record];\n";
            aux = aux->siguiente;
        }
    }
    texto+="{rank=same;\n";

    //PARA COLOCAR LAS RELACIONES
    if(lista->length>0){
        sNodo * aux = lista->primero;
        while (aux->siguiente != NULL){
            texto += "\"Estacion " +QString::number(aux->id) +"\"->\"Estacion " +QString::number(aux->siguiente->id)+"\";";
            aux = aux->siguiente;
        }
    }

    texto += "}\n}\n";
    return texto;


}

int crearEstaciones(ListaSimple * lista, int cantidad){

    crearLista(lista);
    if(cantidad > 0){
        for(int i = 0; i < cantidad; i++){
            insertar(lista,i+1);
        }
    }

    return 0;
}


QString escribirInformacion(ListaSimple * lista){

    QString texto = "*********Estaciones de mantenimiento*********\n";
    if(lista->length>0){

        sNodo * aux = lista->primero;
        while (aux != NULL){
            texto += "Estacion " +QString::number(aux->id) +":\n";

            if(aux->avion != NULL){
                texto += "       Estado: Ocupado.\n";
                texto += "       Avion atendido: " +QString::number(aux->avion->id) +".\n";
                texto += "       Turnos restantes: " +QString::number(aux->avion->mantenimiento) +".\n";
            }else{

                texto += "       Estado: libre.\n";
                texto += "       Avion atendido: Ninguno.\n";
                texto += "       Turnos restantes: ....\n";
            }
            aux = aux->siguiente;
        }


    }
    texto += "***********************************************\n";
    return texto;

}
