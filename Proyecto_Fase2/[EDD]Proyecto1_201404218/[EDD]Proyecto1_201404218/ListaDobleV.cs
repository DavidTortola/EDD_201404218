using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class ListaDobleV
    {

        public NodoM inicio { get; set; }
        public NodoM fin { get; set; }
        public int tamaño { get; set; }
        public int modificador = 2;

        //Constructor
        public ListaDobleV()
        {
            inicio = null;
            fin = null;
            tamaño = 0;
        }

        //Devuelve true/false si esta/no esta vacía
        public bool esVacia()
        {
            if (tamaño > 0)
            {
                return false;
            }
            return true;
        }

        //Inserta un valor de forma ordenada
        public void insertar(string valor)
        {
            NodoM nuevo = new NodoM();
            nuevo.valor = valor;
            //Se asigna el valor

            var isNumeric = int.TryParse(valor, out var n);

            if (esVacia())
            {
                if (isNumeric)
                {
                    inicio = nuevo;
                    fin = nuevo;
                    tamaño++;
                }
            }
            else
            {
                if (isNumeric)
                {
                    insertarEnOrden(nuevo);
                    tamaño++;
                }
            }
        }

        //Recorre la lista buscando la posición para insertar de forma ordenada
        public void insertarEnOrden(NodoM nuevo)
        {
            NodoM aux = inicio;
            bool insertado = false;

            //Se recorre la lista buscando la posición para insertar
            while (aux != null)
            {
                //Nuevo es menor que actual
                if (esMayor(nuevo.valor, aux.valor) < 0)
                {

                    if (aux == inicio)
                    {
                        nuevo.abajo = aux;
                        aux.arriba = nuevo;
                        inicio = nuevo;
                        tamaño++;
                        insertado = true;
                        break;
                    }
                    else
                    {
                        nuevo.arriba = aux.arriba;
                        aux.arriba.abajo = nuevo;
                        nuevo.abajo = aux;
                        aux.arriba = nuevo;
                        tamaño++;
                        insertado = true;
                        break;
                    }
                }
                //Nuevo es igual a actual
                else if (esMayor(nuevo.valor, aux.valor) == 0)
                {
                    insertado = true;
                    break;
                }
                //Nuevo es mayor que actual
                else if (esMayor(nuevo.valor, aux.valor) > 0)
                {
                    aux = aux.abajo;
                }
            }

            //Si no se insertó al recorrer, se inserta al final
            if (insertado == false)
            {
                fin.abajo = nuevo;
                nuevo.arriba = fin;
                fin = nuevo;
                tamaño++;
            }
        }

        //Escribe y retorna un string en lenguaje dot con un subgrafo de esta lista
        public string escribirDOTPrincipal(string nombre)
        {
            string texto = "";

            if (tamaño > 0)
            {
                NodoM aux = inicio;
                while (aux != null)
                {
                    texto += "\"" + aux.valor + "\"[label=\"" + aux.valor + "\" shape = Mrecord, pos=\"0,-" + (Int32.Parse(aux.valor) * modificador).ToString() + "!\"];" + Environment.NewLine;
                    aux = aux.abajo;
                }
                aux = inicio;

                while (aux.abajo != null)
                {
                    texto += "\"" + aux.valor + "\" -> \"" + aux.abajo.valor + "\";" + Environment.NewLine;
                    aux = aux.abajo;
                }
            }
            return texto;
        }

        //Busca y devuelve un nodo si tiene el mismo valor, sino, devuelve null
        public NodoM buscar(string valor)
        {
            if (!esVacia())
            {
                NodoM aux = inicio;
                while (aux != null)
                {
                    if (aux.valor.Equals(valor))
                    {
                        return aux;
                    }
                    else
                    {
                        aux = aux.abajo;
                    }
                }
            }
            return null;
        }

        //Elimina un nodo en base a un valor
        public void eliminar(string valor)
        {
            if (!esVacia())
            {
                NodoM aux = inicio;
                while (aux != null)
                {
                    if (aux.valor.Equals(valor))
                    {
                        eliminarNodo(aux);
                        break;
                    }
                    else
                    {
                        aux = aux.abajo;
                    }
                }
            }
        }

        //Elimina el nodo encontrado con el metodo eliminar
        public void eliminarNodo(NodoM nodo)
        {
            if (nodo == inicio)
            {
                if (nodo.abajo != null)
                {
                    inicio = nodo.abajo;
                    nodo.abajo.arriba = null;
                    tamaño--;
                }
                else
                {
                    inicio = null;
                    fin = null;
                    tamaño = 0;
                }
            }
            else if (nodo == fin)
            {
                if (nodo.arriba != null)
                {
                    fin = nodo.arriba;
                    nodo.arriba.abajo = null;
                    tamaño--;
                }
                else
                {
                    inicio = null;
                    fin = null;
                    tamaño = 0;
                }
            }
            else
            {
                nodo.arriba.abajo = nodo.abajo;
                nodo.abajo.arriba = nodo.arriba;
                tamaño--;
            }
        }

        //Compara dos strings con el criterio de orden 1,2,3,4,...,100,101...
        public int esMayor(string string1, string string2)
        {
            //Si string1 < string2, retorna -1
            //Si string1 > string2, retorna 1
            //Si string1 = string2, retorna 0

            try
            {
                int val1 = Int32.Parse(string1);
                int val2 = Int32.Parse(string2);

                if (val1 < val2)
                {
                    return -1;
                }
                else if (val1 > val2)
                {
                    return 1;
                }
                return 0;

            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}