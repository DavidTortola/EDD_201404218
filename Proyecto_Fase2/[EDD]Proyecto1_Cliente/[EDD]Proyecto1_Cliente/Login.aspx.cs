using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _EDD_Proyecto1_Cliente
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text == "admin" && TextBox2.Text=="1234")
            {
                Session["Usuario"] = "admin";
                Session["Password"] = "1234";
                Session["Admin"] = "true";
                Response.Redirect("MenuAdmin.aspx");
            }
            else
            {
                ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
                string resultado = servidor.login(TextBox1.Text, TextBox2.Text);
                if (resultado.Equals("true"))
                {
                    Session["Usuario"] = TextBox1.Text;
                    Session["Password"] = TextBox2.Text;
                    Session["Admin"] = "false";
                    Session["Logueado"] = "true";
                    servidor.conectar(TextBox1.Text);
                    Response.Redirect("MenuJugador.aspx");
                }
                else if (resultado.Equals("false"))
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label1.Text = "   No se ha encontrado el usuario";
                }
                else
                {
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    Label1.Text = "   se ha encontrado un error";
                }
                servidor.Close();
            }
        }
    }
}