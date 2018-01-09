using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class ListaDobleH
    {

        public NodoM inicio { get; set; }
        public NodoM fin { get; set; }
        public int tamaño { get; set; }
        public int modificador = 2;

        //Constructor
        public ListaDobleH()
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

            bool esLetras = Regex.IsMatch(valor, @"^[\p{L}]+$");

            if (esVacia())
            {
                if (esLetras)
                {
                    inicio = nuevo;
                    fin = nuevo;
                    tamaño++;
                }
            }
            else
            {
                if (esLetras)
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
                        nuevo.derecha = aux;
                        aux.izquierda = nuevo;
                        inicio = nuevo;
                        tamaño++;
                        insertado = true;
                        break;
                    }
                    else
                    {
                        nuevo.izquierda = aux.izquierda;
                        aux.izquierda.derecha = nuevo;
                        nuevo.derecha = aux;
                        aux.izquierda = nuevo;
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
                    aux = aux.derecha;
                }
            }

            //Si no se insertó al recorrer, se inserta al final
            if (insertado == false)
            {
                fin.derecha = nuevo;
                nuevo.izquierda = fin;
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
                    texto += "\"" + aux.valor + "\"[label=\"" + aux.valor + "\", shape = Mrecord, pos=\"" + (convertirString(aux.valor) * modificador).ToString() + ",0!\"];" + Environment.NewLine;
                    aux = aux.derecha;
                }
                aux = inicio;
                while (aux.derecha != null)
                {
                    texto += "\"" + aux.valor + "\" -> \"" + aux.derecha.valor + "\";" + Environment.NewLine;
                    aux = aux.derecha;
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
                        aux = aux.derecha;
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
                        aux = aux.derecha;
                    }
                }
            }
        }

        //Elimina el nodo encontrado con el metodo eliminar
        public void eliminarNodo(NodoM nodo)
        {
            if (nodo == inicio)
            {
                if (nodo.derecha != null)
                {
                    inicio = nodo.derecha;
                    nodo.derecha.izquierda = null;
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
                if (nodo.izquierda != null)
                {
                    fin = nodo.izquierda;
                    nodo.izquierda.derecha = null;
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
                nodo.izquierda.derecha = nodo.derecha;
                nodo.derecha.izquierda = nodo.izquierda;
                tamaño--;
            }
        }

        //Compara dos strings con el criterio de orden A,B,C...Z,AA,AB...ZZ,AAA...
        public int esMayor(string string1, string string2)
        {
            //Si string1 < string2, retorna -1
            //Si string1 > string2, retorna 1
            //Si string1 = string2, retorna 0

            if (string1.Equals(string2))
            {
                return 0;
            }
            else
            {
                var chars1 = string1.ToCharArray();
                var chars2 = string2.ToCharArray();

                if (chars1.Length > chars2.Length)
                {
                    return 1;
                }
                else if (chars1.Length < chars2.Length)
                {
                    return -1;
                }


                for (int i = 0; i < chars1.Length; i++)
                {
                    if (i < chars2.Length)
                    {
                        int val1 = (int)chars1[i];
                        int val2 = (int)chars2[i];

                        if (val1 > val2)
                        {
                            return 1;
                        }
                        else if (val1 < val2)
                        {
                            return -1;
                        }
                        else
                        {

                        }

                    }
                    else
                    {
                        return 1;
                    }
                }
                return -1;
            }
        }

        public int convertirString(string valor)
        {
            valor = valor.ToUpper();
            int total = 0;
            while (!valor.Equals(""))
            {
                if (valor.Length > 1)
                {

                    total += ((valor.Length - 1) * 26) * convertirChar(valor);
                }
                else if (valor.Length == 1)
                {
                    total += convertirChar(valor);
                }
                valor = valor.Remove(0, 1);
            }
            return total;
        }

        public int convertirChar(string caracter)
        {
            char chr = caracter[0];
            switch (chr)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
                case 'G':
                    return 7;
                case 'H':
                    return 8;
                case 'I':
                    return 9;
                case 'J':
                    return 10;
                case 'K':
                    return 11;
                case 'L':
                    return 12;
                case 'M':
                    return 13;
                case 'N':
                    return 14;
                case 'O':
                    return 15;
                case 'P':
                    return 16;
                case 'Q':
                    return 17;
                case 'R':
                    return 18;
                case 'S':
                    return 19;
                case 'T':
                    return 20;
                case 'U':
                    return 21;
                case 'V':
                    return 22;
                case 'W':
                    return 23;
                case 'X':
                    return 24;
                case 'Y':
                    return 25;
                case 'Z':
                    return 26;
                default:
                    return 0;
            }
        }

    }
}