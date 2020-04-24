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
    public partial class frmManual : Form
    {
        int no = 0;
        public frmManual()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double VA) && float.TryParse(textBox2.Text, out float PG) && float.TryParse(textBox3.Text, out float CA)) //Verificamos y tomamos los valores introducidos en estas casillas
            {
                    if (VA <= frmMain.Saldo)
                    {
                        if (PG > 0 && PG < 100)
                        {
                            double VG = 0;
                            Random Re = new Random();

                            if (no == 0)
                            {
                                chart1.Series[0].Points.AddXY(no, frmMain.Saldo);
                            }
                            if (PG >= Re.Next(0, 100))
                            {
                                VG = (double)(VA * CA);
                                MessageBox.Show("Usted gano... ");
                            }
                            else
                            {
                                MessageBox.Show("Usted perdio... ");
                            }

                            frmMain.Saldo = frmMain.Saldo - VA + VG;
                            textBox4.Text = Math.Round(frmMain.Saldo) + ""; //Evitar un problema con los decimales
                            no++;
                            chart1.Series[0].Points.AddXY(no, frmMain.Saldo);
                        }
                        else
                        {
                            MessageBox.Show("PG debe ser mayor a cero y menor a 100");
                        }
                    }

                    else
                    {
                        MessageBox.Show("VA debe ser menor que el saldo inicial");
                    }
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e) //Aqui tomamos el valor introducido en PG y calculamos la CA
        {
            if (float.TryParse(textBox2.Text, out float PG))
            {
                if (PG > 0 && PG < 100)
                {
                    textBox3.Text = 1d / (PG / 100) + "";
                }
                else
                {
                    textBox3.Text = 0 + "";
                }
            }
            else
            {
                textBox3.Text = 0 + "";
            }
        }
    }
}
