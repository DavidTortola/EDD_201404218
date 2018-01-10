using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _EDD_Proyecto1_Cliente
{
    public partial class Juego : System.Web.UI.Page
    {
        public static int tiempo = 0;
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
                if (servidor.obtenerTipoJuego() == 3)
                {
                    if (tiempo > 0)
                    {
                        lblTiempo.Text = tiempo.ToString();
                        tiempo--;
                        servidor.colocarTiempo(tiempo.ToString());
                    }
                    else
                    {
                        Timer1.Enabled = false;
                        string asf = servidor.tiempoTerminado();
                        if (!asf.Equals("")){

                            lblResultados.Text = asf;
                            lblTiempo.Text = "Tiempo terminado.";
                        }
                    }

                }
                servidor.Close();
            }
            catch (Exception b)
            {

            }
        }


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

            TextBox12.TextMode = TextBoxMode.MultiLine;
            TextBox12.Rows = 7;

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            Label1.Text = servidor.estadoJuegoJugadores();
            dibujarJuego();
            if(servidor.obtenerTipoJuego() == 3)
            {
                if(!lblTiempo.Text.Equals("Tiempo terminado."))
                {

                    lblTiempo.Text = "Tiempo:";
                    int n = servidor.obtenerTiempo();
                    tiempo = n;
                }
            }else if (servidor.obtenerTipoJuego() == 1)
            {
                Timer1.Enabled = false;
            }
            TextBox12.Text = servidor.obtenerConsola();
            /*
            string jlk = servidor.finDelJuego();
            if (!jlk.Equals(""))
            {

                lblResultados.Text = jlk;
            }
            */
            lblResultados.Text = servidor.resultado();

            if (servidor.estaIniciado().Equals("false"))
            {
                Response.Redirect("Login.aspx");
            }


            servidor.Close();

            if (Session["Admin"] != null)
            {
                Label labelUsu = new Label();
                labelUsu.Text = "Usuario: " + Session["Usuario"].ToString();
                this.Controls.Add(labelUsu);
            }

            
        }




        public void dibujarJuego()
        {
            crearCarpeta();
            crearCarpeta2();

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            if (servidor.estaIniciado().Equals("true"))
            {
                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel0.txt", servidor.obtenerArchivoPorNivel("0"));
                ejecutarDot("Nivel0");
                imgNivel0.ImageUrl = "~/Reportes/Nivel0.png";

                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel1.txt", servidor.obtenerArchivoPorNivel("1"));
                ejecutarDot("Nivel1");
                imgNivel1.ImageUrl = "~/Reportes/Nivel1.png";

                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel2.txt", servidor.obtenerArchivoPorNivel("2"));
                ejecutarDot("Nivel2");
                imgNivel2.ImageUrl = "~/Reportes/Nivel2.png";

                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel3.txt", servidor.obtenerArchivoPorNivel("3"));
                ejecutarDot("Nivel3");
                imgNivel3.ImageUrl = "~/Reportes/Nivel3.png";

            }
        }

        private void ejecutarDot(String nombreA)
        {
            crearCarpeta();
            crearCarpeta2();

            Process a = new Process();
            a.StartInfo.FileName = "\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\fdp.exe\"";
            a.StartInfo.Arguments = "-Tjpg " + "C:\\inetpub\\wwwroot\\[EDD]Proyecto1_Cliente\\Reportes\\" + nombreA + ".txt" + " -o C:\\inetpub\\wwwroot\\[EDD]Proyecto1_Cliente\\Reportes\\" + nombreA + ".png";
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
        }

        public void crearCarpeta()
        {
            // ruta del directorio a crear
            string path = @"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes";

            try
            {
                // revisa si existe
                if (Directory.Exists(path))
                {
                    return;
                }

                // intenta crear el directorio
                DirectoryInfo di = Directory.CreateDirectory(path);

                // borrar un directorio
                //di.Delete();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally { }
        }

        public void crearCarpeta2()
        {
            // ruta del directorio a crear
            string path = @"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\CargaArchivos";

            try
            {
                // revisa si existe
                if (Directory.Exists(path))
                {
                    return;
                }

                // intenta crear el directorio
                DirectoryInfo di = Directory.CreateDirectory(path);

                // borrar un directorio
                //di.Delete();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtMoverNivel.Text, out n);
            if (isNumeric)
            {
                ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
                txtResultado.Text = servidor.moverUnidad(txtMoverX.Text.Trim(), txtMoverY.Text.Trim().ToUpper(), txtMoverNivel.Text.Trim(), Session["Usuario"].ToString(), txtMoverX2.Text.Trim(), txtMoverY2.Text.Trim().ToUpper());
                TextBox12.Text = servidor.obtenerConsola();
                //txtResultado.Text = txtMoverX.Text + " " + txtMoverY.Text + " " + txtMoverNivel.Text + " " + Session["Usuario"].ToString() + " " + txtMoverX2.Text + " " + txtMoverY2.Text;
                servidor.Close();
            }
            dibujarJuego();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int n, n2;
            bool isNumeric = int.TryParse(txtAtacarNivel.Text, out n);
            bool isNumeric2 = int.TryParse(txtAtacarNivel2.Text, out n2);
            if (isNumeric && isNumeric2)
            {
                ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
                txtResultado0.Text = servidor.atacar(txtAtacarX.Text.Trim(), txtAtacarY.Text.Trim().ToUpper(), txtAtacarNivel.Text.Trim(), Session["Usuario"].ToString(), txtAtacarX2.Text.Trim(), txtAtacarY2.Text.Trim().ToUpper(),txtAtacarNivel2.Text.Trim());
                TextBox12.Text = servidor.obtenerConsola();
                //txtResultado.Text = txtMoverX.Text + " " + txtMoverY.Text + " " + txtMoverNivel.Text + " " + Session["Usuario"].ToString() + " " + txtMoverX2.Text + " " + txtMoverY2.Text;
                servidor.Close();
            }
            dibujarJuego();
        }

        
    }
}