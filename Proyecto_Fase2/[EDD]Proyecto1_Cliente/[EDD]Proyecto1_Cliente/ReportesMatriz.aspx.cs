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
    public partial class ReportesMatriz : System.Web.UI.Page
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
            else
            {
                Response.Redirect("Login.aspx");
            }


            if (Session["Admin"] != null)
            {
                Label labelUsu = new Label();
                labelUsu.Text = "Usuario: " + Session["Usuario"].ToString();
                this.Controls.Add(labelUsu);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
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
            a.StartInfo.Arguments = "-Tjpg " + "C:\\inetpub\\wwwroot\\[EDD]Proyecto1_Cliente\\Reportes\\" +nombreA +".txt" + " -o C:\\inetpub\\wwwroot\\[EDD]Proyecto1_Cliente\\Reportes\\" + nombreA + ".png";
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            crearCarpeta();
            crearCarpeta2();

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            if (servidor.estaIniciado().Equals("true"))
            {
                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel0.txt", servidor.obtenerArchivoInicial("0"));
                ejecutarDot("Nivel0");
                imgNivel0.ImageUrl = "~/Reportes/Nivel0.png";

                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel1.txt", servidor.obtenerArchivoInicial("1"));
                ejecutarDot("Nivel1");
                imgNivel1.ImageUrl = "~/Reportes/Nivel1.png";

                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel2.txt", servidor.obtenerArchivoInicial("2"));
                ejecutarDot("Nivel2");
                imgNivel2.ImageUrl = "~/Reportes/Nivel2.png";

                System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\Nivel3.txt", servidor.obtenerArchivoInicial("3"));
                ejecutarDot("Nivel3");
                imgNivel3.ImageUrl = "~/Reportes/Nivel3.png";

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuJuegos.aspx");
        }
    }
}