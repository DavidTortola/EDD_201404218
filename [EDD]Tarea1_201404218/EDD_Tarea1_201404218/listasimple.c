#include "listasimple.h"
#include <stdlib.h>
#include <stdio.h>

int inicializarLista(ListaSimple * lista){

    lista->primero = NULL;
    lista->ultimo = NULL;
    lista->length = 0;

    return 0;
}

int insertarInicio(ListaSimple* lista, int val){

    Nodo * nuevo = (Nodo * )malloc(sizeof(Nodo));
    nuevo->val = val;

    if (lista->primero == NULL){

        lista->primero = nuevo;
        lista->ultimo = nuevo;
        lista->length++;

    }else{

        lista->ultimo->siguiente = nuevo;
        nuevo->anterior = lista->ultimo;
        lista->ultimo = nuevo;

    }

    return 0;
}

int eliminarUltimo(ListaSimple* lista){

    if(lista->ultimo != NULL){
        if(lista->ultimo->anterior != NULL){
            lista->ultimo = lista->ultimo->anterior;
            lista->ultimo->siguiente = NULL;
        }else{

            lista->ultimo = NULL;
            lista->primero = NULL;

        }
    }

    return 0;

}

int imprimirLista(ListaSimple* lista){
    if (lista->primero != NULL){
        Nodo *aux = lista->primero;
        while(aux != NULL){
            printf("%d\n",aux->val);
            aux = aux->siguiente;
        }

    }else{
        printf("La lista está vacía\n");
    }
    return 0;
}

int eliminarPorBusqueda(ListaSimple* lista, int posicion){

    int contador = 1;
    if (lista->primero != NULL){

        Nodo *aux = lista->primero;
        while(contador < posicion){
            if(aux != NULL){
                printf("a");
                aux = aux->siguiente;
                contador++;
            }else{
                break;
            }
        }

        if(aux->anterior != NULL){
            if(aux->siguiente != NULL){
                //Tiene nodo antes y después

                aux->anterior->siguiente = aux->siguiente;
                aux->siguiente->anterior = aux->anterior;

            }else{
                //Tiene nodo antes pero no después
                lista->ultimo = aux->anterior;
                aux->anterior->siguiente = NULL;

            }
        }else{
            if(aux->siguiente != NULL){
                //No tiene nodo antes pero si después
                lista->primero = aux->siguiente;
                aux->siguiente->anterior = NULL;

            }else{
                //No tiene nodo antes ni después
                lista->primero = NULL;
                lista->ultimo = NULL;
            }
        }

    }else{
        printf("La lista está vacía\n");
    }
    return 0;
}
