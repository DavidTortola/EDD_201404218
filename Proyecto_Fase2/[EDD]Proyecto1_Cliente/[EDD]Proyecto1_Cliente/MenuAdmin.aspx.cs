using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _EDD_Proyecto1_Cliente
{
    public partial class MenuAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] != null)
            {
                if (Session["Admin"].ToString() != "true")
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (Session["Admin"] != null)
            {
                Label labelUsu = new Label();
                labelUsu.Text = "Usuario: " + Session["Usuario"].ToString();
                this.Controls.Add(labelUsu);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuJuegos.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.masterReset();
            servidor.Close();
            Session.Clear();
        }
    }
}