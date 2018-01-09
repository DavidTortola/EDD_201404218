using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _EDD_Proyecto1_Cliente
{
    public partial class ColocarUnidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Logueado"] != null)
            {
                if (Session["Logueado"].ToString() != "true")
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            Label1.Text = servidor.cantidadRestante(enviarInformacion(), Session["Usuario"].ToString());

            TextBox1.Text = "Tamaño en x: " + servidor.obtenerX() + " tamaño en y: " + servidor.obtenerY();

            if (servidor.jugadorEstaPreparado(Session["Usuario"].ToString()).Equals("true"))
            {
                Response.Redirect("Juego.aspx");
            }

            servidor.Close();

            if (Label1.Text.Equals("0"))
            {
                DropDownList2.Visible = false;
            }
            else
            {
                DropDownList2.Visible = true;
            }

            if (Session["Admin"] != null)
            {
                Label labelUsu = new Label();
                labelUsu.Text = "Usuario: " + Session["Usuario"].ToString();
                this.Controls.Add(labelUsu);
            }


        }


        public void mostrarInformacion()
        {
            DropDownList2.Items.Clear();
            if (DropDownList1.SelectedValue.Equals("satelites"))
            {
                DropDownList2.Items.Add("neosatelite");
            }
            else if (DropDownList1.SelectedValue.Equals("aviones"))
            {
                DropDownList2.Items.Add("bombardero");
                DropDownList2.Items.Add("caza");
                DropDownList2.Items.Add("helicoptero de combate");
            }
            else if (DropDownList1.SelectedValue.Equals("barcos"))
            {
                DropDownList2.Items.Add("fragata");
                DropDownList2.Items.Add("crucero");
            }
            else if (DropDownList1.SelectedValue.Equals("submarinos"))
            {
                DropDownList2.Items.Add("submarino");
            }
        }

        public string enviarInformacion()
        {
            if (DropDownList1.SelectedValue.Equals("satelites"))
            {
                return "3";
            }
            else if (DropDownList1.SelectedValue.Equals("aviones"))
            {
                return "2";
            }
            else if (DropDownList1.SelectedValue.Equals("barcos"))
            {
                return "1";
            }
            else if (DropDownList1.SelectedValue.Equals("submarinos"))
            {
                return "0";
            }
            else
            {
                return "";
            }
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Label1.Text.Equals("0"))
            {
                DropDownList2.Visible = false;
            }
            else
            {
                DropDownList2.Visible = true;
            }

            mostrarInformacion();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!txtX.Equals("") && !txtY.Equals("") && DropDownList2.Visible == true)
            {
                ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
                servidor.insertarUnidad(txtX.Text, txtY.Text, DropDownList2.SelectedItem.ToString(), Session["Usuario"].ToString(), enviarInformacion());
                servidor.Close();
            }


            ServidorIPEstatica.WebService1SoapClient servidor2 = new ServidorIPEstatica.WebService1SoapClient();
            Label1.Text = servidor2.cantidadRestante(enviarInformacion(), Session["Usuario"].ToString());
            servidor2.Close();

            if (Label1.Text.Equals("0"))
            {
                DropDownList2.Visible = false;
            }
            else
            {
                DropDownList2.Visible = true;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.jugadorPreparado(Session["Usuario"].ToString());
            servidor.Close();
            Response.Redirect("Juego.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            mostrarInformacion();
        }
    }

}