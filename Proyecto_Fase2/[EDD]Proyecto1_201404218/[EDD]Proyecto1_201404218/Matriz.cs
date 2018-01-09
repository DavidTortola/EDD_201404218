using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class Matriz
    {
        public ListaDobleV listaVertical { get; set; }
        public ListaDobleH listaHorizontal { get; set; }
        public int tamaño { get; set; }

        public int modificador = 2;
        
        public Matriz()
        {
            listaVertical = null;
            listaHorizontal = null;
            tamaño = 0;
        }

        public bool insertar(string x, string y, string subtipo, string usuario)
        {
            if (!x.Equals("") && !y.Equals("") && !subtipo.Equals(""))
            {
                y = y.ToUpper();
                subtipo = subtipo.ToLower();
                Unidad unidad = new Unidad(subtipo, usuario);
                if (!unidad.subtipo.Equals(""))
                {
                    return insertar(x, y, unidad);
                    
                }
            }
            return false;
        }

        public bool esVacia()
        {
            if (tamaño > 0)
            {
                return false;
            }
            return true;
        }

        public bool insertar(string x, string y, Unidad unidad)
        {
            if (esVacia())
            {

                listaVertical = new ListaDobleV();
                listaHorizontal = new ListaDobleH();

                NodoM nuevo = new NodoM();
                nuevo.unidad = unidad;
                nuevo.x = x;
                nuevo.y = y;

                listaVertical.insertar(x);
                listaHorizontal.insertar(y);

                NodoM encabezadoVertical = listaVertical.buscar(x);
                NodoM encabezadoHorizontal = listaHorizontal.buscar(y);

                encabezadoVertical.derecha = nuevo;
                encabezadoHorizontal.abajo = nuevo;

                nuevo.arriba = encabezadoHorizontal;
                nuevo.izquierda = encabezadoVertical;

                tamaño++;
                return true;
            }
            else
            {
                if (listaVertical.buscar(x) != null && listaHorizontal.buscar(y) != null)
                {
                    return existenAmbosEncabezados(x, y, unidad);
                }
                else if (listaVertical.buscar(x) == null && listaHorizontal.buscar(y) != null)
                {
                    return existeHorizontal(x, y, unidad);
                }
                else if (listaVertical.buscar(x) != null && listaHorizontal.buscar(y) == null)
                {
                    return existeVertical(x, y, unidad);
                }
                else if (listaVertical.buscar(x) == null && listaHorizontal.buscar(y) == null)
                {
                    return noExisten(x, y, unidad);
                }
            }
            return false;
            
        }

        //Devuelve true/false si existe o no un nodo con las coordenadas x,y
        public bool comparar(string x, string y)
        {
            NodoM aux = listaHorizontal.buscar(y);

            if (aux != null)
            {
                aux = aux.abajo;
                while (aux != null)
                {
                    if (aux.x.Equals(x))
                    {
                        return true;
                    }
                    else
                    {
                        aux = aux.abajo;
                    }
                }
            }
            return false;
        }

        //Busca en la matriz un nodo con las coordenadas x, y
        //si existe lo devuelve, sino, devuelve null
        public NodoM obtenerNodo(string x, string y)
        {

            NodoM nodo = null;
            if (comparar(x, y))
            {
                NodoM aux = listaHorizontal.buscar(y);
                aux = aux.abajo;
                while (aux != null)
                {
                    if (aux.x.Equals(x))
                    {
                        nodo = aux;
                        break;
                    }
                    else
                    {
                        aux = aux.abajo;
                    }
                }
            }
            return nodo;
        }

        public bool existenAmbosEncabezados(string x, string y, Unidad unidad)
        {
            //Se busca el nodo en la posición x,y
            NodoM nodo = obtenerNodo(x, y);

            //Si el nodo existe, se agrega el nuevo nodo con relación a este.
            if (nodo != null)
            {
                NodoM nuevo = new NodoM();
                nuevo.x = x;
                nuevo.y = y;
                nuevo.unidad = unidad;

                return agregarANodo(nodo, nuevo);
                
            }
            //Si no existe un nodo en las coordenadas x,y
            else
            {

                //-----------------------PARA INSERTAR EN Y----------------------//

                //Se crea el nuevo nodo
                NodoM nuevo = new NodoM();
                nuevo.x = x;
                nuevo.y = y;
                nuevo.unidad = unidad;

                //Se busca el encabezado en donde se va a insertar
                //y se recorre hacia abajo buscando la posicion en y a insertar
                NodoM aux = listaHorizontal.buscar(y);
                aux = aux.abajo;
                bool agregado = false;
                while (aux != null)
                {
                    if (esMayor(aux.x, x) < 0)
                    {
                        aux = aux.abajo;
                    }
                    else
                    {
                        //Se inserta si se encuentra la posición correcta en y
                        nuevo.abajo = aux;
                        nuevo.arriba = aux.arriba;
                        aux.arriba.abajo = nuevo;
                        aux.arriba = nuevo;
                        tamaño++;
                        agregado = true;
                        break;
                    }
                }

                //Si no se agregó, se agrega hasta abajo del encabezado
                if (!agregado)
                {
                    aux = listaHorizontal.buscar(y);
                    aux = aux.abajo;

                    while (aux.abajo != null)
                    {
                        aux = aux.abajo;
                    }

                    nuevo.arriba = aux;
                    aux.abajo = nuevo;
                    tamaño++;

                }

                //-----------------------PARA INSERTAR EN X----------------------//

                //Se recorre buscando la posición correcta en X
                NodoM auxV = listaVertical.buscar(x);
                auxV = auxV.derecha;
                agregado = false;
                while (auxV != null)
                {
                    if (esMayor2(auxV.y, y) < 0)
                    {
                        auxV = auxV.derecha;
                    }
                    else
                    {
                        //Si se encuentra se inserta
                        nuevo.derecha = auxV;
                        nuevo.izquierda = auxV.izquierda;
                        auxV.izquierda.derecha = nuevo;
                        auxV.izquierda = nuevo;
                        tamaño++;
                        agregado = true;
                        break;
                    }
                }

                //Si no se insertó, se inserta al final del encabezado vertical
                if (!agregado)
                {
                    auxV = listaVertical.buscar(x);
                    auxV = auxV.derecha;

                    while (auxV.derecha != null)
                    {
                        auxV = auxV.derecha;
                    }

                    auxV.derecha = nuevo;
                    nuevo.izquierda = auxV;
                    tamaño++;

                }
                return true;
            }
            return false;
        }

        public bool existeHorizontal(string x, string y, Unidad unidad)
        {
            //Se crea la cabezera en y
            listaVertical.insertar(x);

            //Se crea el nuevo nodo
            NodoM nuevo = new NodoM();
            nuevo.x = x;
            nuevo.y = y;
            nuevo.unidad = unidad;

            NodoM aux = listaHorizontal.buscar(y);
            aux = aux.abajo;

            bool agregado = false;
            while (aux != null)
            {
                if (esMayor(aux.x, x) < 0)
                {
                    aux = aux.abajo;
                }
                else
                {
                    nuevo.abajo = aux;
                    nuevo.arriba = aux.arriba;
                    aux.arriba.abajo = nuevo;
                    aux.arriba = nuevo;
                    agregado = true;
                    tamaño++;
                    break;
                }
            }
            if (!agregado)
            {
                aux = listaHorizontal.buscar(y);
                aux = aux.abajo;
                while (aux.abajo != null)
                {
                    aux = aux.abajo;
                }
                nuevo.arriba = aux;
                aux.abajo = nuevo;
                tamaño++;
            }

            NodoM auxV = listaVertical.buscar(x);
            auxV.derecha = nuevo;
            nuevo.izquierda = auxV;
            tamaño++;

            return true;

        }

        public bool existeVertical(string x, string y, Unidad unidad)
        {
            listaHorizontal.insertar(y);

            NodoM nuevo = new NodoM();
            nuevo.x = x;
            nuevo.y = y;
            nuevo.unidad = unidad;

            NodoM auxV = listaVertical.buscar(x);
            auxV = auxV.derecha;
            bool agregado = false;
            while (auxV != null)
            {
                if (esMayor2(auxV.y, y) < 0)
                {
                    auxV = auxV.derecha;
                }
                else
                {
                    nuevo.derecha = auxV;
                    nuevo.izquierda = auxV.izquierda;
                    auxV.izquierda.derecha = nuevo;
                    auxV.izquierda = nuevo;
                    tamaño++;
                    agregado = true;
                    break;
                }
            }

            if (!agregado)
            {
                auxV = listaVertical.buscar(x);
                auxV = auxV.derecha;
                while (auxV.derecha != null)
                {
                    auxV = auxV.derecha;
                }
                nuevo.izquierda = auxV;
                auxV.derecha = nuevo;
                tamaño++;
            }

            NodoM aux = listaHorizontal.buscar(y);
            aux.abajo = nuevo;
            nuevo.arriba = aux;
            tamaño++;

            return true;

        }

        public bool noExisten(string x, string y, Unidad unidad)
        {
            listaHorizontal.insertar(y);
            listaVertical.insertar(x);

            NodoM nuevo = new NodoM();
            nuevo.x = x;
            nuevo.y = y;
            nuevo.unidad = unidad;

            NodoM aux = listaHorizontal.buscar(y);
            NodoM auxV = listaVertical.buscar(x);

            aux.abajo = nuevo;
            auxV.derecha = nuevo;

            nuevo.arriba = aux;
            nuevo.izquierda = auxV;
            tamaño++;
            tamaño++;

            return true;

        }

        //Método en el que se agrega un nodo a una posición donde ya existía un nodo.
        //Funciona evaluando todas las combinaciones, para los valores del nodo actual 0,1,2,3
        //y el nodo nuevo 0,1,2,3
        public bool agregarANodo(NodoM nodo, NodoM nuevo)
        {
            if (nodo.getZ() == 0)
            {
                if (nuevo.getZ() == 1)
                {
                    if (nodo.adelante == null)
                    {
                        nodo.adelante = nuevo;
                        nuevo.atras = nodo;
                        colocarApuntadores(nodo, nuevo);
                        tamaño++;
                    }
                    else if (nodo.adelante.getZ() != 1)
                    {
                        nuevo.adelante = nodo.adelante;
                        nuevo.atras = nodo;
                        nodo.adelante.atras = nuevo;
                        nodo.adelante = nuevo;
                        colocarApuntadores(nodo, nuevo);
                        tamaño++;
                    }
                    return true;
                }
                else if (nuevo.getZ() == 2)
                {
                    if (nodo.adelante == null)
                    {
                        nodo.adelante = nuevo;
                        nuevo.atras = nodo;
                        tamaño++;
                    }
                    else if (nodo.adelante.getZ() == 3)
                    {
                        nuevo.adelante = nodo.adelante;
                        nuevo.atras = nodo;
                        nodo.adelante.atras = nuevo;
                        nodo.adelante = nuevo;
                        tamaño++;
                    }
                    return true;
                }
                else if (nuevo.getZ() == 3)
                {
                    if (nodo.adelante == null)
                    {
                        nodo.adelante = nuevo;
                        nuevo.atras = nodo;
                        tamaño++;
                    }
                    else if (nodo.adelante.getZ() == 2)
                    {
                        nodo.adelante.adelante = nuevo;
                        nuevo.atras = nodo.adelante;
                        tamaño++;
                    }
                    return true;
                }
            }
            else if (nodo.getZ() == 1)
            {
                if (nuevo.getZ() == 0)
                {
                    if (nodo.atras == null)
                    {
                        nodo.atras = nuevo;
                        nuevo.adelante = nodo;
                        tamaño++;
                        return true;
                    }
                }
                else if (nuevo.getZ() == 2)
                {
                    if (nodo.adelante == null)
                    {
                        nodo.adelante = nuevo;
                        nuevo.atras = nodo;
                        tamaño++;

                        return true;
                    }
                    else if (nodo.adelante.getZ() == 3)
                    {
                        nuevo.adelante = nodo.adelante;
                        nuevo.atras = nodo;

                        nodo.adelante.atras = nuevo;
                        nodo.adelante = nuevo;

                        tamaño++;

                        return true;
                    }
                }
                else if (nuevo.getZ() == 3)
                {
                    if (nodo.adelante == null)
                    {
                        nodo.adelante = nuevo;
                        nuevo.atras = nodo;
                        tamaño++;
                        return true;
                    }
                    else if (nodo.adelante.getZ() == 2)
                    {
                        if (nodo.adelante.adelante == null)
                        {
                            nodo.adelante.adelante = nuevo;
                            nuevo.atras = nodo.adelante;
                            tamaño++;
                            return true;
                        }
                    }
                    
                }
                
            }
            else if (nodo.getZ() == 2)
            {
                if (nuevo.getZ() == 0)
                {
                    if (nodo.atras == null)
                    {
                        nodo.atras = nuevo;
                        nuevo.adelante = nodo;
                        tamaño++;
                        return true;
                    }
                    
                }
                else if (nuevo.getZ() == 1)
                {
                    if (nodo.atras == null)
                    {
                        nodo.atras = nuevo;
                        nuevo.adelante = nodo;
                        colocarApuntadores(nodo, nuevo);
                        tamaño++;
                        return true;
                    }
                    else if (nodo.atras.getZ() == 0)
                    {
                        nuevo.adelante = nodo;
                        nuevo.atras = nodo.atras;

                        nodo.atras.adelante = nuevo;
                        nodo.atras = nuevo;

                        colocarApuntadores(nodo, nuevo);

                        tamaño++;
                        return true;
                    }
                }
                else if (nuevo.getZ() == 3)
                {
                    if (nodo.adelante == null)
                    {
                        nodo.adelante = nuevo;
                        nuevo.atras = nodo;
                        tamaño++;
                        return true;
                    }
                }
            }
            else if (nodo.getZ() == 3)
            {
                if (nuevo.getZ() == 0)
                {
                    if (nodo.atras == null)
                    {
                        nodo.atras = nuevo;
                        nuevo.adelante = nodo;
                        tamaño++;
                        return true;
                    }
                    else if (nodo.atras.getZ() == 2)
                    {
                        if (nodo.atras.atras == null)
                        {
                            nodo.atras.atras = nuevo;
                            nuevo.adelante = nodo.atras;
                            tamaño++;
                            return true;
                        }
                    }
                }
                else if (nuevo.getZ() == 1)
                {
                    if (nodo.atras == null)
                    {
                        nodo.atras = nuevo;
                        nuevo.adelante = nodo;
                        colocarApuntadores(nodo, nuevo);
                        tamaño++;
                        return true;
                    }
                    else if (nodo.atras.getZ() == 2)
                    {
                        if (nodo.atras.atras == null)
                        {
                            nodo.atras.atras = nuevo;
                            nuevo.adelante = nodo.atras;
                            colocarApuntadores(nodo, nuevo);
                            tamaño++;
                            return true;
                        }
                        else if (nodo.atras.atras.getZ() == 0)
                        {
                            nuevo.adelante = nodo.atras;
                            nuevo.atras = nodo.atras.atras;

                            nodo.atras.atras.adelante = nuevo;
                            nodo.atras.atras = nuevo;

                            colocarApuntadores(nodo, nuevo);

                            tamaño++;
                            return true;
                        }
                    }
                }
                else if (nuevo.getZ() == 2)
                {
                    if (nodo.atras == null)
                    {
                        nodo.atras = nuevo;
                        nuevo.adelante = nodo;
                        tamaño++;
                        return true;
                    }
                    else if (nodo.atras.getZ() == 0)
                    {
                        nuevo.atras = nodo.atras;
                        nuevo.adelante = nodo;

                        nodo.atras.adelante = nuevo;
                        nodo.atras = nuevo;

                        tamaño++;
                        return true;
                    }
                }
            }
            return false;
        }

        //Recibe dos nodos, al nuevo le coloca los del nodo para volverlo el principal en la matriz
        public void colocarApuntadores(NodoM nodo, NodoM nuevo)
        {
            nuevo.arriba = nodo.arriba;
            nuevo.abajo = nodo.abajo;
            nuevo.derecha = nodo.derecha;
            nuevo.izquierda = nodo.izquierda;

            if (nodo.arriba != null)
            {
                nodo.arriba.abajo = nuevo;
            }

            if (nodo.abajo != null)
            {
                nodo.abajo.arriba = nuevo;
            }

            if (nodo.derecha != null)
            {
                nodo.derecha.izquierda = nuevo;
            }

            if (nodo.izquierda != null)
            {
                nodo.izquierda.derecha = nuevo;
            }

            nodo.arriba = null;
            nodo.abajo = null;
            nodo.derecha = null;
            nodo.izquierda = null;

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

        //Compara dos strings con el criterio de orden A,B,C...Z,AA,AB...ZZ,AAA...
        public int esMayor2(string string1, string string2)
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

        public string escribirDOTPrincipal()
        {
            string texto = "";

            if (listaHorizontal != null)
            {
                NodoM aux = listaHorizontal.inicio;

                while (aux != null)
                {
                    NodoM aux2 = aux.abajo;
                    while (aux2 != null)
                    {
                        texto += "\"" + aux2.x + aux2.y + "\"[label=\"{<f0>" + aux2.unidad.subtipo + "|<f1>Mov:" + aux2.unidad.movimiento.ToString() + "|<f2>Vida:" + aux2.unidad.vida.ToString() + "|<f3>Alcance:" + aux2.unidad.alcance.ToString() + "|<f4>Daño:" + aux2.unidad.daño.ToString() + "|<f5>Usuario:" + aux2.unidad.usuario + "}\", shape = Mrecord, pos=\"" + (convertirString(aux2.y) * modificador).ToString() + ",-" + (Int32.Parse(aux2.x) * modificador).ToString() + "!\"];" + Environment.NewLine;
                        aux2 = aux2.abajo;
                    }
                    aux = aux.derecha;
                }

            }

            if (listaHorizontal != null)
            {
                NodoM aux = listaHorizontal.inicio;

                while (aux != null)
                {
                    NodoM aux2 = aux.abajo;

                    if (aux2 != null)
                    {
                        texto += "\"" + aux.valor + "\" -> \"" + aux2.x + aux2.y + "\":f0;" + Environment.NewLine;
                    }

                    while (aux2.abajo != null)
                    {
                        texto += "\"" + aux2.x + aux2.y + "\":f5 -> \"" + aux2.abajo.x + aux2.abajo.y + "\":f0;" + Environment.NewLine;
                        aux2 = aux2.abajo;
                    }

                    aux = aux.derecha;
                }
            }
            
            if (listaVertical != null)
            {
                NodoM aux = listaVertical.inicio;
                while (aux != null)
                {
                    NodoM aux2 = aux.derecha;
                    if (aux2 != null)
                    {
                        texto += "\"" + aux.valor + "\" -> \"" + aux2.x + aux2.y + "\";" + Environment.NewLine;
                    }

                    while (aux2.derecha != null)
                    {
                        texto += "\"" + aux2.x + aux2.y + "\" -> \"" + aux2.derecha.x + aux2.derecha.y + "\";" + Environment.NewLine;
                        aux2 = aux2.derecha;
                    }
                    aux = aux.abajo;

                }
            }

            texto += "}" + Environment.NewLine;

            return texto;
        }

        public void graficarPrincipal(string nombre)
        {
            string texto = "digraph Matriz{ " + Environment.NewLine;


            texto += "node[shape = box, style = filled, color = black, fontcolor = white, fontname = \"Helvetica\", fontsize = 12];" + Environment.NewLine;

            if (listaVertical != null)
            {

                texto += listaVertical.escribirDOTPrincipal("0");
            }
            if (listaHorizontal != null)
            {

                texto += listaHorizontal.escribirDOTPrincipal("1");
            }

            texto += escribirDOTPrincipal();
            texto += "}";

            System.IO.File.WriteAllText("C:\\Reportes\\" + nombre + ".txt", texto);

            System.Diagnostics.ProcessStartInfo process = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + "fdp -Tpng \"C:\\Reportes\\" + nombre + ".txt\" -o \"C:\\Reportes\\" + nombre + ".png\"");
            process.RedirectStandardOutput = true;
            process.UseShellExecute = false;
            process.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = process;
            proc.Start();
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
        
        //ESTE MÉTODO RECIBE UN NODO, Y DEVUELVE EL NODO EN EL NIVEL ESPECIFICADO, SI ESTE EXISTE, SINO, RETORNA NULL.
        public NodoM obtenerNivel(NodoM nodo, int nivel)
        {
            if (nodo != null)
            {
                if (nodo.getZ() == 0)
                {
                    if (nivel == 0)
                    {
                        return nodo;
                    }
                    else if (nivel == 1)
                    {
                        return nodo.adelante;
                    }
                    else if (nivel == 2)
                    {
                        NodoM aux = nodo;
                        while (aux != null)
                        {
                            if (aux.getZ() == nivel)
                            {
                                return aux;
                            }
                            aux = aux.adelante;
                        }
                    }
                    else if (nivel == 3)
                    {
                        NodoM aux = nodo;
                        while (aux != null)
                        {
                            if (aux.getZ() == nivel)
                            {
                                return aux;
                            }
                            aux = aux.adelante;
                        }
                    }
                }
                else if (nodo.getZ() == 1)
                {
                    if (nivel == 0)
                    {
                        return nodo.atras;
                    }
                    else if (nivel == 1)
                    {
                        return nodo;
                    }
                    else if (nivel == 2)
                    {
                        if (nodo.adelante != null)
                        {
                            if (nodo.adelante.getZ() == 2)
                            {
                                return nodo.adelante;
                            }
                        }
                    }
                    else if (nivel == 3)
                    {
                        NodoM aux = nodo;
                        while (aux != null)
                        {
                            if (aux.getZ() == nivel)
                            {
                                return aux;
                            }
                            aux = aux.adelante;
                        }
                    }
                }
                else if (nodo.getZ() == 2)
                {
                    if (nivel == 0)
                    {
                        NodoM aux = nodo;
                        while (aux != null)
                        {
                            if (aux.getZ() == nivel)
                            {
                                return aux;
                            }
                            aux = aux.atras;
                        }
                    }
                    else if (nivel == 1)
                    {
                        return nodo.atras;
                    }
                    else if (nivel == 2)
                    {
                        return nodo;
                    }
                    else if (nivel == 3)
                    {
                        return nodo.adelante;
                    }
                }
                else if (nodo.getZ() == 3)
                {
                    if (nivel == 0)
                    {
                        NodoM aux = nodo;
                        while (aux != null)
                        {
                            if (aux.getZ() == nivel)
                            {
                                return aux;
                            }
                            aux = aux.atras;
                        }
                    }
                    else if (nivel == 1)
                    {
                        NodoM aux = nodo;
                        while (aux != null)
                        {
                            if (aux.getZ() == nivel)
                            {
                                return aux;
                            }
                            aux = aux.atras;
                        }
                    }
                    else if (nivel == 2)
                    {
                        return nodo.atras;
                    }
                    else if (nivel == 3)
                    {
                        return nodo;
                    }
                }
            }
            return null;
        }

        public void graficarNivel(string nombre, int nivel)
        {
            string texto = "digraph Matriz{ " + Environment.NewLine;

            texto += "node[shape = box, style = filled, color = black, fontcolor = white, fontname = \"Helvetica\", fontsize = 12, height=\"0.75\"];" + Environment.NewLine;

            if (listaVertical != null)
            {

                texto += listaVertical.escribirDOTPrincipal("0");
            }
            if (listaHorizontal != null)
            {

                texto += listaHorizontal.escribirDOTPrincipal("1");
            }
            texto += escribirDOTNivel(nivel);
            texto += "}";

            System.IO.File.WriteAllText("C:\\Reportes\\" + nombre + ".txt", texto);

            System.Diagnostics.ProcessStartInfo process = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + "fdp -Tpng \"C:\\Reportes\\" + nombre + ".txt\" -o \"C:\\Reportes\\" + nombre + ".png\"");
            process.RedirectStandardOutput = true;
            process.UseShellExecute = false;
            process.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = process;
            proc.Start();
        }

        public string archivoPorNivel(int nivel) {

            string texto = "digraph Matriz{ " + Environment.NewLine;

            texto += "node[shape = box, style = filled, color = black, fontcolor = white, fontname = \"Helvetica\", fontsize = 12, height=\"0.75\"];" + Environment.NewLine;

            if (listaVertical != null)
            {

                texto += listaVertical.escribirDOTPrincipal("0");
            }
            if (listaHorizontal != null)
            {

                texto += listaHorizontal.escribirDOTPrincipal("1");
            }
            texto += escribirDOTNivel(nivel);
            texto += "}";
            return texto;
        }

        public string escribirDOTNivel(int nivel)
        {
            string texto = "";

            if (listaHorizontal != null)
            {
                NodoM aux = listaHorizontal.inicio;

                while (aux != null)
                {
                    NodoM aux2 = aux.abajo;

                    while (aux2 != null)
                    {
                        NodoM temp = obtenerNivel(aux2, nivel);
                        if (temp != null)
                        {
                            texto += "\"" + temp.x + temp.y + "\"[label=\"{<f0>" + temp.unidad.subtipo + "|<f1>Vida:" + temp.unidad.vida.ToString() + "|<f2>Mov:" + temp.unidad.movimiento.ToString() + "|<f3>Alcance:" + temp.unidad.alcance.ToString() + "|<f4>Daño:" + temp.unidad.daño.ToString() + "|<f5>Usuario:" + temp.unidad.usuario + "}\", shape = Mrecord, pos=\"" + (convertirString(temp.y) * modificador).ToString() + ",-" + (Int32.Parse(temp.x) * modificador).ToString() + "!\"];" + Environment.NewLine;
                        }

                        aux2 = aux2.abajo;
                    }
                    aux = aux.derecha;
                }

            }

            if (listaHorizontal != null)
            {
                NodoM aux = listaHorizontal.inicio;

                while (aux != null)
                {

                    NodoM aux2 = aux.abajo;
                    NodoM temp = obtenerNivel(aux2, nivel);

                    while (temp == null && aux2 != null)
                    {
                        aux2 = aux2.abajo;
                        temp = obtenerNivel(aux2, nivel);
                    }

                    if (temp != null)
                    {
                        texto += "\"" + aux.valor + "\" -> \"" + temp.x + temp.y + "\":f0;" + Environment.NewLine;
                    }
                    if (aux2 != null)
                    {
                        aux2 = aux2.abajo;
                    }

                    while (aux2 != null)
                    {

                        if (obtenerNivel(aux2, nivel) != null)
                        {
                            texto += "\"" + temp.x + temp.y + "\":f5 -> \"" + obtenerNivel(aux2, nivel).x + obtenerNivel(aux2, nivel).y + "\":f0;" + Environment.NewLine;
                            temp = obtenerNivel(aux2, nivel);
                        }

                        aux2 = aux2.abajo;
                    }

                    aux = aux.derecha;
                }
            }

            if (listaVertical != null)
            {
                NodoM aux = listaVertical.inicio;

                while (aux != null)
                {

                    NodoM aux2 = aux.derecha;
                    NodoM temp = obtenerNivel(aux2, nivel);

                    while (temp == null && aux2 != null)
                    {
                        aux2 = aux2.derecha;
                        temp = obtenerNivel(aux2, nivel);
                    }

                    if (temp != null)
                    {
                        texto += "\"" + aux.valor + "\" -> \"" + temp.x + temp.y + "\";" + Environment.NewLine;
                    }
                    if (aux2 != null)
                    {
                        aux2 = aux2.derecha;
                    }

                    while (aux2 != null)
                    {

                        if (obtenerNivel(aux2, nivel) != null)
                        {
                            texto += "\"" + temp.x + temp.y + "\" -> \"" + obtenerNivel(aux2, nivel).x + obtenerNivel(aux2, nivel).y + "\";" + Environment.NewLine;
                            temp = obtenerNivel(aux2, nivel);
                        }

                        aux2 = aux2.derecha;
                    }

                    aux = aux.abajo;
                }
            }

            return texto;
        }

        public void eliminar(string x, string y, int nivel)
        {
            NodoM nodo = obtenerNodo(x, y);

            if (nodo != null)
            {
                if (nodo.getZ() == nivel)
                {
                    eliminarPrincipal(nodo);
                }
                else
                {
                    NodoM aux = obtenerNivel(nodo, nivel);
                    if (aux != null)
                    {
                        if (aux.atras != null)
                        {
                            aux.atras.adelante = aux.adelante;
                        }

                        if (aux.adelante != null)
                        {
                            aux.adelante.atras = aux.atras;
                        }

                    }
                }
            }
        }

        public void eliminarPrincipal(NodoM nodo)
        {
            if (nodo != null)
            {

                if (nodo.getZ() == 0)
                {
                    if (obtenerNivel(nodo, 1) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 1);
                        aux.atras = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 2) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 2);
                        aux.atras = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 3) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 3);
                        aux.atras = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else
                    {
                        if (nodo.arriba != null)
                        {
                            nodo.arriba.abajo = nodo.abajo;
                        }
                        if (nodo.abajo != null)
                        {
                            nodo.abajo.arriba = nodo.arriba;
                        }
                        if (nodo.derecha != null)
                        {
                            nodo.derecha.izquierda = nodo.izquierda;
                        }
                        if (nodo.izquierda != null)
                        {
                            nodo.izquierda.derecha = nodo.derecha;
                        }
                        NodoM encabezadoH = listaHorizontal.buscar(nodo.y);
                        if (encabezadoEsVacioH(encabezadoH))
                        {
                            listaHorizontal.eliminar(nodo.y);
                        }
                        NodoM encabezadoV = listaVertical.buscar(nodo.x);
                        if (encabezadoEsVacioV(encabezadoV))
                        {
                            listaVertical.eliminar(nodo.x);
                        }
                    }
                }
                else if (nodo.getZ() == 1)
                {
                    if (obtenerNivel(nodo, 0) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 0);
                        aux.adelante = nodo.adelante;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 2) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 2);
                        aux.atras = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 3) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 3);
                        aux.atras = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else
                    {
                        if (nodo.arriba != null)
                        {
                            nodo.arriba.abajo = nodo.abajo;
                        }
                        if (nodo.abajo != null)
                        {
                            nodo.abajo.arriba = nodo.arriba;
                        }
                        if (nodo.derecha != null)
                        {
                            nodo.derecha.izquierda = nodo.izquierda;
                        }
                        if (nodo.izquierda != null)
                        {
                            nodo.izquierda.derecha = nodo.derecha;
                        }
                        NodoM encabezadoH = listaHorizontal.buscar(nodo.y);
                        if (encabezadoEsVacioH(encabezadoH))
                        {
                            listaHorizontal.eliminar(nodo.y);
                        }
                        NodoM encabezadoV = listaVertical.buscar(nodo.x);
                        if (encabezadoEsVacioV(encabezadoV))
                        {
                            listaVertical.eliminar(nodo.x);
                        }
                    }
                }
                else if (nodo.getZ() == 2)
                {
                    if (obtenerNivel(nodo, 1) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 1);
                        aux.adelante = nodo.adelante;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 0) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 0);
                        aux.adelante = nodo.adelante;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 3) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 3);
                        aux.atras = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else
                    {
                        if (nodo.arriba != null)
                        {
                            nodo.arriba.abajo = nodo.abajo;
                        }
                        if (nodo.abajo != null)
                        {
                            nodo.abajo.arriba = nodo.arriba;
                        }
                        if (nodo.derecha != null)
                        {
                            nodo.derecha.izquierda = nodo.izquierda;
                        }
                        if (nodo.izquierda != null)
                        {
                            nodo.izquierda.derecha = nodo.derecha;
                        }
                        NodoM encabezadoH = listaHorizontal.buscar(nodo.y);
                        if (encabezadoEsVacioH(encabezadoH))
                        {
                            listaHorizontal.eliminar(nodo.y);
                        }
                        NodoM encabezadoV = listaVertical.buscar(nodo.x);
                        if (encabezadoEsVacioV(encabezadoV))
                        {
                            listaVertical.eliminar(nodo.x);
                        }
                    }
                }
                else if (nodo.getZ() == 3)
                {
                    if (obtenerNivel(nodo, 2) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 2);
                        aux.adelante = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 1) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 1);
                        aux.adelante = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else if (obtenerNivel(nodo, 0) != null)
                    {
                        NodoM aux = obtenerNivel(nodo, 0);
                        aux.adelante = null;
                        colocarApuntadores(nodo, aux);
                    }
                    else
                    {
                        if (nodo.arriba != null)
                        {
                            nodo.arriba.abajo = nodo.abajo;
                        }
                        if (nodo.abajo != null)
                        {
                            nodo.abajo.arriba = nodo.arriba;
                        }
                        if (nodo.derecha != null)
                        {
                            nodo.derecha.izquierda = nodo.izquierda;
                        }
                        if (nodo.izquierda != null)
                        {
                            nodo.izquierda.derecha = nodo.derecha;
                        }
                        NodoM encabezadoH = listaHorizontal.buscar(nodo.y);
                        if (encabezadoEsVacioH(encabezadoH))
                        {
                            listaHorizontal.eliminar(nodo.y);
                        }
                        NodoM encabezadoV = listaVertical.buscar(nodo.x);
                        if (encabezadoEsVacioV(encabezadoV))
                        {
                            listaVertical.eliminar(nodo.x);
                        }
                    }
                }
            }
        }

        public bool encabezadoEsVacioH(NodoM nodo)
        {
            while (nodo != null)
            {
                nodo = nodo.abajo;
                if (nodo != null)
                {
                    return false;
                }
                return true;
            }
            return true;

        }

        public bool encabezadoEsVacioV(NodoM nodo)
        {
            while (nodo != null)
            {
                nodo = nodo.derecha;
                if (nodo != null)
                {
                    return false;
                }
                return true;
            }
            return true;

        }

    }
}