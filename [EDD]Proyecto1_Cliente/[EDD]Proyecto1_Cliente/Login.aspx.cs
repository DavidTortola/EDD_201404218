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
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}