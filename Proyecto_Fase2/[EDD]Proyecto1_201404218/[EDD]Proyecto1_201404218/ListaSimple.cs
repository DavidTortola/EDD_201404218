using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class ListaSimple
    {
        public NodoListaSimple inicio { get; set; }
        public NodoListaSimple fin { get; set; }
        public int tamaño { get; set; }


        public void inicializarLista()
        {
            inicio = null;
            fin = null;
            tamaño = 0;
        }

        public void insertar(string nickname, int valor)
        {
            NodoListaSimple nuevo = new NodoListaSimple();
            nuevo.nickname = nickname;
            nuevo.valor = valor;
            insertar(nuevo);
        }

        public void insertar(NodoListaSimple nuevo)
        {
            
            if(tamaño == 0)
            {
                inicio = nuevo;
                fin = nuevo;
                tamaño++;
            }
            else if(tamaño == 1)
            { 
                if(nuevo.valor > inicio.valor)
                {
                    nuevo.siguiente = inicio;
                    inicio.anterior = nuevo;
                    inicio = nuevo;
                    tamaño++;
                }
                else
                {
                    fin.siguiente = nuevo;
                    nuevo.anterior = fin;
                    fin = nuevo;
                    tamaño++;
                }
            }
            else if(tamaño >1)
            {
                if(nuevo.valor > inicio.valor)
                {
                    nuevo.siguiente = inicio;
                    inicio.anterior = nuevo;
                    inicio = nuevo;
                    tamaño++;
                }
                else
                {
                    NodoListaSimple aux = inicio;
                    while (aux != null && nuevo.valor < aux.valor)
                    {
                        aux = aux.siguiente;
                    }
                    if(aux != null)
                    {
                        if(aux != fin)
                        {
                            nuevo.siguiente = aux;
                            if(aux.anterior != null)
                            {
                                aux.anterior.siguiente = nuevo;
                                nuevo.anterior = aux.anterior;
                            }
                            aux.anterior = nuevo;
                            tamaño++;

                        }
                        else
                        {
                            nuevo.siguiente = fin;
                            if(fin.anterior != null)
                            {
                                fin.anterior.siguiente = nuevo;
                                nuevo.anterior = fin.anterior;
                            }
                            fin.anterior = nuevo;
                            tamaño++;
                        }
                    }
                    else
                    {
                        fin.siguiente = nuevo;
                        nuevo.anterior = fin;
                        fin = nuevo;
                        tamaño++;
                    }

                }
                

            }
            else
            {
            }
            
        }

    }
}