using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _EDD_Proyecto1_201404218
{
    public class Unidad
    {

        public string tipo { get; set; }
        public string subtipo { get; set; }
        public int movimiento { get; set; }
        public int alcance { get; set; }
        public int daño { get; set; }
        public int vida { get; set; }
        public string usuario { get; set; }

        //Constructor
        public Unidad(string subtipo, string usuario)
        {
            this.usuario = usuario;
            switch (subtipo)
            {
                case "neosatelite":
                    tipo = "satelite";
                    this.subtipo = subtipo;
                    movimiento = 6;
                    alcance = 0;
                    daño = 2;
                    vida = 10;
                    break;
                case "bombardero":
                    tipo = "avion";
                    this.subtipo = subtipo;
                    movimiento = 7;
                    alcance = 0;
                    daño = 5;
                    vida = 10;
                    break;
                case "caza":
                    tipo = "avion";
                    this.subtipo = subtipo;
                    movimiento = 9;
                    alcance = 1;
                    daño = 2;
                    vida = 20;
                    break;
                case "helicoptero de combate":
                    tipo = "avion";
                    this.subtipo = subtipo;
                    movimiento = 9;
                    alcance = 1;
                    daño = 3;
                    vida = 15;
                    break;
                case "fragata":
                    tipo = "barco";
                    this.subtipo = subtipo;
                    movimiento = 5;
                    alcance = 6;
                    daño = 3;
                    vida = 10;
                    break;
                case "crucero":
                    tipo = "barco";
                    this.subtipo = subtipo;
                    movimiento = 6;
                    alcance = 1;
                    daño = 3;
                    vida = 15;
                    break;
                case "submarino":
                    tipo = "submarino";
                    this.subtipo = subtipo;
                    movimiento = 5;
                    alcance = 1;
                    daño = 2;
                    vida = 10;
                    break;
                default:
                    tipo = "";
                    this.subtipo = "";
                    movimiento = 0;
                    alcance = 0;
                    daño = 0;
                    vida = 0;
                    break;
            }
        }

    }
}