using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _EDD_Proyecto1_Cliente
{
    public partial class WebForm1 : System.Web.UI.Page
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

            TextBox2.TextMode = TextBoxMode.MultiLine;
            TextBox2.Rows = 5;
            txtGanados.TextMode = TextBoxMode.MultiLine;
            txtGanados.Rows = 10;
            txtDestruidas.TextMode = TextBoxMode.MultiLine;
            txtDestruidas.Rows = 10;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            Graph graph = new Graph();
            //graph.graficar2(servidor.insertarUsuario(TextBox1.Text, TextBox2.Text, TextBox3.Text, true),"Usuarios");
        }

        protected void Button4_Click(object sender, EventArgs e)
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

                    if (FileUpload1.FileName.Equals("usuarios.csv"))
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader(Server.MapPath("~/CargaArchivos/usuarios.csv"));
                        string texto = file.ReadToEnd();
                        separarLineas(texto);

                        file.Close();

                        ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
                        Graph graph = new Graph();
                        graph.graficar(servidor.graficarUsuarios(), "Usuarios");


                    }else if (FileUpload1.FileName.Equals("juegos.csv"))
                    {

                        System.IO.StreamReader file = new System.IO.StreamReader(Server.MapPath("~/CargaArchivos/juegos.csv"));
                        string texto = file.ReadToEnd();
                        insertarJuegos(texto);

                        file.Close();

                        ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
                        Graph graph = new Graph();
                        graph.graficar(servidor.graficarUsuarios(), "Usuarios");

                    }

                }
                catch
                {

                }
            }
            Image1.ImageUrl = "~/Reportes/Usuarios.png";
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
            string nickname = "";
            string contraseña = "";
            string correoElectronico = "";
            bool conectado = false;
            
            foreach (string s in result)
            {
                //Response.Write("<script LANGUAGE='JavaScript' >alert('" + s + "')</script>");
                if (contador == 0)
                {
                    nickname = s;
                }else if(contador == 1)
                {
                    contraseña = s;
                }else if(contador == 2)
                {
                    correoElectronico = s;
                }else if(contador == 3)
                {
                    if (s.Equals("1"))
                    {
                        conectado = true;
                    }
                    else
                    {
                        conectado = false;
                    }
                }
                contador++;
                
                
            }
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.insertarUsuario(nickname, contraseña, correoElectronico, conectado);

        }

        public void separarLineas(string text)
        {
            string[] result = text.Split(new[] { Environment.NewLine },StringSplitOptions.RemoveEmptyEntries);

            foreach(string s in result)
            {
                //Response.Write("<script LANGUAGE='JavaScript' >alert('" +s +"')</script>");
                separarComas(s);
            }
        }

        public void insertarJuegos(string text)
        {
            string[] result = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in result)
            {
                //Response.Write("<script LANGUAGE='JavaScript' >alert('" +s +"')</script>");
                insertarJuegos2(s);
            }
        }

        public void insertarJuegos2(string texto)
        {
            string[] result = texto.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int contador = 0;
            string nickname = "";
            string oponente = "";
            int unidadesDesplegadas = 0;
            int unidadesSobrevivientes = 0;
            int unidadesDestruidas = 0;
            bool gano = false;
            foreach (string s in result)
            {
                //Response.Write("<script LANGUAGE='JavaScript' >alert('" + s + "')</script>");
                if (contador == 0)
                {
                    nickname = s;
                }
                else if (contador == 1)
                {
                    oponente = s;
                }
                else if (contador == 2)
                {
                    unidadesDesplegadas = Convert.ToInt32(s);
                }
                else if(contador == 3)
                {
                    unidadesSobrevivientes = Convert.ToInt32(s);
                }
                else if(contador == 4){
                    unidadesDestruidas = Convert.ToInt32(s);
                }
                else if (contador == 5)
                {
                    if (s.Equals("1"))
                    {
                        gano = true;
                    }
                    else
                    {
                        gano = false;
                    }
                }
                contador++;
                
            }

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.insertarJuego(nickname, oponente, unidadesDesplegadas, unidadesSobrevivientes, unidadesDestruidas, gano);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            /*
            System.IO.StreamReader file =new System.IO.StreamReader(Server.MapPath("~/CargaArchivos/usuarios.csv"));
            string texto = file.ReadToEnd();
            separarLineas(texto);

            file.Close();

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            Graph graph = new Graph();
            graph.graficar2(servidor.graficarUsuarios(),"Usuarios");
            */
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.limpiar();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.eliminarUsuario(TextBox1.Text);
            Graph graph = new Graph();
            graph.graficar(servidor.graficarUsuarios(), "Usuarios");
            Image1.ImageUrl = "~/Reportes/Usuarios.png";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            bool conectado = false;
            if (txtConectado.Text.Equals("1"))
            {
                conectado = true;
            }else if (txtConectado.Text.Equals("0"))
            {
                conectado = false;
            }
            else
            {
                conectado = false;
            }
            servidor.insertarUsuario(txtNickname.Text, txtPassword.Text, txtCorreo.Text, conectado);
            txtNickname.Text = "";
            txtPassword.Text = "";
            txtCorreo.Text = "";
            txtConectado.Text = "";
            servidor.Close();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            Graph graph = new Graph();
            graph.graficar(servidor.graficarUsuarios(), "Usuarios");
            servidor.Close();
            Image1.ImageUrl = "~/Reportes/Usuarios.png";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            txtNickname0.Text = servidor.obtenerNickname(txtModificar.Text);
            txtPassword0.Text = servidor.obtenerPassword(txtModificar.Text);
            txtCorreo0.Text = servidor.obtenerCorreoElectronico(txtModificar.Text);
            txtConectado0.Text = servidor.obtenerConectado(txtModificar.Text);
            TextBox2.Text = servidor.obtenerJuegos(txtModificar.Text);
            servidor.Close();
            
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.eliminarUsuario(txtModificar.Text);
            bool conectado = false;
            if (txtConectado0.Text.Equals("1"))
            {
                conectado = true;
            }
            else
            {
                conectado = false;
            }
            servidor.insertarUsuario(txtNickname0.Text, txtPassword0.Text, txtCorreo0.Text, conectado);
            modificarJuegos(txtNickname0.Text, TextBox2.Text);

            Graph graph = new Graph();
            graph.graficar(servidor.graficarUsuarios(), "Usuarios");
            servidor.Close();
            Image1.ImageUrl = "~/Reportes/Usuarios.png";
            servidor.Close();
        }

        public void modificarJuegos(string nickname, string texto)
        {
            string[] result = texto.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in result)
            {
                //Response.Write("<script LANGUAGE='JavaScript' >alert('" +s +"')</script>");
                modificarJuegos2(nickname,s);
            }
        }

        public void modificarJuegos2(string nickname, string texto)
        {
            string[] result = texto.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int contador = 0;
            string oponente = "";
            int unidadesDesplegadas = 0;
            int unidadesSobrevivientes = 0;
            int unidadesDestruidas = 0;
            bool gano = false;
            foreach (string s in result)
            {
                //Response.Write("<script LANGUAGE='JavaScript' >alert('" + s + "')</script>");
                 if (contador == 0)
                {
                    oponente = s;
                }
                else if (contador == 1)
                {
                    unidadesDesplegadas = Convert.ToInt32(s);
                }
                else if (contador == 2)
                {
                    unidadesSobrevivientes = Convert.ToInt32(s);
                }
                else if (contador == 3)
                {
                    unidadesDestruidas = Convert.ToInt32(s);
                }
                else if (contador == 4)
                {
                    if (s.Equals("1"))
                    {
                        gano = true;
                    }
                    else
                    {
                        gano = false;
                    }
                }
                contador++;

            }

            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            servidor.insertarJuego(nickname, oponente, unidadesDesplegadas, unidadesSobrevivientes, unidadesDestruidas, gano);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            Graph graph = new Graph();
            graph.graficar(servidor.graficarEspejo(), "Usuarios");
            servidor.Close();
            Image1.ImageUrl = "~/Reportes/Usuarios.png";
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            txtAltura.Text = servidor.obtenerAltura();
            txtNiveles.Text = servidor.obtenerNiveles();
            txtHojas.Text = servidor.obtenerHojas();
            txtRamas.Text = servidor.obtenerRamas();
            servidor.Close();
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            ServidorIPEstatica.WebService1SoapClient servidor = new ServidorIPEstatica.WebService1SoapClient();
            txtGanados.Text = servidor.consultarJuegosGanados();
            txtDestruidas.Text = servidor.consultarPorcentajeUnidadesDestruidas();
            servidor.Close();
        }

    }
}