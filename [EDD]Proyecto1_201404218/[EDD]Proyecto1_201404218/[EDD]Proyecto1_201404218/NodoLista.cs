using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class NodoLista
    {
        public NodoLista anterior { get; set; }
        public NodoLista siguiente { get; set; }
        public string nickname { get; set; }
        public string oponente { get; set; }
        public int unidadesDesplegadas { get; set; }
        public int unidadesSobrevivientes { get; set; }
        public int unidadesDestruidas { get; set; }
        public bool gano { get; set; }
    }
}