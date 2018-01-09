using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _EDD_Proyecto1_Cliente
{
    public partial class MenuJugador : System.Web.UI.Page
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
            Label1.Text = servidor.juegoDisponible();

            if (servidor.jugadorEstaPreparado(Session["Usuario"].ToString()).Equals("true"))
            {
                Response.Redirect("Juego.aspx");
            }


            servidor.Close();

            if (Session["Admin"] != null)
            {
                Label labelUsu = new Label();
                labelUsu.Text = "Usuario: " + Session["Usuario"].ToString();
                this.Controls.Add(labelUsu);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            if (servidor.estaIniciado().Equals("false"))
            {
                servidor.insertarJugador(Session["Usuario"].ToString());
                Response.Redirect("ColocarUnidades.aspx");
            }
            servidor.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            if (servidor.estaIniciado().Equals("false"))
            {

                Label1.Text = "Esperando que inicie un juego";
            }
            else
            {
                Response.Redirect("ColocarUnidades.aspx");
            }
            servidor.Close();
        }
    }
}