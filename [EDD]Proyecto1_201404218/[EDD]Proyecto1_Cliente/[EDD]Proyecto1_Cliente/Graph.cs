using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;

namespace _EDD_Proyecto1_Cliente
{
    public class Graph
    {

        public void graficar2(string inf, string nombre)
        {
            crearCarpeta();
            crearCarpeta2();
            string texto = "digraph G{ " + Environment.NewLine;

            texto += inf;
            texto += "}";

            System.IO.File.WriteAllText("C:\\Reportes\\graph.txt", texto);
            /*
            System.Diagnostics.ProcessStartInfo process = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + "dot -Tpng \"C:\\Reportes\\graph.txt\" -o \"C:\\Reportes\\" +nombre +".png\"");
            //System.Diagnostics.ProcessStartInfo process = new System.Diagnostics.ProcessStartInfo("cmd", "/c" + "notepad");

            process.RedirectStandardOutput = true;
            
            process.UseShellExecute = false;
            process.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = process;
            proc.Start();
            */
            ejecutarDot("", "");
        }

        private void ejecutarDot(String nombreA, String nombreI)
        {
            Process a = new Process();
            a.StartInfo.FileName = "\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\"";
            a.StartInfo.Arguments = "-Tjpg " + "C:\\inetpub\\wwwroot\\[EDD]Proyecto1_Cliente\\Reportes\\graph.txt" + " -o C:\\inetpub\\wwwroot\\[EDD]Proyecto1_Cliente\\Reportes\\" +nombreA +".png";
            a.StartInfo.UseShellExecute = false;
            a.Start();
            a.WaitForExit();
        }


        public void graficar(string inf, string nombre)
        {
            crearCarpeta();
            crearCarpeta2();

            string texto = "digraph G{ " + Environment.NewLine;
            texto += "node[shape = box, style = filled, color = black, fontcolor = white, fontname = \"Helvetica\"];" + Environment.NewLine;
            texto += inf;
            texto += "}";

            System.IO.File.WriteAllText(@"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\graph.txt", texto);
            /*
            Process proc = new Process();
           
            proc.StartInfo.FileName = @"C:\inetpub\wwwroot\[EDD]Proyecto1_Cliente\Reportes\graficar.cmd";
            proc.Start();
            */
            ejecutarDot(nombre, "");

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

    }
}