using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class ListaDoble
    {

        public NodoLista inicio { get; set; }
        public NodoLista fin { get; set; }
        public int tamaño { get; set; }
        string nickname { get; set; }


        public void inicializarLista()
        {
            inicio = null;
            fin = null;
            tamaño = 0;
            nickname = "";
        }

        public void insertar(string nickname, string oponente, int unidadesDesplegadas, int unidadesSobrevivientes, int unidadesDestruidas, bool gano)
        {
            NodoLista nuevo = new NodoLista();
            nuevo.nickname = nickname;
            nuevo.oponente = oponente;
            nuevo.unidadesDesplegadas = unidadesDesplegadas;
            nuevo.unidadesSobrevivientes = unidadesSobrevivientes;
            nuevo.unidadesDestruidas = unidadesDestruidas;
            nuevo.gano = gano;
            this.nickname = nickname;
            insertar(nuevo);
        }

        public void insertar(NodoLista nuevo)
        {
            if (tamaño == 0)
            {
                inicio = nuevo;
                fin = nuevo;
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

        public string escribirDOT()
        {

            string texto = "";
            if (tamaño > 0)
            {
                int contador = 0;
                NodoLista aux = inicio;
                texto += "subgraph cluster_" + nickname + "{" + Environment.NewLine;

                while (aux != null)
                {
                    texto += "\"" + nickname + Convert.ToString(contador) + "\"[label=\"{Oponente: " + aux.oponente +"|Unidades desplegadas: " +aux.unidadesDesplegadas.ToString() +"|Unidades sobrevivientes: " +aux.unidadesSobrevivientes.ToString() +"|Unidades destruidas: " +aux.unidadesDestruidas.ToString() +"|Gano: " +aux.gano.ToString() + "}\" shape=record];" + Environment.NewLine;
                    contador++;
                    aux = aux.siguiente;
                }
                aux = inicio;
                contador = 0;
                while (aux.siguiente != null)
                {
                    texto += "\"" + nickname + Convert.ToString(contador) + "\"->\"" + nickname + Convert.ToString(contador + 1) + "\";" + Environment.NewLine;
                    texto += "\"" + nickname + Convert.ToString(contador+1) + "\"->\"" + nickname + Convert.ToString(contador) + "\";" + Environment.NewLine;
                    contador++;
                    aux = aux.siguiente;
                }
                texto += "}" + Environment.NewLine;
                
            }
            return texto;
        }
       
    }
}