using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _EDD_Tarea3_201404218
{
    public partial class Form1 : Form
    {
        public static Arbol arbol = new Arbol();

        public Form1()
        {
            InitializeComponent();
        }

        //Preorden
        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox2.Text = arbol.preorden(arbol.raiz);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arbol.insertar(maskedTextBox1.Text, arbol);
            maskedTextBox1.Text = "";
            arbol.graficar();
        }

        //Inorden
        private void button3_Click(object sender, EventArgs e)
        {
            maskedTextBox3.Text = arbol.inorden(arbol.raiz);
        }

        //Postorden
        private void button4_Click(object sender, EventArgs e)
        {
            maskedTextBox4.Text = arbol.postorden(arbol.raiz);
        }

        public void colocarImagen()
        {
            Image i = Image.FromFile("graf.png");
            label1.Size = i.Size;
            label1.Image = i;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            colocarImagen();
        }
    }
}
