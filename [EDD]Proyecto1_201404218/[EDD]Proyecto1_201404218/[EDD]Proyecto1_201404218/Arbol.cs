using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace _EDD_Proyecto1_201404218
{
    public class Arbol
    {
        public Nodo raiz { get; set; }
        public int hojas { get; set; }
        public int ramas { get; set; }
        public ListaSimple consultas { get; set; }

        public void insertar(string nickname)
        {
            Nodo nuevo = new Nodo();
            nuevo.nickname = nickname;
            insertar(nuevo, raiz);
        }

        public void insertar(string nickname, string contraseña, string correoElectronico, bool conectado)
        {
            Nodo nuevo = new Nodo();
            nuevo.nickname = nickname;
            nuevo.contraseña = contraseña;
            nuevo.correoElectronico = correoElectronico;
            nuevo.conectado = conectado;
            nuevo.listaJuegos = new ListaDoble();
            insertar(nuevo, raiz);
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

                texto += "\"" + raiz.nickname + "\"[label=\"" + "<izquierda>|{<centro2>" + raiz.nickname + "|" +raiz.contraseña +"|" +raiz.correoElectronico + "|<centro>Conectado: " + raiz.conectado.ToString() +"}|<derecha>\", shape = Mrecord];" + Environment.NewLine;

                if (raiz.listaJuegos != null)
                {
                    if (raiz.listaJuegos.tamaño > 0)
                    {
                        texto += raiz.listaJuegos.escribirDOT();
                        texto += raiz.nickname + ":centro -> " + raiz.nickname + "0;" + Environment.NewLine;
                    }
                }


                if (raiz.izquierda != null)
                {
                    texto += raiz.nickname + ":izquierda -> " + raiz.izquierda.nickname + ":centro2;" + Environment.NewLine;

                    texto += escribirDOT(raiz.izquierda);
                }
                else
                {
                    texto += "nulli" + raiz.nickname + " [shape = point];" + Environment.NewLine;
                    texto += raiz.nickname + ":izquierda -> " + "nulli" + raiz.nickname + ";" + Environment.NewLine;
                }
                if (raiz.derecha != null)
                {
                    texto += raiz.nickname + ":derecha -> " + raiz.derecha.nickname + ":centro2;" + Environment.NewLine;
                    texto += escribirDOT(raiz.derecha);
                }
                else
                {
                    texto += "nulld" + raiz.nickname + " [shape = point];" + Environment.NewLine;
                    texto += raiz.nickname + ":derecha -> " + "nulld" + raiz.nickname + ";" + Environment.NewLine;
                }
            }
            return texto;
        }

        public string escribirEspejo(Nodo raiz)
        {
            string texto = "";
            if (raiz != null)
            {

                texto += "\"" + raiz.nickname + "\"[label=\"" + "<izquierda>|{<centro2>" + raiz.nickname + "|" + raiz.contraseña + "|" + raiz.correoElectronico + "|<centro>Conectado: " + raiz.conectado.ToString() + "}|<derecha>\", shape = Mrecord];" + Environment.NewLine;


                if (raiz.listaJuegos != null)
                {
                    if (raiz.listaJuegos.tamaño > 0)
                    {
                        texto += raiz.listaJuegos.escribirDOT();
                        texto += raiz.nickname + ":centro -> " + raiz.nickname + "0;" + Environment.NewLine;
                    }
                }


                if (raiz.izquierda != null)
                {
                    texto += raiz.nickname + ":derecha -> " + raiz.izquierda.nickname + ":centro2;" + Environment.NewLine;

                    texto += escribirEspejo(raiz.izquierda);
                }
                else
                {
                    texto += "nulli" + raiz.nickname + " [shape = point];" + Environment.NewLine;
                    texto += raiz.nickname + ":derecha -> " + "nulli" + raiz.nickname + ";" + Environment.NewLine;
                }
                if (raiz.derecha != null)
                {
                    texto += raiz.nickname + ":izquierda -> " + raiz.derecha.nickname + ":centro2;" + Environment.NewLine;
                    texto += escribirEspejo(raiz.derecha);
                }
                else
                {
                    texto += "nulld" + raiz.nickname + " [shape = point];" + Environment.NewLine;
                    texto += raiz.nickname + ":izquierda -> " + "nulld" + raiz.nickname + ";" + Environment.NewLine;
                }
            }
            return texto;
        }

        public string escribirDOT2(Nodo raiz)
        {
            string texto = "";
            if (raiz != null)
            {
                if (raiz.listaJuegos != null)
                {
                    if (raiz.listaJuegos.tamaño > 0)
                    {
                        texto += raiz.listaJuegos.escribirDOT();
                        texto += raiz.nickname + " -> " + raiz.nickname + "0;" + Environment.NewLine;
                    }
                }


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

        public void colocarDatos(Arbol a,Nodo raiz)
        {
            a.hojas = 0;
            a.ramas = 0;
            colocarDatos2(a, raiz);
        }

        public void colocarDatos2(Arbol a, Nodo raiz)
        {
            if(raiz != null)
            {
                if(raiz.izquierda == null && raiz.derecha == null)
                {
                    a.hojas++;
                }
                else
                {
                    if(raiz.padre == null)
                    {
                        if(raiz.izquierda == null && raiz.derecha == null)
                        {
                            a.hojas++;
                        }
                        if (raiz.izquierda != null)
                        {
                            colocarDatos2(a, raiz.izquierda);
                        }
                        if (raiz.derecha != null)
                        {
                            colocarDatos2(a, raiz.derecha);
                        }
                    }
                    else
                    {
                        a.ramas++;
                        if(raiz.izquierda != null)
                        {
                            colocarDatos2(a,raiz.izquierda);
                        }
                        if(raiz.derecha != null)
                        {
                            colocarDatos2(a,raiz.derecha);
                        }
                    }
                }
            }
        }

        public void eliminar(Nodo nodo)
        {
            //Si el arbol no es null
            if (raiz != null && nodo != null)
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
                    if (nodo.padre != null)
                    {
                        if (nodo.padre.izquierda != null)
                        {
                            if (nodo.padre.izquierda.nickname == nodo.nickname)
                            {
                                nodo.padre.izquierda = nodo.izquierda;
                                nodo.izquierda.padre = nodo.padre;
                            }
                        }
                        if (nodo.padre.derecha != null)
                        {
                            if (nodo.padre.derecha.nickname == nodo.nickname)
                            {
                                nodo.padre.derecha = nodo.izquierda;
                                nodo.izquierda.padre = nodo.padre;
                            }
                        }
                    }
                    else
                    {
                        nodo.izquierda.padre = null;
                        raiz = nodo.izquierda;
                    }
                }
                //Si solo tiene hijo derecho
                else if (nodo.izquierda == null && nodo.derecha != null)
                {
                    if (nodo.padre != null)
                    {
                        if (nodo.padre.izquierda != null)
                        {
                            if (nodo.padre.izquierda.nickname == nodo.nickname)
                            {
                                nodo.padre.izquierda = nodo.derecha;
                                nodo.derecha.padre = nodo.padre;
                            }
                        }
                        if (nodo.padre.derecha != null)
                        {
                            if (nodo.padre.derecha.nickname == nodo.nickname)
                            {
                                nodo.padre.derecha = nodo.derecha;
                                nodo.derecha.padre = nodo.padre;
                            }
                        }
                    }
                    else
                    {
                        nodo.derecha.padre = null;
                        raiz = nodo.derecha;
                    }
                }
                //Si tiene ambos hijos
                else
                {
                    Nodo aux = mayor(nodo.izquierda);

                    eliminar(aux);

                    aux.izquierda = nodo.izquierda;
                    aux.derecha = nodo.derecha;
                    if(nodo.izquierda != null)
                    {
                        nodo.izquierda.padre = aux;
                    }

                    if (nodo.derecha != null)
                    {
                        nodo.derecha.padre = aux;
                    }

                    aux.padre = nodo.padre;

                    if (nodo.padre != null)
                    {
                        if (nodo.padre.izquierda != null)
                        {
                            if (nodo.padre.izquierda.nickname == nodo.nickname)
                            {
                                nodo.padre.izquierda = aux;
                            }
                        }
                        if (nodo.padre.derecha != null)
                        {
                            if (nodo.padre.derecha.nickname == nodo.nickname)
                            {
                                nodo.padre.derecha = aux;
                            }
                        }
                    }
                    else
                    {
                        raiz = aux;
                    }
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

        public string escribirJuegos(string nickname)
        {
            Nodo nuevo = busqueda(nickname, raiz);
            string texto = "";
            if (nuevo != null)
            {
                if (nuevo.listaJuegos != null)
                {
                    NodoLista aux = nuevo.listaJuegos.inicio;
                    while (aux != null)
                    {
                        string gano = "";
                        if (aux.gano)
                        {
                            gano = "1";
                        }
                        else
                        {
                            gano = "0";
                        }

                        texto += aux.oponente + "," + aux.unidadesDesplegadas + "," + aux.unidadesSobrevivientes + "," + aux.unidadesDestruidas + "," + gano + Environment.NewLine;
                        aux = aux.siguiente;
                    }
                }
                else
                {
                }
            }
            return texto;
        }

        public int altura(Nodo raiz)
        {
            int alturaIz = 0;
            int alturaDer = 0;
            if(raiz != null)
            {
                if(raiz.izquierda != null)
                {
                    alturaIz = altura2(raiz.izquierda);
                }
                if(raiz.derecha != null)
                {
                    alturaDer = altura2(raiz.derecha);
                }
                if(alturaIz > alturaDer)
                {
                    return alturaIz;
                }
                else
                {
                    return alturaDer;
                }
            }
            else
            {
                return 0;
            }
        }


        public int altura2(Nodo raiz)
        {
            int alturaIz = 0;
            int alturaDer = 0;
            if (raiz != null)
            {
                if (raiz.izquierda != null)
                {
                    alturaIz = altura2(raiz.izquierda);
                }
                if (raiz.derecha != null)
                {
                    alturaDer = altura2(raiz.derecha);
                }
                if (alturaIz > alturaDer)
                {
                    return alturaIz + 1;
                }
                else
                {
                    return alturaDer + 1;
                }
            }
            else
            {
                return 0;
            }
        }

        //DEVUELVE UN STRING CON EL TOP USUARIOS CON JUEGOS GANADOS
        public string consultarJuegosGanados()
        {
            consultas = new ListaSimple();
            masJuegosGanados(raiz);
            return escribirConsulta(0);
        }

        //DEVUELVE UN STRING CON EL USUARIO CON MAS PORCENTAJE DE UNIDADES DESTRUIDAS
        public string consultarPorcentajeUnidadesDestruidas()
        {
            consultas = new ListaSimple();
            masUnidadesDestruidas(raiz);
            return escribirConsulta(1);

        }

        //RECORRE TODO EL ARBOL DESDE EL NODO RAIZ INSERTANDO CADA USUARIO Y SU NUMERO DE JUEGOS GANADOS EN LA LSITA consultas DE ESTA CLASE
        public void masJuegosGanados(Nodo raiz)
        {
            if (raiz != null)
            {
                NodoListaSimple nuevo = new NodoListaSimple();
                nuevo.nickname = raiz.nickname;
                nuevo.valor = obtenerJuegosGanados(raiz.listaJuegos);
                consultas.insertar(nuevo);

                masJuegosGanados(raiz.izquierda);
                masJuegosGanados(raiz.derecha);

            }
        }

        //ESTE MÉTODO RECORRE LA LISTA DE JUEGOS DE UN USUARIO Y SUMA LOS JUEGOS GANADOS Y LO DEVUELVE COMO INT
        public int obtenerJuegosGanados(ListaDoble lista)
        {
            int contador = 0;
            if (lista != null)
            {
                NodoLista aux = lista.inicio;

                while (aux != null)
                {
                    if (aux.gano)
                    {
                        contador++;
                    }
                    aux = aux.siguiente;
                }
            }
            return contador;
        }

        //ESTE MÉTODO RECORRE LA LSITA SIMPLE DE CONSULTAS Y DEVUELVE UN STRING CON SUS NICKNAMES Y SUS VALORES, PUEDE SER VICTORIAS O PORCENTAJE UNIDADES DESTRUIDAS
        public string escribirConsulta(int opcion)
        {
            string texto = "";
            int contador = 0;
            NodoListaSimple aux = consultas.inicio;
            while(aux != null && contador < 10)
            {
                if(opcion == 0)
                {

                    texto += aux.nickname + " " + aux.valor.ToString() +Environment.NewLine;
                    contador++;
                }
                else
                {

                    texto += aux.nickname + " " + aux.valor.ToString() +"%" +Environment.NewLine;
                    contador++;
                }
                aux = aux.siguiente;
            }
            return texto;
        }

        //Recorre el árbol insertando cada nodo en la lista de consultas junto con el valor de unidades destruidas
        public void masUnidadesDestruidas(Nodo raiz)
        {
            if(raiz != null)
            {
                NodoListaSimple nuevo = new NodoListaSimple();
                nuevo.nickname = raiz.nickname;
                nuevo.valor = obtenerPorcentajeUnidadesDestruidas(raiz.listaJuegos);
                consultas.insertar(nuevo);

                masUnidadesDestruidas(raiz.izquierda);
                masUnidadesDestruidas(raiz.derecha);
            }
        }

        //Obtiene el porcentaje de unidades destruidas de una lista
        public int obtenerPorcentajeUnidadesDestruidas(ListaDoble lista)
        {
            int porcentaje = 0;
            int contador = 0;
            if(lista != null)
            {
                NodoLista aux = lista.inicio;
                while(aux != null)
                {
                    porcentaje += (aux.unidadesDestruidas * 100) / aux.unidadesDesplegadas;
                    contador++;
                    aux = aux.siguiente;
                }
            }
            if(contador != 0)
            {
                return porcentaje / contador;
            }
            else
            {
                return 0;
            }
        }

    }
}