using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plataforma_de_Apuestas_PE
{
    public partial class frmMain : Form
    {
        static double saldo;
        public frmMain()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form apuestaManual = new frmManual();
            apuestaManual.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form apuestaAutomatica = new frmAutomatica();
            apuestaAutomatica.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Saldo = 0 + double.Parse(textBox2.Text); //Asignamos a salto el valor introducido en IS (No se valida si se ingreso un valor, ya que no es "obligatorio")

                if (saldo > 0)
                {
                    textBox1.Text = Saldo + "";
                }
                else
                {
                    MessageBox.Show("El saldo debe ser mayor a cero");
                    textBox1.Text = 0 + "";
                }
        }

        public static double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
    }
}
