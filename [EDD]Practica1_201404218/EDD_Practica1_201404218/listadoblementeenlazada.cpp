#include "listadoblementeenlazada.h"
#include <iostream>

int crearLista(ListaDoblementeEnlazada * lista){


    lista->primero = NULL;
    lista->ultimo = NULL;
    lista->length = 0;
    lista->numeroEscritorios = 0;

    return 0;
}

//MÉTODO DE INSERCIÓN CON ORDENAMIENTO
int insertar(ListaDoblementeEnlazada * lista, Escritorio *escritorio){
    /*
    ldNodo * nuevo = new ldNodo();
    nuevo->escritorio = escritorio;

    if(!esVacia(lista)){


        lista->ultimo->siguiente = nuevo;
        nuevo->anterior = lista->ultimo;
        nuevo->siguiente = NULL;
        lista->ultimo = nuevo;
        lista->length++;

    }else{

        lista->primero = nuevo;
        lista->ultimo = nuevo;
        lista->length++;

}


    return 0;*/



    ldNodo * nuevo = new ldNodo();
    nuevo->escritorio = escritorio;

    if(!esVacia(lista)){

        ldNodo * aux = new ldNodo();
        aux = lista->primero;
        while(nuevo->escritorio->id<aux->escritorio->id && aux!=NULL){
            aux = aux->siguiente;
        }
        if(aux!=NULL){
        if(aux->anterior != NULL){
            nuevo->siguiente = aux;
            nuevo->anterior = aux->anterior;
            aux->anterior->siguiente = nuevo;
            aux->anterior = nuevo;
            lista->length++;
        }else{

            nuevo->siguiente = aux;
            aux->anterior = nuevo;
            lista->primero = nuevo;
            lista->length++;


        }
        }else{

            lista->ultimo->siguiente = nuevo;
            nuevo->anterior = lista->ultimo;
            nuevo->siguiente = NULL;
            lista->ultimo = nuevo;
            lista->length++;
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

    QString texto = "subgraph cluster_2 { ";
    texto += "label = \"Escritorios de registro\";\n";

    //PARA DECLARAR LAS CABECERAS Y LABELS
    if(!esVacia(lista)){
        ldNodo * aux = lista->ultimo;
        while (aux != NULL){
            texto += "\"Escritorio " +QString(QChar::fromLatin1(aux->escritorio->id)) +"\"";
            texto += "[label=\"{<f0>Escritorio: " +QString(QChar::fromLatin1(aux->escritorio->id)) +"|";

            if(aux->escritorio->cola->primero != NULL){

                texto += "<f1>Ocupado? Si|";
                texto += "<f2>Pasajero atendido: " +QString::number(aux->escritorio->cola->primero->pasajero->id) +"|";
                texto += "<f3>Documentos: " +QString::number(aux->escritorio->pilaDocumentos->length) +"|";
                texto += "<f4>Turnos: " +QString::number(aux->escritorio->cola->primero->pasajero->numeroTurnos);

            }else{
                texto += "<f1>Ocupado? No|";
                texto += "<f3>Documentos: 0";
            }




            texto += "}\" shape=record];\n";
            aux = aux->anterior;
        }
    }
    texto+="{rank=same;\n";

    //PARA COLOCAR LAS RELACIONES
    if(!esVacia(lista)){
        ldNodo * aux = lista->primero;
        while (aux != NULL){
            if(aux->siguiente !=NULL){
                texto += "\"Escritorio " +QString(QChar::fromLatin1(aux->escritorio->id)) + "\"->\"Escritorio " +QString(QChar::fromLatin1(aux->siguiente->escritorio->id)) + "\";\n";
                texto += "\"Escritorio " +QString(QChar::fromLatin1(aux->siguiente->escritorio->id)) + "\"->\"Escritorio " +QString(QChar::fromLatin1(aux->escritorio->id)) + "\";\n";
                aux = aux->siguiente;
            }else{
                aux = aux->siguiente;
            }
        }
    }

    texto += "}\n";
    texto += "{";

    //Para colocar los pasajeros en cada escritorio
    if(!esVacia(lista)){

        //SE RECORRE CADA UNO DE LOS ESCRITORIOS
        ldNodo * aux = lista->primero;
        while(aux != NULL){

            if(aux->escritorio->cola->primero != NULL){

                //SE RECORRE CADA PASAJERO EN ESTA COLA
                csNodo * aux2 = aux->escritorio->cola->primero;
                while (aux2 != NULL){
                    texto += "\"Pasajero2 " +QString::number(aux2->pasajero->id) +"\"";
                    texto += "[label=\"{<f0>Pasajero: " +QString::number(aux2->pasajero->id) +"|";
                    texto += "<fi>Avion: " +QString::number(aux2->pasajero->avion) + "|";
                    texto += "<f2>Maletas: " +QString::number(aux2->pasajero->maletas) +"|";
                    texto += "<f3>Documentos: " +QString::number(aux2->pasajero->documentos) +"|";
                    texto += "<f4>Turnos: " +QString::number(aux2->pasajero->numeroTurnos) +"";
                    texto += "}\" shape=record];\n";
                    aux2 = aux2->siguiente;
                }
                csNodo * aux3 = aux->escritorio->cola->primero;

                if(aux3!=NULL){
                    texto += "\"Escritorio " +QString(QChar::fromLatin1(aux->escritorio->id)) + "\"->\"Pasajero2 "+QString::number(aux3->pasajero->id) +"\";";
                }


                while(aux3->siguiente != NULL){

                    texto += "\"Pasajero2 " +QString::number(aux3->pasajero->id) +"\"->\"Pasajero2 " +QString::number(aux3->siguiente->pasajero->id) +"\";";
                    aux3 = aux3->siguiente;
                }


            }
            aux = aux->siguiente;
        }
     }

    texto += "}\n}\n";
    return texto;
}

Escritorio * crearEscritorio(char id_){

    Escritorio * nuevo = new Escritorio();
    nuevo->id = id_;
    nuevo->cola = new ColaSimple();
    crearCola(nuevo->cola);
    nuevo->pilaDocumentos = new Pila();
    crearPila(nuevo->pilaDocumentos);

    return nuevo;

}

int crearEscritorios(ListaDoblementeEnlazada * lista, int cantidad){

    for(int i = 0;i<cantidad;i++){

        insertar(lista,crearEscritorio(i+65));

    }

    return 0;
}

int espaciosVacios(ListaDoblementeEnlazada * lista){
    int contador = 0;
    if(!esVacia(lista)){
        ldNodo * aux = lista->primero;

        while(aux!=NULL){
            contador++;
            aux = aux->siguiente;
        }


    }
    return contador;

}

int ingresar(ColaSimple * cola, Pasajero * pasajero){

    std::cout << "aqui" << std::endl;
    std::cout << cola->primero << std::endl;
    std::cout << "aqui no xd " << std::endl;
    queue(cola,pasajero);
    return 0;
}

QString escribirInformacion(ListaDoblementeEnlazada * lista){

    QString texto = "-------Escritorios de registro------\n";

    if(!esVacia(lista)){
        //RECORRE LOS ESCRITORIOS
        ldNodo * aux = lista->primero;
        while (aux != NULL){

            texto += "Escritorio " + QString(QChar::fromLatin1(aux->escritorio->id)) +"\n";


            if(aux->escritorio->cola->primero != NULL){

                texto += "        Ocupado? Si \n";
                texto += "        Pasajero atendido: " +QString::number(aux->escritorio->cola->primero->pasajero->id) +"\n";
                texto += "        Documentos: " +QString::number(aux->escritorio->pilaDocumentos->length) +"\n";
                texto += "        Turnos: " +QString::number(aux->escritorio->cola->primero->pasajero->numeroTurnos) +"\n";

            }else{
                texto += "        Ocupado? No\n";
                texto += "        Documentos: 0\n";
            }
            aux = aux->siguiente;
        }
    }

    texto += "-----------------------------------\n";
    return texto;
}
