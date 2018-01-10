using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _EDD_Proyecto1_Cliente
{
    public partial class MenuJuegos : System.Web.UI.Page
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

            Label1.Text = obtenerEstadoDeJuego();

            if (Session["Admin"] != null)
            {
                Label labelUsu = new Label();
                labelUsu.Text = "Usuario: " + Session["Usuario"].ToString();
                this.Controls.Add(labelUsu);
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAdmin.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.iniciarJuego();
            servidor.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();

            servidor.colocarUnidadesNivel0(txtNivel0.Text);
            servidor.colocarUnidadesNivel1(txtNivel1.Text);
            servidor.colocarUnidadesNivel2(txtNivel2.Text);
            servidor.colocarUnidadesNivel3(txtNivel3.Text);
            servidor.colocarTamañoX(txtX.Text);
            servidor.colocarTamañoY(txtY.Text);
            servidor.colocarTipoJuego(DropDownList1.SelectedValue);
            
            
            if (!txtTiempo.Text.Equals(""))
            {
                string[] tiempo = txtTiempo.Text.Trim().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                int minutos = Int32.Parse(tiempo[0]);
                minutos = minutos * 60;
                servidor.colocarTiempo(minutos.ToString());
            }
            servidor.cargarDatos();

            servidor.Close();

            Label1.Text = obtenerEstadoDeJuego();

        }

        public string obtenerEstadoDeJuego()
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            string texto = servidor.estadoDeJuego();
            servidor.Close();
            return texto;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesMatriz.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            crearCarpeta2();
            bool archivoOk = false;
            String path = Server.MapPath("~/CargaArchivos/");
            if (FileUpload1.HasFile)
            {
                String extension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] extensiones = { ".csv" };
                for (int i = 0; i < extensiones.Length; i++)
                {
                    if (extension == extensiones[i])
                    {
                        archivoOk = true;
                    }
                }
            }
            if (archivoOk)
            {
                try
                {
                    FileUpload1.SaveAs(path + FileUpload1.FileName);

                    if (FileUpload1.FileName.Equals("juegoActual.csv"))
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(Server.MapPath("~/CargaArchivos/juegoActual.csv"));
                        string texto = file.ReadToEnd();
                        separarLineas(texto);

                        file.Close();


                    }

                }
                catch
                {

                }
            }
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

        public void separarComas(string texto)
        {
            string[] result = texto.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int contador = 0;
            string jugador1 = "";
            string jugador2 = "";
            string naves0 = "";
            string naves1 = "";
            string naves2 = "";
            string naves3 = "";
            string tamañoX = "";
            string tamañoY = "";
            string tipoJuego = "";
            string minutos = "";

            foreach (string s in result)
            {
                if (contador == 0)
                {
                    jugador1 = s.Trim();
                }
                else if (contador == 1)
                {
                    jugador2 = s.Trim();
                }
                else if (contador == 2)
                {
                    naves0 = s;
                }
                else if (contador == 3)
                {
                    naves1 = s;
                }
                else if (contador == 4)
                {
                    naves2 = s;
                }
                else if (contador == 5)
                {
                    naves3 = s;

                }
                else if (contador == 6)
                {
                    tamañoX = s;
                }
                else if (contador == 7)
                {
                    tamañoY = s;
                }
                else if (contador == 8)
                {
                    tipoJuego = s;
                }else if (contador == 9)
                {
                    string[] tiempo = s.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    minutos = tiempo[0];
                    int tiempo1 = Int32.Parse(minutos);
                    tiempo1 = tiempo1 * 60;
                    minutos = tiempo1.ToString();
                }
            
                contador++;


            }

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.colocarUnidadesNivel0(naves0);
            txtNivel0.Text = naves0;
            servidor.colocarUnidadesNivel1(naves1);
            txtNivel1.Text = naves1;
            servidor.colocarUnidadesNivel2(naves2);
            txtNivel2.Text = naves2;
            servidor.colocarUnidadesNivel3(naves3);
            txtNivel3.Text = naves3;
            servidor.colocarTamañoX(tamañoX);
            txtX.Text = tamañoX;
            servidor.colocarTamañoY(tamañoY);
            txtY.Text = tamañoY;
            servidor.colocarTipoJuego(tipoJuego);
            servidor.colocarTiempo(minutos);
            servidor.cargarDatos();


            
            if (servidor.estaIniciado().Equals("false"))
            {
                servidor.insertarJugador(jugador1);
                servidor.insertarJugador(jugador2);
            }

            txtX.Text = jugador1 + " - " + jugador2;
            servidor.iniciarJuego();

            servidor.Close();

            Label1.Text = obtenerEstadoDeJuego();

        }

        public void separarLineas(string text)
        {
            string[] result = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in result)
            {
                separarComas(s);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.terminarJuego();
            servidor.Close();
        }
    }
}