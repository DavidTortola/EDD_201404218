#include <iostream>

extern "C"{
#include "listasimple.h"
}

using namespace std;

ListaSimple *lista = (ListaSimple*)malloc(sizeof(ListaSimple));


int main()
{

    inicializarLista(lista);

    int opcion = 0;
    int valor = 0;

    while(true){
        cout << "Bienvenido a [EDD]Tarea1_201404218, escoja una opción:" << endl << endl;
        cout << "1. Insertar un dato al inicio." << endl;
        cout << "2. Eliminar el último dato de la lista." << endl;
        cout << "3. Imprimir la lista." << endl;
        cout << "4. Eliminar por posicion." << endl;
        cout << "Cualquier otro valor para salir." << endl;
        cin >> opcion;

        if (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4){
            cout << "Aplicación por: Osmel David Tórtola Tistoj - 201404218" << endl;
            break;
        }else if(opcion == 1){

            cout << "Escriba un valor numérico a ingresar:" << endl;
            cin >> valor;

            insertarInicio(lista, valor);

        }else if(opcion == 2){
            eliminarUltimo(lista);
            cout << "El último valor de la lista ha sido eliminado" << endl;

        }else if(opcion == 3){
            cout << endl;
            cout << "El contenido de la lista es:" << endl;
            cout << "----------------------------" << endl;
            imprimirLista(lista);
            cout << "-------fin de impresion-----" << endl;
            cout << endl;
        }else if(opcion == 4){
            cout << "Ingrese la posición a eliminar:" << endl;
            cin >> valor;
            eliminarPorBusqueda(lista,valor);
            cout << "La posicion " <<valor <<" ha sido eliminada." << endl;
        }

    }
    return 0;
}
