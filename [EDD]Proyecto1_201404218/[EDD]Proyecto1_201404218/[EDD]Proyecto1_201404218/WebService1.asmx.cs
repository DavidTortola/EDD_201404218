using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _EDD_Proyecto1_201404218
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        //Árbol binario de búsqueda que almacena los usuarios
        static public Arbol arbol = new Arbol();

        [WebMethod]
        public string HelloWorld()
        {
            return "enviando del servidor al cliente";
        }

        [WebMethod]
        public string insertarUsuario(string nickname, string contraseña, string correoElectronico, bool conectado)
        {
            arbol.insertar(nickname, contraseña, correoElectronico, conectado);
            return arbol.escribirDOT(arbol.raiz);
        }

        [WebMethod]
        public string graficarUsuarios()
        {
            return arbol.escribirDOT(arbol.raiz);
        }
        
        [WebMethod]
        public string graficarEspejo()
        {
            return arbol.escribirEspejo(arbol.raiz);
        }

        [WebMethod]
        public string obtenerAltura()
        {
            return arbol.altura(arbol.raiz).ToString();
        }
        [WebMethod]
        public string obtenerHojas()
        {
            arbol.colocarDatos(arbol, arbol.raiz);
            return arbol.hojas.ToString();
        }
        [WebMethod]
        public string obtenerRamas()
        {
            arbol.colocarDatos(arbol, arbol.raiz);
            return arbol.ramas.ToString();
        }

        [WebMethod]
        public string obtenerNiveles()
        {
            return arbol.altura2(arbol.raiz).ToString();
        }

        [WebMethod]
        public void insertarJuego(string nickname, string oponente, int unidadesDesplegadas, int unidadesSobrevivientes, int unidadesDestruidas, bool gano)
        {
            if (arbol.raiz != null)
            {
                Nodo usuario = arbol.busqueda(nickname, arbol.raiz);
                //usuario.listaJuegos.inicializarLista();
                if(usuario != null)
                {
                    usuario.listaJuegos.insertar(nickname, oponente, unidadesDesplegadas, unidadesSobrevivientes, unidadesDestruidas, gano);
                }
            }
        }

        [WebMethod]
        public void limpiar()
        {
            arbol = new Arbol();
        }

        [WebMethod]
        public void eliminarUsuario(string nickname)
        {
            arbol.eliminar(arbol.busqueda(nickname, arbol.raiz));
        }


        //METODOS PARA OBTENER DATOS DE USUARIOS:
        [WebMethod]
        public string obtenerNickname(string nickname)
        {
            Nodo nuevo = arbol.busqueda(nickname, arbol.raiz);
            if (nuevo != null)
            {
                return nuevo.nickname;
            }
            else
            {
                return "NO SE HA ENCONTRADO";
            }
        }
        [WebMethod]
        public string obtenerPassword(string nickname)
        {
            Nodo nuevo = arbol.busqueda(nickname, arbol.raiz);
            if (nuevo != null)
            {
                return nuevo.contraseña;
            }
            else
            {
                return "NO SE HA ENCONTRADO";
            }
        }

        [WebMethod]
        public string obtenerCorreoElectronico(string nickname)
        {
            Nodo nuevo = arbol.busqueda(nickname, arbol.raiz);
            if (nuevo != null)
            {
                return nuevo.correoElectronico;
            }
            else
            {
                return "NO SE HA ENCONTRADO";
            }
        }

        [WebMethod]
        public string obtenerConectado(string nickname)
        {
            Nodo nuevo = arbol.busqueda(nickname, arbol.raiz);
            if (nuevo != null)
            {
                if (nuevo.conectado)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "NO SE HA ENCONTRADO";
            }
        }

        [WebMethod]
        public string obtenerJuegos(string nickname)
        {
            
            return arbol.escribirJuegos(nickname);
        }

        [WebMethod]
        public string consultarJuegosGanados()
        {
            return arbol.consultarJuegosGanados();
        }

        [WebMethod]
        public string consultarPorcentajeUnidadesDestruidas()
        {
            return arbol.consultarPorcentajeUnidadesDestruidas();
        }

        [WebMethod]
        public string login(string nickname, string password)
        {
            Nodo nuevo = arbol.busqueda(nickname, arbol.raiz);
            if(nuevo != null)
            {
                if (nuevo.contraseña.Equals(password))
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            else
            {
                return "false";
            }
        }

        [WebMethod]
        public void conectar(string nickname)
        {
            Nodo aux = arbol.busqueda(nickname, arbol.raiz);
            if ( aux != null)
            {
                aux.conectado = true;
            }
        }
    }
}
