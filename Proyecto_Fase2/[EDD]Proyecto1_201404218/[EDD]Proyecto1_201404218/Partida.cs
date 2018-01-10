using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class Partida
    {

        //Clase partida:
        //Se crea el objeto
        //Se le colocan los valores
        //Se cambia el paràmetro datos cargados a true
        //Se inician los dos jugadores
        //Luego se inica el juego con el mètodo iniciar, que inicializa el tablero.

        //Luego se insertan las unidades antes de empezar.


        public int unidadesNivel0 { get; set; }
        public int unidadesNivel1 { get; set; }
        public int unidadesNivel2 { get; set; }
        public int unidadesNivel3 { get; set; }
        public int tamañoX { get; set; }
        public int tamañoY { get; set; }
        public int tipoJuego { get; set; } //1 = normal, 2 = tiempo, 3 = base
        public Jugador jugador1 { get; set; }
        public Jugador jugador2 { get; set; }
        public bool iniciado { get; set; }
        public bool datosCargados { get; set; }
        public Matriz tablero {get; set;}
        public bool mover { get; set; }

        public int tiempo { get; set; }

        public string estadoInicial0 { get; set; }
        public string estadoInicial1 { get; set; }
        public string estadoInicial2 { get; set; }
        public string estadoInicial3 { get; set; }

        public string ganador { get; set; }
        public void iniciar()
        {
            if (jugador1 != null && jugador2 != null && datosCargados)
            {
                WebService1.termino = false;
                jugador1.unidadesNivel0 = unidadesNivel0;
                jugador1.unidadesNivel1 = unidadesNivel1;
                jugador1.unidadesNivel2 = unidadesNivel2;
                jugador1.unidadesNivel3 = unidadesNivel3;
                jugador1.unidades = 0;
                jugador2.unidadesNivel0 = unidadesNivel0;
                jugador2.unidadesNivel1 = unidadesNivel1;
                jugador2.unidadesNivel2 = unidadesNivel2;
                jugador2.unidadesNivel3 = unidadesNivel3;
                jugador2.unidades = 0;

                tablero = new Matriz();
                iniciado = true;
            }
            else
            {
                iniciado = false;
            }
        }

        public void cargarDatos()
        {
            if(unidadesNivel0 != 0)
            {
                datosCargados = true;
            }
            else
            {
                datosCargados = false;
                return;
            }

            if (unidadesNivel1 != 0)
            {
                datosCargados = true;
            }
            else
            {
                datosCargados = false;
                return;
            }

            if (unidadesNivel3 != 0)
            {
                datosCargados = true;
            }
            else
            {
                datosCargados = false;
                return;
            }

            if (tamañoX != 0)
            {
                datosCargados = true;
            }
            else
            {
                datosCargados = false;
                return;
            }

            if (tamañoY != 0)
            {
                datosCargados = true;
            }
            else
            {
                datosCargados = false;
                return;
            }

            if (tipoJuego != 0)
            {
                datosCargados = true;
            }
            else
            {
                datosCargados = false;
                return;
            }

        }

        public void insertarUnidad(string x, string y, string subtipo, string usuario, string nivel)
        {
            try
            {
                if (iniciado)
                {
                    if (jugador1.nombre.Equals(usuario))
                    {
                        if (nivel.Equals("0"))
                        {
                            if (jugador1.unidadesNivel0 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador1.unidades++;
                                    jugador1.unidadesNivel0--;
                                }
                            }
                        }
                        else if (nivel.Equals("1"))
                        {
                            if (jugador1.unidadesNivel1 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador1.unidades++;
                                    jugador1.unidadesNivel1--;
                                }
                            }
                        }
                        else if (nivel.Equals("2"))
                        {
                            if (jugador1.unidadesNivel2 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador1.unidades++;
                                    jugador1.unidadesNivel2--;
                                }
                            }
                        }
                        else if (nivel.Equals("3"))
                        {
                            if (jugador1.unidadesNivel3 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador1.unidades++;
                                    jugador1.unidadesNivel3--;

                                }
                            }
                        }
                    }
                    else if (jugador2.nombre.Equals(usuario))
                    {
                        if (nivel.Equals("0"))
                        {
                            if (jugador2.unidadesNivel0 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador2.unidades++;
                                    jugador2.unidadesNivel0--;

                                }
                            }
                        }
                        else if (nivel.Equals("1"))
                        {
                            if (jugador2.unidadesNivel1 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador2.unidades++;
                                    jugador2.unidadesNivel1--;

                                }
                            }
                        }
                        else if (nivel.Equals("2"))
                        {
                            if (jugador2.unidadesNivel2 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador2.unidades++;
                                    jugador2.unidadesNivel2--;
                                }
                            }
                        }
                        else if (nivel.Equals("3"))
                        {
                            if (jugador2.unidadesNivel3 > 0)
                            {
                                if(tablero.insertar(x, y, subtipo, usuario))
                                {
                                    jugador2.unidades++;
                                    jugador2.unidadesNivel3--;
                                }
                            }
                        }
                    }
                }
            }catch(Exception e)
            {

            }
        }

        public void jugadorPreparado(string usuario)
        {
            if(jugador1 != null)
            {
                if (jugador1.nombre.Equals(usuario))
                {
                    jugador1.preparado = true;
                }
                else if(jugador2 != null)
                {
                    if (jugador2.nombre.Equals(usuario))
                    {
                        jugador2.preparado = true;
                    }
                }
            }
            else if(jugador2 != null)
            {
                if (jugador2.nombre.Equals(usuario))
                {
                    jugador2.preparado = true;
                }
            }
        }

        public string estadoJuegoJugadores()
        {
            if (jugador1 != null && jugador2 != null)
            {
                
                if(jugador1.preparado == false)
                {
                    if(jugador2.preparado == false)
                    {
                        return "Esperando a ambos jugadores";
                    }
                    else
                    {
                        return "Esperando a " + jugador1.nombre;
                    }
                }
                else
                {
                    if(jugador2.preparado == false)
                    {
                        return "Esperando a " + jugador2.nombre;
                    }
                    else
                    {
                        return "Ambos jugadores están preparados";
                    }
                }
            }
            return "";
        }

        public void activarMovimientos()
        {
            if(jugador1 != null && jugador2 != null)
            {
                if(jugador1.preparado && jugador2.preparado)
                {
                    mover = true;
                    estadoInicial0 = tablero.escribirDOTNivel(0);
                    estadoInicial1 = tablero.escribirDOTNivel(1);
                    estadoInicial2 = tablero.escribirDOTNivel(2);
                    estadoInicial3 = tablero.escribirDOTNivel(3);
                }
                else
                {
                    mover = false;
                }
            }
            else
            {
                mover = false;
            }
        }

        public string estadoInicial(string nivel)
        {
            if(nivel.Equals("0"))
            {
                return estadoInicial0;
            }else if (nivel.Equals("1"))
            {
                return estadoInicial1;
            }else if (nivel.Equals("2"))
            {
                return estadoInicial2;
            }else if (nivel.Equals("3"))
            {
                return estadoInicial3;
            }
            return "";
        }

        public int getDesplegadas()
        {
            return unidadesNivel0 + unidadesNivel1 + unidadesNivel2 + unidadesNivel3;
        }

        public int getSobrevivientes()
        {
            return jugador1.unidades + jugador2.unidades;
        }

    }
}