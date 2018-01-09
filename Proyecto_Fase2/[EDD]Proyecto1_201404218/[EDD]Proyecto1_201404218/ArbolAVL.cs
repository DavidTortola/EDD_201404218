using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class ArbolAVL
    {

        public NodoAVL raiz { get; set; }
        public int nivel { get; set; }

        public void insertar(string valor, string contraseña, string correo)
        {
            raiz = insertar(valor, contraseña, correo, raiz);
            enlazarPapas(raiz, null);
        }

        public NodoAVL insertar(string valor, string contraseña, string correo, NodoAVL raiz)
        {
            if (raiz == null)
            {
                raiz = new NodoAVL();
                raiz.valor = valor;
                raiz.contraseña = contraseña;
                raiz.correoElectronico = correo;
            }
            else if (string.Compare(valor, raiz.valor) < 0)
            {
                NodoAVL aux = insertar(valor, contraseña, correo, raiz.izquierda);
                raiz.izquierda = aux;

                if ((altura(raiz.derecha) - altura(raiz.izquierda)) == -2)
                {
                    if (string.Compare(valor, raiz.izquierda.valor) < 0)
                    {
                        raiz = rotacionIzquierda(raiz);
                    }
                    else
                    {
                        raiz = rotacionDobleIzquierda(raiz);
                    }
                }
            }else if(string.Compare(valor, raiz.valor) > 0)
            {
                NodoAVL aux = insertar(valor, contraseña, correo, raiz.derecha);
                raiz.derecha = aux;

                if ((altura(raiz.derecha) - altura(raiz.izquierda)) == 2)
                {
                    if (string.Compare(valor, raiz.derecha.valor) > 0)
                    {
                        raiz = rotacionDerecha(raiz);
                    }
                    else
                    {
                        raiz = rotacionDobleDerecha(raiz);
                    }
                }
            }
            raiz.altura = Max(altura(raiz.izquierda), altura(raiz.derecha)) + 1;
            return raiz;
        }
        public int altura(NodoAVL nodo)
        {
            if (nodo == null)
            {
                return -1;
            }
            else
            {
                return nodo.altura;
            }
        }

        public int Max(int val1, int val2)
        {
            if (val1 > val2)
            {
                return val1;
            }
            else
            {
                return val2;
            }

        }

        public NodoAVL rotacionIzquierda(NodoAVL nodo)
        {
            if (nodo != null)
            {
                if (nodo.izquierda != null)
                {

                    NodoAVL aux = nodo.izquierda;
                    nodo.izquierda = aux.derecha;
                    aux.derecha = nodo;
                    nodo.altura = Max(altura(nodo.izquierda), altura(nodo.derecha)) + 1;
                    aux.altura = Max(altura(aux.izquierda), nodo.altura) + 1;
                    return aux;
                }
            }
            return null;
        }

        public NodoAVL rotacionDerecha(NodoAVL nodo)
        {
            if (nodo != null)
            {
                if (nodo.derecha != null)
                {

                    NodoAVL aux = nodo.derecha;
                    nodo.derecha = aux.izquierda;
                    aux.izquierda = nodo;
                    nodo.altura = Max(altura(nodo.derecha), altura(nodo.izquierda)) + 1;
                    aux.altura = Max(altura(aux.derecha), nodo.altura) + 1;
                    return aux;
                }
            }
            return null;
        }

        public NodoAVL rotacionDobleIzquierda(NodoAVL nodo)
        {
            nodo.izquierda = rotacionDerecha(nodo.izquierda);
            return rotacionIzquierda(nodo);
        }

        public NodoAVL rotacionDobleDerecha(NodoAVL nodo)
        {
            nodo.derecha = rotacionIzquierda(nodo.derecha);
            return rotacionDerecha(nodo);
        }

        public void enlazarPapas(NodoAVL nodo, NodoAVL papa)
        {
            if (nodo != null)
            {
                nodo.papa = papa;

                if (nodo.derecha != null)
                {
                    enlazarPapas(nodo.derecha, nodo);
                }

                if (nodo.izquierda != null)
                {
                    enlazarPapas(nodo.izquierda, nodo);
                }
            }
        }

        public string escribirDOT(NodoAVL raiz)
        {
            string texto = "";
            if (raiz != null)
            {

                texto += "\"" + raiz.valor + "\"[label=\"" + "<izquierda>|{<centro2>" + raiz.valor + "|" + raiz.contraseña + "|<centro>" + raiz.correoElectronico + "}|<derecha>\", shape = Mrecord];" + Environment.NewLine;


                if (raiz.izquierda != null)
                {
                    texto += raiz.valor + ":izquierda -> " + raiz.izquierda.valor + ":centro2;" + Environment.NewLine;
                    texto += escribirDOT(raiz.izquierda);
                }
                else
                {
                    texto += "nulli" + raiz.valor + " [shape = point];" + Environment.NewLine;
                    texto += raiz.valor + ":izquierda -> " + "nulli" + raiz.valor + ";" + Environment.NewLine;
                }
                if (raiz.derecha != null)
                {
                    texto += raiz.valor + ":derecha -> " + raiz.derecha.valor + ":centro2;" + Environment.NewLine;
                    texto += escribirDOT(raiz.derecha);
                }
                else
                {
                    texto += "nulld" + raiz.valor + " [shape = point];" + Environment.NewLine;
                    texto += raiz.valor + ":derecha -> " + "nulld" + raiz.valor + ";" + Environment.NewLine;
                }
            }
            return texto;
        }

        public void eliminar(string valor)
        {
            NodoAVL nodo = buscar(valor, raiz, null);

            enlazarPapas(raiz, null);

            eliminar(nodo);

            
        }
        
        public void eliminar(NodoAVL nodo)
        {
            bool derecha = false;
            bool izquierda = false;

            if(nodo != null)
            {
                if(nodo.derecha != null)
                {
                    derecha = true;
                }
                else
                {
                    derecha = false;
                }

                if(nodo.izquierda != null)
                {
                    izquierda = true;
                }
                else
                {
                    derecha = false;
                }

                if(derecha == false && izquierda == false)
                {
                    reBalanceo(caso1(nodo));
                }

                if(derecha == true && izquierda == false)
                {
                    reBalanceo(caso2(nodo));
                }

                if(derecha == false && izquierda == true)
                {
                    reBalanceo(caso2(nodo));
                }

                if(derecha == true && izquierda == true)
                {
                    reBalanceo(caso3(nodo));
                }


            }
        }
        
        public void reBalanceo(NodoAVL nodo)
        {

            while (nodo != null)
            {

                if (estaBalanceado(nodo))
                {
                    NodoAVL x = nodo;
                    NodoAVL y = mayorHijo(nodo);
                    NodoAVL z = mayorHijo(y);

                    nodo = reestructuracion(x, y, z);
                    colocarAlturas(raiz);

                }

                if(nodo != null)
                {
                    nodo = nodo.papa;
                }
            }
        }

        public NodoAVL caso1(NodoAVL nodo)
        {
            if(nodo != null)
            {
                if(nodo.papa == null)
                {
                    raiz = null;
                    return null;
                }
                else
                {
                    NodoAVL nodopapa = nodo.papa;
                    NodoAVL izquierda = nodopapa.izquierda;
                    NodoAVL derecha = nodopapa.derecha;
                    
                    if(izquierda != null)
                    {
                        if(izquierda.valor.Equals(nodo.valor))
                        {
                            nodo.papa.izquierda = null;
                        }
                    }

                    if(derecha != null)
                    {
                        if (derecha.valor.Equals(nodo.valor))
                        {
                            nodo.papa.derecha = null;
                        }
                    }
                    colocarAlturas(raiz);

                    return nodopapa;
                }
            }
            return null;
        }

        public NodoAVL caso2(NodoAVL nodo)
        {
            if(nodo != null)
            {
                if(nodo.papa != null)
                {
                    NodoAVL hijoizquierdo = nodo.papa.izquierda;
                    NodoAVL hijoderecho = nodo.papa.derecha;
                    NodoAVL actual;
                    if(nodo.izquierda != null)
                    {
                        actual = nodo.izquierda;
                    }
                    else
                    {
                        actual = nodo.derecha;
                    }

                    if(hijoizquierdo == nodo)
                    {
                        nodo.papa.izquierda = actual;
                        actual.papa = nodo.papa;
                        colocarAlturas(raiz);
                        return actual.papa;
                    }
                    if (hijoderecho == nodo)
                    {
                        nodo.papa.derecha = actual;
                        actual.papa = nodo.papa;
                        colocarAlturas(raiz);
                        return actual.papa;
                    }


                }
                else
                {
                    NodoAVL der = nodo.derecha;
                    NodoAVL iz = nodo.izquierda;

                    if (der != null)
                    {
                        raiz = der;
                        der.papa = null;
                        colocarAlturas(raiz);
                        return der;
                    }
                    else if (iz != null)
                    {
                        raiz = iz;
                        iz.papa = null;
                        colocarAlturas(raiz);
                        return iz;
                    }
                    colocarAlturas(raiz);
                    
                }
                colocarAlturas(raiz);
                return null;
            }

            colocarAlturas(raiz);
            return null;
        }

        public NodoAVL caso3(NodoAVL nodo)
        {
            if(nodo != null)
            {
                NodoAVL ultimoizquierda = recorrerIzquierda(nodo.derecha);

                if (ultimoizquierda == nodo.derecha)
                {
                    raiz = ultimoizquierda;

                    if(nodo.izquierda != null)
                    {

                        nodo.izquierda.papa = ultimoizquierda;
                    }
                    ultimoizquierda.izquierda = nodo.izquierda;
                    ultimoizquierda.papa = null;
                    

                    colocarAlturas(raiz);

                    return ultimoizquierda;


                    //ultimoizquierda = null;
                }
                if(ultimoizquierda != null)
                {
                    if(nodo.papa == null)
                    {
                        raiz = ultimoizquierda;
                        //PRUEBA

                        if(ultimoizquierda.derecha != null)
                        {
                            ultimoizquierda.derecha.papa = ultimoizquierda.papa;
                        }
                        if(ultimoizquierda.papa != null)
                        {
                            ultimoizquierda.papa.izquierda = ultimoizquierda.derecha;
                        }

                        ultimoizquierda.izquierda = nodo.izquierda;
                        ultimoizquierda.derecha = nodo.derecha;
                        ultimoizquierda.papa = null;
                        nodo.izquierda.papa = ultimoizquierda;
                        nodo.derecha.papa = ultimoizquierda;
                        
                            
                        colocarAlturas(raiz);

                        return ultimoizquierda;
                    }
                    else
                    {
                        if(nodo.papa.derecha == nodo)
                        {
                            nodo.papa.derecha = ultimoizquierda;
                        }
                        else if(nodo.papa.izquierda == nodo)
                        {
                            nodo.papa.izquierda = ultimoizquierda;
                        }
                    }
                    ultimoizquierda.papa.izquierda = null;
                    ultimoizquierda.izquierda = nodo.izquierda;
                    ultimoizquierda.derecha = nodo.derecha;
                    ultimoizquierda.papa = nodo.papa;

                    nodo.izquierda.papa = ultimoizquierda;
                    nodo.derecha.papa = ultimoizquierda;

                    colocarAlturas(raiz);
                    return nodo.papa;

                }
                else
                {
                    NodoAVL nododerecho = nodo.derecha;
                    if(nodo.papa == null)
                    {
                        raiz = nododerecho;
                    }
                    else
                    {
                        if(nodo.papa.derecha == nodo)
                        {
                            nodo.papa.derecha = nododerecho;
                        }
                        else if(nodo.papa.izquierda == nodo)
                        {
                            nodo.papa.izquierda = nododerecho;
                        }

                        nododerecho.papa = nodo.papa;
                        nododerecho.izquierda = nodo.izquierda;
                        colocarAlturas(raiz);
                        return nododerecho;
                    }
                }
            }
            return null;
        }

        public NodoAVL recorrerIzquierda(NodoAVL nodo)
        {
            if (nodo != null)
            {
                if (nodo.izquierda != null)
                {
                    return recorrerIzquierda(nodo.izquierda);

                }
            }
            return nodo;
        }

        public bool estaBalanceado(NodoAVL nodo)
        {
            if (nodo != null)
            {
                if (nodo.getFE() > 1 || nodo.getFE() < -1)
                {
                    return true;
                }
            }
            return false;
        }

        public NodoAVL mayorHijo(NodoAVL nodo)
        {
            NodoAVL iz = null;
            NodoAVL der = null;

            if(nodo != null)
            {
                if(nodo.izquierda != null)
                {
                    iz = nodo.izquierda;
                }
                if(nodo.derecha != null)
                {
                    der = nodo.derecha;
                }
                if(iz!=null && der != null)
                {
                    if(iz.altura > der.altura)
                    {
                        return iz;
                    }
                    else if(iz.altura < der.altura)
                    {
                        return der;
                    }
                    else
                    {
                        return der;
                    }
                }else if(iz != null)
                {
                    return iz;
                }else if(der != null)
                {
                    return der;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }




        public NodoAVL reestructuracion(NodoAVL x, NodoAVL y, NodoAVL z)
        {
            if(x!= null && y != null && z != null)
            {
                if (x.getFE() < -1)
                {
                    if (y.getFE() == 1)
                    {
                        if(raiz != x)
                        {
                            return rotacionDobleIzquierda(x);
                        }
                        else
                        {
                            raiz = rotacionDobleIzquierda(x);
                            return raiz;
                        }
                    }
                    else if (y.getFE() == -1)
                    {
                        if(raiz != x)
                        {
                            return rotacionIzquierda(x);
                        }
                        else
                        {
                            raiz = rotacionIzquierda(x);
                            return raiz;
                        }
                    }
                    else if (y.getFE() == 0)
                    {
                        if(raiz != x)
                        {
                            return rotacionIzquierda(x);
                        }
                        else
                        {
                            raiz = rotacionIzquierda(x);
                            return raiz;
                        }
                    }
                }
                else if (x.getFE() > 1)
                {
                    if(y.getFE() == -1)
                    {
                        if(raiz != x)
                        {
                            return rotacionDobleDerecha(x);
                        }
                        else
                        {
                            raiz = rotacionDobleDerecha(x);
                            return raiz;
                        }
                    }
                    else if(y.getFE() == 1)
                    {
                        if(raiz != x)
                        {
                            return rotacionDerecha(x);

                        }
                        else
                        {
                            raiz = rotacionDerecha(x);
                            return raiz;
                        }
                    }
                    else if (y.getFE() == 0)
                    {
                        if (raiz != x)
                        {
                            return rotacionDerecha(x);
                        }
                        else
                        {
                            raiz = rotacionDerecha(x);
                            return raiz;
                        }
                    }
                }
            }
            return null;
        }

        public void colocarAlturas(NodoAVL nodo)
        {
            if(nodo != null)
            {
                nodo.obtenerAltura();
            }
        }
        
        public NodoAVL buscar(string valor, NodoAVL nodo, NodoAVL padre)
        {
            if(nodo != null)
            {
                if(padre == null)
                {
                    if (string.Compare(valor, nodo.valor) < 0)
                    {
                        return buscar(valor, nodo.izquierda,nodo);
                    }
                    else if (string.Compare(valor, nodo.valor) > 0)
                    {
                        return buscar(valor, nodo.derecha, nodo);
                    }
                    else
                    {
                        return nodo;
                    }
                }
                else
                {
                    if (valor.Equals(nodo.valor))
                    {
                        return nodo;
                    }
                    else
                    {
                        if (string.Compare(valor, nodo.valor)<0)
                        {
                            return buscar(valor, nodo.izquierda, nodo);
                        }
                        else
                        {
                            return buscar(valor, nodo.derecha, nodo);
                        }
                    }
                }
               
            }
            return null;
        }
        
    }
}