using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class NodoM
    {
        public NodoM arriba { get; set; }
        public NodoM abajo { get; set; }
        public NodoM derecha { get; set; }
        public NodoM izquierda { get; set; }
        public NodoM adelante { get; set; }
        public NodoM atras { get; set; }
        public Unidad unidad { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string valor { get; set; }

        public NodoM()
        {
            arriba = null;
            abajo = null;
            derecha = null;
            izquierda = null;
            adelante = null;
            atras = null;
            unidad = null;
            valor = "";
        }

        public int getZ()
        {
            if (unidad != null)
            {
                switch (unidad.tipo)
                {
                    case "satelite":
                        return 3;
                        break;
                    case "avion":
                        return 2;
                        break;
                    case "barco":
                        return 1;
                        break;
                    case "submarino":
                        return 0;
                        break;
                    default:
                        return -1;
                        break;
                }
            }
            else
            {
                return -1;
            }
        }

    }
}