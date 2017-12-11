#include <stdio.h>
#include <stdlib.h>

struct Nodo{

    int valor;
    struct Nodo *siguiente;

};

struct ListaSimple{

    struct Nodo *inicio;
    struct Nodo *fin;
    int length;

};

void inicializarLista(struct ListaSimple *lista){

    lista->inicio = NULL;
    lista->fin = NULL;
    lista->length = 0;

}


void insertar(struct ListaSimple *lista, struct Nodo* nuevo){

    if(lista->inicio == NULL){

        lista->inicio = nuevo;
        lista->fin = nuevo;
        lista->length++;

    }else if(lista->fin != NULL){

        lista->fin->siguiente = nuevo;
        lista->fin = nuevo;
        lista->length++;

    }

}

void insertar2(struct ListaSimple * lista, int valor){

    struct Nodo nuevo;
    nuevo.valor = valor;

    if(lista->inicio == NULL){

        lista->inicio = &nuevo;
        lista->fin = &nuevo;
        lista->length++;

    }else{

        lista->fin->siguiente = &nuevo;
        lista->fin = &nuevo;
        lista->length++;


    }

}

int main()
{
    struct ListaSimple lista1;
    struct ListaSimple * lista;

    lista = &lista1;
    inicializarLista(lista);

    insertar2(lista,2);
    insertar2(lista,3);
    printf("%d --- %d\n",lista->inicio->valor,lista->length);

    return 0;
}
