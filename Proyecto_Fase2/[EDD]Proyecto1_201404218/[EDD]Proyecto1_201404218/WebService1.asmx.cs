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
        public string graficarAVL(string usuario)
        {
            if(arbol != null)
            {

                Nodo aux = arbol.busqueda(usuario, arbol.raiz);
                if(aux != null)
                {
                    string texto = "";

                    texto += aux.contactos.escribirDOT(aux.contactos.raiz);

                    return texto;
                }
                
            }
            return "";
        }

        [WebMethod]
        public void insertarContacto(string usuario, string usuario2, string contraseña, string correo)
        {
            if (arbol != null)
            {

                Nodo aux = arbol.busqueda(usuario, arbol.raiz);
                if(aux != null)
                {
                    aux.contactos.insertar(usuario2, contraseña, correo);
                }
                
            }
        }

        [WebMethod]
        public void eliminarContacto(string usuario, string usuario2)
        {
            if (arbol != null)
            {

                Nodo aux = arbol.busqueda(usuario, arbol.raiz);
                if (aux != null)
                {
                    aux.contactos.eliminar(usuario2);
                }

            }
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
        public string tiempoTerminado()
        {
            try
            {

                if (partida != null)
                {
                    if (partida.jugador1.unidades > partida.jugador2.unidades)
                    {
                        insertarJuego(partida.jugador1.nombre, partida.jugador2.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), true);
                        insertarJuego(partida.jugador2.nombre, partida.jugador1.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), false);
                        return "Ha ganado el jugador " + partida.jugador1.nombre;
                    }
                    else if (partida.jugador1.unidades < partida.jugador2.unidades)
                    {
                        insertarJuego(partida.jugador1.nombre, partida.jugador2.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), false);
                        insertarJuego(partida.jugador2.nombre, partida.jugador1.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), true);
                        return "Ha ganado el jugador " + partida.jugador2.nombre;
                    }
                    else
                    {
                        return "Ha sido un empate";
                    }

                }
            }catch(Exception e)
            {

            }
            return "";
        }


        [WebMethod]
        public string finDelJuego()
        {
            try
            {
                if (partida != null)
                {
                    if (partida.jugador2.unidades == 0)
                    {

                        insertarJuego(partida.jugador1.nombre, partida.jugador2.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), true);
                        insertarJuego(partida.jugador2.nombre, partida.jugador1.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), false);
                        return "Ha ganado el jugador " + partida.jugador1.nombre;
                    }
                    else if (partida.jugador1.unidades == 0)
                    {
                        insertarJuego(partida.jugador1.nombre, partida.jugador2.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), false);
                        insertarJuego(partida.jugador2.nombre, partida.jugador1.nombre, partida.getDesplegadas(), partida.getSobrevivientes(), (partida.getDesplegadas() - partida.getSobrevivientes()), true);
                        return "Ha ganado el jugador " + partida.jugador2.nombre;
                    }
                    else
                    {
                        return "";
                    }

                }
            }catch(Exception e)
            {

            }
            return "";
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


        //-----------------MÉTODOS PARA EL JUEGO------------------------//
        public static Partida partida = new Partida();


        [WebMethod]
        public void colocarUnidadesNivel0(string valor)
        {
            try
            {
                partida.unidadesNivel0 = Int32.Parse(valor);
            }catch(Exception e)
            {

            }
        }

        [WebMethod]
        public void colocarUnidadesNivel1(string valor)
        {
            try
            {
                partida.unidadesNivel1 = Int32.Parse(valor);
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public void colocarUnidadesNivel2(string valor)
        {
            try
            {
                partida.unidadesNivel2 = Int32.Parse(valor);
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public void colocarUnidadesNivel3(string valor)
        {
            try
            {
                partida.unidadesNivel3 = Int32.Parse(valor);
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public void colocarTamañoX(string valor)
        {
            try
            {
                partida.tamañoX = Int32.Parse(valor);
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public void colocarTamañoY(string valor)
        {
            try
            {
                partida.tamañoY = Int32.Parse(valor);
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public void colocarTipoJuego(string valor)
        {
            try
            {
                partida.tipoJuego = Int32.Parse(valor);
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public void colocarTiempo(string valor)
        {
            try
            {
                partida.tiempo = Int32.Parse(valor);
            }catch(Exception e)
            {

            }
        }

        [WebMethod]
        public int obtenerTiempo()
        {
            if (partida != null)
            {
                return partida.tiempo;
            }
            return 0;
        }

        [WebMethod]
        public int obtenerTipoJuego()
        {
            if (partida != null)
            {
                return partida.tipoJuego;
            }
            return 0;
        }

        [WebMethod]
        public void cargarDatos()
        {
            try
            {
                partida.cargarDatos();
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public void insertarJugador(string valor)
        {
            try
            {
                if(arbol.busqueda(valor, arbol.raiz)!= null)
                {
                    if(partida.jugador1 == null)
                    {
                        partida.jugador1 = new Jugador();
                        partida.jugador1.nombre = valor;
                    }
                    else if(partida.jugador2 == null)
                    {
                        partida.jugador2 = new Jugador();
                        partida.jugador2.nombre = valor;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public string estaIniciado()
        {
            if (partida.iniciado == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [WebMethod]
        public string estadoDeJuego()
        {
            if(partida.datosCargados == false)
            {
                return "Esperando la carga de datos";
            }else if(partida.iniciado == false)
            {
                if(partida.jugador1 == null && partida.jugador2 == null)
                {
                    return "Esperando 2 jugadores...";
                }else if(partida.jugador1 != null && partida.jugador2 == null)
                {
                    return "Jugador conectado: " + partida.jugador1.nombre + Environment.NewLine + " Esperando 1 jugador más...";
                }
                else
                {
                    return "Jugadores conectados: " + partida.jugador1.nombre + Environment.NewLine + "           " + partida.jugador2.nombre +Environment.NewLine +" Puede iniciar el juego!";
                }
            }
            else
            {
                return "¡Juego en proceso!" + "Jugadores conectados: " + partida.jugador1.nombre + Environment.NewLine + "           " + partida.jugador2.nombre;
            }
        }

        [WebMethod]
        public void iniciarJuego()
        {
            try
            {
                partida.iniciar();
            }
            catch (Exception e)
            {

            }
        }

        [WebMethod]
        public string juegoDisponible()
        {
            if(partida.datosCargados == true)
            {
                if(partida.jugador1 == null || partida.jugador2 == null)
                {
                    return "Juego disponible!";
                }
                else
                {
                    return "No hay ningún juego disponible";
                }
            }
            else
            {
                return "No hay ningún juego disponible";
            }
        }

        [WebMethod]
        public string obtenerArchivoPorNivel(string nivel)
        {
            if (partida.iniciado)
            {
                try
                {
                    int niv = Int32.Parse(nivel);
                    return partida.tablero.archivoPorNivel(niv);
                }
                catch (Exception e)
                {

                }
            }
            return "";
        }

        [WebMethod]
        public string cantidadRestante(string nivel, string usuario)
        {
            if (!nivel.Equals("") && !usuario.Equals(""))
            {
                if (partida.iniciado)
                {
                    try
                    {
                        int niv = Int32.Parse(nivel);
                        if (partida.jugador1.nombre.Equals(usuario))
                        {
                            if (niv == 0)
                            {
                                return partida.jugador1.unidadesNivel0.ToString();
                            }
                            else if (niv == 1)
                            {
                                return partida.jugador1.unidadesNivel1.ToString();
                            }
                            else if (niv == 2)
                            {
                                return partida.jugador1.unidadesNivel2.ToString();
                            }
                            else if (niv == 3)
                            {
                                return partida.jugador1.unidadesNivel3.ToString();
                            }
                            else
                            {
                                return "";
                            }
                        }else if (partida.jugador2.nombre.Equals(usuario))
                        {
                            if (niv == 0)
                            {
                                return partida.jugador2.unidadesNivel0.ToString();
                            }
                            else if (niv == 1)
                            {
                                return partida.jugador2.unidadesNivel1.ToString();
                            }
                            else if (niv == 2)
                            {
                                return partida.jugador2.unidadesNivel2.ToString();
                            }
                            else if (niv == 3)
                            {
                                return partida.jugador2.unidadesNivel3.ToString();
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return "";


        }


        [WebMethod]
        public void insertarUnidad(string x, string y, string subtipo, string usuario, string nivel)
        {
            if (partida.iniciado)
            {
                if (validarPosicion(x, y))
                {
                    partida.insertarUnidad(x, y, subtipo, usuario, nivel);
                }
            }
        }

        [WebMethod]
        public void jugadorPreparado(string usuario)
        {
            partida.jugadorPreparado(usuario);
            partida.activarMovimientos();
        }

        [WebMethod]
        public string estadoJuegoJugadores()
        {
            return partida.estadoJuegoJugadores();
        }

        [WebMethod]
        public string obtenerArchivoInicial(string nivel)
        {
            if (partida != null)
            {
                return partida.estadoInicial(nivel);
            }
            return "";
        }

        //Este método devuelve un string "true" o "false" si el jugador está preparado
        [WebMethod]
        public string jugadorEstaPreparado(string jugador)
        {
            if(partida != null)
            {
                if(partida.jugador1 != null)
                {
                    if (partida.jugador1.preparado && partida.jugador1.nombre.Equals(jugador))
                    {
                        return "true";
                    }
                    else if(partida.jugador2 != null)
                    {
                        
                        if (partida.jugador2.preparado && partida.jugador2.nombre.Equals(jugador))
                        {
                            return "true";
                        }
                    }
                }
                else
                {
                    if (partida.jugador2 != null)
                    {

                        if (partida.jugador2.preparado && partida.jugador2.nombre.Equals(jugador))
                        {
                            return "true";
                        }
                    }
                }
            }
            return "false";
        }
        
        [WebMethod]
        public void masterReset()
        {
            arbol = new Arbol();
            partida = new Partida();
            textoConsola = "";
        }

        [WebMethod]
        public string moverUnidad(string x, string y, string nivel, string usuario, string x2, string y2)
        {
            
            if(partida != null)
            {
                if (partida.mover)
                {
                    if (validarPosicion(x, y))
                    {
                        if (partida.jugador1.nombre.Equals(usuario))
                        {
                            if (partida.tablero.obtenerNodo(x, y) != null)
                            {
                                NodoM aux = partida.tablero.obtenerNivel(partida.tablero.obtenerNodo(x, y), Int32.Parse(nivel));

                                if (aux != null)
                                {
                                    if (aux.unidad.usuario.Equals(usuario))
                                    {
                                        if (validarDistancia(x, convertirString(y), x2, convertirString(y2), aux.unidad.movimiento))
                                        {
                                            if (partida.tablero.insertar(x2, y2, aux.unidad))
                                            {
                                                partida.tablero.eliminar(x, y, Int32.Parse(nivel));
                                                textoConsola += "El usuario " + aux.unidad.usuario + " ha movido su " + aux.unidad.subtipo + " de " + x + "," + y + " a la posición " + x2 + "," + y2 + ".\n";
                                                return "se ha movido " + aux.unidad.subtipo + " de " + usuario;
                                            }
                                            else
                                            {
                                                NodoM aux2 = partida.tablero.obtenerNodo(x2,y2);
                                                return "La posicón a la que se quiere mover ya está ocupada.";
                                            }
                                        }
                                        return aux.unidad.subtipo + " no se puede mover más de " + aux.unidad.movimiento;

                                    }
                                    return "La unidad no es del usuario " + usuario + " es de " + aux.unidad.usuario;
                                }
                                return "La unidad no está en este nodo";
                            }
                            return "El nodo no existe.";
                        }
                        else if (partida.jugador2.nombre.Equals(usuario))
                        {
                            if (partida.tablero.obtenerNodo(x, y) != null)
                            {
                                NodoM aux = partida.tablero.obtenerNivel(partida.tablero.obtenerNodo(x, y), Int32.Parse(nivel));

                                if (aux != null)
                                {
                                    if (aux.unidad.usuario.Equals(usuario))
                                    {
                                        if (validarDistancia(x, convertirString(y), x2, convertirString(y2), aux.unidad.movimiento))
                                        {
                                            if (partida.tablero.insertar(x2, y2, aux.unidad))
                                            {
                                                partida.tablero.eliminar(x, y, Int32.Parse(nivel));
                                                textoConsola += "El usuario " + aux.unidad.usuario + " ha movido su " + aux.unidad.subtipo +" de " +x +"," +y  + " a la posición " + x2 + "," + y2 + ".\n";
                                                return "se ha movido " + aux.unidad.subtipo + " de " + usuario;
                                            }
                                            return "La posicón a la que se quiere mover ya está ocupada.";
                                        }
                                        return aux.unidad.subtipo + " no se puede mover más de " + aux.unidad.movimiento;
                                    }
                                    return "La unidad no es del usuario " + usuario + " es de " + aux.unidad.usuario;
                                }
                                return "La unidad no está en este nodo";
                            }
                            return "El nodo no existe.";
                        }
                        return "el usuario " + usuario + " no esta en la partida";
                    }
                    return "La posición está fuera del tablero";
                }
                return "no se puede mover aún";
            }
            return "la partida no existe";

        }
        
        public bool validarDistancia(string xa, int ya, string xb, int yb, int distancia2)
        {
            double x1, y1, x2, y2;

            x1 = Int32.Parse(xa);
            y1 = ya;
            x2 = Int32.Parse(xb);
            y2 = yb;

            double distancia = Math.Sqrt(Math.Pow((x2-x1),2)+Math.Pow((y2-y1),2));

            if(distancia <= distancia2)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        public bool validarDistanciaMinima(string xa, int ya, string xb, int yb, int distancia2)
        {
            double x1, y1, x2, y2;

            x1 = Int32.Parse(xa);
            y1 = ya;
            x2 = Int32.Parse(xb);
            y2 = yb;

            double distancia = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));

            if (distancia >= distancia2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public bool validarPosicion(string x, string y)
        {
            try
            {
                if (Int32.Parse(x) > partida.tamañoX || convertirString(y) >= partida.tamañoY)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        [WebMethod]
        public string obtenerX()
        {
            if(partida != null)
            {
                return partida.tamañoX.ToString();
            }
            else
            {
                return "";
            }
        }

        [WebMethod]
        public string obtenerY()
        {
            if(partida != null)
            {
                return partida.tamañoY.ToString();
            }
            else
            {
                return "";
            }
        }

        public static string textoConsola;
        

        [WebMethod]
        public string obtenerConsola()
        {
            return textoConsola;
        }


        [WebMethod]
        public string atacar(string x, string y, string nivel, string usuario, string x2, string y2, string nivel2)
        {
            if(partida != null)
            {
                if (partida.mover)
                {
                    NodoM aux = partida.tablero.obtenerNivel(partida.tablero.obtenerNodo(x, y), Int32.Parse(nivel));
                    if (aux != null)
                    {
                        if (aux.unidad.usuario.Equals(usuario))
                        {
                            if (validarAtaque(x, y, aux.unidad.subtipo, nivel, x2, y2, nivel2))
                            {
                                NodoM aux2 = partida.tablero.obtenerNivel(partida.tablero.obtenerNodo(x2, y2), Int32.Parse(nivel2));
                                if (aux2 != null)
                                {
                                    if (!aux2.unidad.usuario.Equals(usuario))
                                    {
                                        aux2.unidad.vida -= aux.unidad.daño;
                                        textoConsola += "El " + aux2.unidad.subtipo + " de " + aux2.unidad.usuario + " en " + x2 + "," + y2 + " ha recibido " + aux.unidad.daño + " puntos de daño por el " + aux.unidad.subtipo + " de " + usuario + " en " + x + "," + y + ".\n";
                                        if (aux2.unidad.vida <= 0)
                                        {
                                            partida.tablero.eliminar(x2, y2, Int32.Parse(nivel2));
                                            if (partida.jugador1.nombre.Equals(aux2.unidad.usuario))
                                            {
                                                partida.jugador1.unidades--;
                                                textoConsola += "El " + aux2.unidad.subtipo + " de " + aux2.unidad.usuario + " en " + x2 + "," + y2 + " ha sido destruida por " + usuario +".\n";

                                                if(partida.jugador1.unidades <= 0)
                                                {
                                                    //La partida ha terminado
                                                }

                                                return "La unidad de " + aux2.unidad.usuario + " ha sido destruida.";
                                            }else if (partida.jugador2.nombre.Equals(aux2.unidad.usuario))
                                            {
                                                partida.jugador2.unidades--;
                                                textoConsola += "El " + aux2.unidad.subtipo + " de " + aux2.unidad.usuario + " en " + x2 + "," + y2 + " ha sido destruida por " + usuario + ".\n";

                                                if(partida.jugador2.unidades <= 0)
                                                {
                                                    //La partida ha terminado
                                                }


                                                return "La unidad de " + aux2.unidad.usuario + " ha sido destruida.";
                                            }
                                            
                                        }
                                        
                                        return "La unidad de " +aux2.unidad.usuario +" ha sido atacada en " +x2 +"," +y2 +".";
                                    }

                                    return "No puedes atacar a una unidad que te pertenece";
                                }
                                return "No existe una unidad en la posición " + x + "," + y + " en el nivel " + nivel2;
                            }
                            return "El " + aux.unidad.subtipo + " de " + usuario + " no puede atacar a la posición deseada.";
                        }
                        return "La unidad que " + usuario + " quiere utilizar, no le pertenece";
                    }
                    return "La unidad atacante de " + usuario + " en la posición " + x + "," + y + " no existe.";
                }
                return "Aún no se han terminado de colocar las unidades";
            }
            return "La partida aún no empieza";
        }

        public bool validarAtaque(string x1, string y1, string subtipo, string nivel, string x2, string y2, string nivel2)
        {
            switch (subtipo)
            {

                case "neosatelite":

                    if(validarDistancia(x1, convertirString(y1), x2, convertirString(y2), 0))
                    {
                        if (!nivel2.Equals("3"))
                        {
                            return true;
                        }
                    }
                    return false;

                case "bombardero":
                    if (validarDistancia(x1, convertirString(y1), x2, convertirString(y2), 0))
                    {
                        if (!nivel2.Equals("3") && !nivel2.Equals("2"))
                        {
                            return true;
                        }
                    }
                    return false;
                case "caza":
                    if (validarDistancia(x1, convertirString(y1), x2, convertirString(y2),1))
                    {
                        return true;
                    }
                    return false;
                case "helicoptero de combate":
                    if (validarDistancia(x1, convertirString(y1), x2, convertirString(y2), 1))
                    {
                        return true;
                    }
                    return false;
                case "fragata":
                    if (validarDistancia(x1, convertirString(y1), x2, convertirString(y2), 6))
                    {
                        if (validarDistanciaMinima(x1, convertirString(y1), x2, convertirString(y2), 2))
                        {
                            return true;
                        }
                    }
                    return false;
                case "crucero":
                    if (validarDistancia(x1, convertirString(y1), x2, convertirString(y2), 1))
                    {
                        return true;
                    }
                    return false;
                case "submarino":
                    if (validarDistancia(x1, convertirString(y1), x2, convertirString(y2), 1))
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        //-----------------------------------------------------------------------
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

    }
}
