using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class Nodo
    {
        public Nodo izquierda { get; set; }
        public Nodo derecha { get; set; }
        public Nodo padre { get; set; }
        public string nickname { get; set; }
        public string contraseña { get; set; }
        public string correoElectronico { get; set; }
        public ArbolAVL contactos { get; set; }
        public bool conectado { get; set; }
        public ListaDoble listaJuegos { get; set; }
    }
}