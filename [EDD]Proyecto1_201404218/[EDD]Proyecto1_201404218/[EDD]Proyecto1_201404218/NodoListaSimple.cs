using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class NodoListaSimple
    {
        public NodoListaSimple siguiente { get; set; }
        public NodoListaSimple anterior { get; set; }
        public string nickname { get; set; }
        public int valor { get; set; }
    }
}