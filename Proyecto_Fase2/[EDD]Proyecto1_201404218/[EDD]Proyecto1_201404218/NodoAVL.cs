using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class NodoAVL
    {

        public NodoAVL raiz { get; set; }
        public NodoAVL derecha { get; set; }
        public NodoAVL izquierda { get; set; }
        public int altura { get; set; }
        public string valor { get; set; }
        public NodoAVL papa { get; set; }

        public string contraseña { get; set; }
        public string correoElectronico { get; set; }


        public int obtenerAltura()
        {
            int val1 = 0, val2 = 0;
            bool valor1 = false, valor2 = false;

            if (izquierda != null)
            {
                val1 = izquierda.obtenerAltura();
                valor1 = true;
            }
            if (derecha != null)
            {
                val2 = derecha.obtenerAltura();
                valor2 = true;
            }

            if (valor1  && valor2)
            {
                if (val1 < val2)
                {
                    altura = val2 + 1;
                }
                else if (val1 > val2)
                {
                    altura = val1 + 1;
                }
                else
                {
                    altura = val1 + 1;
                }
            }
            else
            {
                if (valor1)
                {
                    altura = val1 + 1;
                }
                else if (valor2)
                {
                    altura = val2 + 1;
                }
                else
                {
                    altura = 0;
                }
            }
            return altura;
        }

        public int getFE()
        {
            int val1 = 0, val2 = 0, fe = 0;

            if (izquierda != null)
            {
                val1 = izquierda.altura + 1;
            }
            if (derecha != null)
            {
                val2 = derecha.altura + 1;
            }
            fe = val2 - val1;

            return fe;
        }


    }
}