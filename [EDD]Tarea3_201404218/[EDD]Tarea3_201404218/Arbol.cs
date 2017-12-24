using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _EDD_Tarea3_201404218
{
    public class Arbol
    {
        public Nodo raiz { get; set; }

        public void insertar(string nickname, Arbol arbol)
        {
            Nodo nuevo = new Nodo();
            nuevo.nickname = nickname;
            arbol.insertar(nuevo, arbol.raiz);
        }

        public void insertar(Nodo nuevo, Nodo raiz)
        {
            if (raiz != null)
            {
                //Si nuevo es menor que raiz
                if (String.Compare(nuevo.nickname, raiz.nickname) < 0)
                {
                    if (raiz.izquierda != null)
                    {
                        insertar(nuevo, raiz.izquierda);
                    }
                    else
                    {
                        raiz.izquierda = nuevo;
                        nuevo.padre = raiz;
                    }

                    //Si nuevo es mayor que raiz
                }
                else if (String.Compare(nuevo.nickname, raiz.nickname) > 0)
                {
                    if (raiz.derecha != null)
                    {
                        insertar(nuevo, raiz.derecha);
                    }
                    else
                    {
                        raiz.derecha = nuevo;
                        nuevo.padre = raiz;
                    }
                }
                //Los nodos son iguales
                else
                {

                }
            }
            else
            {
                this.raiz = nuevo;
            }
        }

        public void graficar()
        {
            string texto = "digraph G{ " + Environment.NewLine;

            texto += escribirDOT(raiz);
            texto += "}";

            System.IO.File.WriteAllText(".\\texto.txt", texto);
            System.Diagnostics.ProcessStartInfo process = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + "dot -Tpng texto.txt -o graf.png");
            process.RedirectStandardOutput = true;
            process.UseShellExecute = false;
            process.CreateNoWindow = false;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = process;
            proc.Start();
        }

        public string escribirDOT(Nodo raiz)
        {
            string texto = "";
            if (raiz != null)
            {
                if (raiz.izquierda != null)
                {
                    texto += raiz.nickname + " -> " + raiz.izquierda.nickname + ";" + Environment.NewLine;
                    texto += escribirDOT(raiz.izquierda);
                }
                else
                {
                    texto += "nulli" + raiz.nickname + " [shape = point];" + Environment.NewLine;
                    texto += raiz.nickname + " -> " + "nulli" + raiz.nickname + ";" + Environment.NewLine;
                }
                if (raiz.derecha != null)
                {
                    texto += raiz.nickname + " -> " + raiz.derecha.nickname + ";" + Environment.NewLine;
                    texto += escribirDOT(raiz.derecha);
                }
                else
                {
                    texto += "nulld" + raiz.nickname + " [shape = point];" + Environment.NewLine;
                    texto += raiz.nickname + " -> " + "nulld" + raiz.nickname + ";" + Environment.NewLine;
                }
            }
            return texto;
        }

        public Nodo busqueda(string nickname, Nodo raiz)
        {
            //Si la raiz no es nula
            if (raiz != null)
            {
                //Si busqueda es menor que raiz
                if (String.Compare(nickname, raiz.nickname) < 0)
                {
                    if (raiz.izquierda != null)
                    {
                        return busqueda(nickname, raiz.izquierda);
                    }
                    else
                    {
                        return null;
                    }

                }
                //Si busqueda es mayor que raiz
                else if (String.Compare(nickname, raiz.nickname) > 0)
                {
                    if (raiz.derecha != null)
                    {
                        return busqueda(nickname, raiz.derecha);
                    }
                    else
                    {
                        return null;
                    }
                }
                //Si busqueda es igual a raiz
                else
                {
                    return raiz;
                }

            }
            //Si la raiz es nula
            return null;
        }

        public void eliminar(Nodo nodo)
        {
            //Si el arbol no es null
            if (raiz != null)
            {
                //Si no tiene hijos solo se elimina
                if (nodo.izquierda == null && nodo.derecha == null)
                {
                    if (nodo.padre != null)
                    {
                        if (nodo.padre.izquierda != null)
                        {
                            if (nodo.padre.izquierda.nickname == nodo.nickname)
                            {
                                nodo.padre.izquierda = null;
                            }
                        }
                        if (nodo.padre.derecha != null)
                        {
                            if (nodo.padre.derecha.nickname == nodo.nickname)
                            {
                                nodo.padre.derecha = null;
                            }
                        }
                    }
                    else
                    {
                        raiz = null;
                    }

                }
                //Si solo tiene hijo izquierdo
                else if (nodo.izquierda != null && nodo.derecha == null)
                {
                    if (nodo.padre.izquierda != null)
                    {
                        if (nodo.padre.izquierda.nickname == nodo.nickname)
                        {
                            nodo.padre.izquierda = nodo.izquierda;
                        }
                    }
                    if (nodo.padre.derecha != null)
                    {
                        if (nodo.padre.derecha.nickname == nodo.nickname)
                        {
                            nodo.padre.derecha = nodo.izquierda;
                        }
                    }
                }
                //Si solo tiene hijo derecho
                else if (nodo.izquierda == null && nodo.derecha != null)
                {
                    if (nodo.padre.izquierda != null)
                    {
                        if (nodo.padre.izquierda.nickname == nodo.nickname)
                        {
                            nodo.padre.izquierda = nodo.derecha;
                        }
                    }
                    if (nodo.padre.derecha != null)
                    {
                        if (nodo.padre.derecha.nickname == nodo.nickname)
                        {
                            nodo.padre.derecha = nodo.derecha;
                        }
                    }
                }
                //Si tiene ambos hijos
                else
                {
                    Nodo aux = mayor(raiz.izquierda);
                    nodo.nickname = aux.nickname;
                    eliminar(aux);
                }
            }
            //Si el árbol está vacío
            else
            {

            }
        }

        public Nodo mayor(Nodo raiz)
        {
            if (raiz != null)
            {
                if (raiz.derecha == null)
                {
                    return raiz;
                }
                else
                {
                    return mayor(raiz.derecha);
                }
            }
            return null;
        }

        public string preorden(Nodo raiz)
        {
            string texto = "";
            if(raiz != null)
            {
                texto += raiz.nickname + ", ";
                texto += preorden(raiz.izquierda);
                texto += preorden(raiz.derecha);
            }
            return texto;
        }

        public string inorden(Nodo raiz)
        {
            string texto = "";
            if (raiz != null)
            {
                texto += inorden(raiz.izquierda);
                texto += raiz.nickname + ", ";
                texto += inorden(raiz.derecha);
            }
            return texto;
        }

        public string postorden(Nodo raiz)
        {
            string texto = "";
            if (raiz != null)
            {
                texto += postorden(raiz.izquierda);
                texto += postorden(raiz.derecha);
                texto += raiz.nickname + ", ";
            }
            return texto;
        }

    }
}
