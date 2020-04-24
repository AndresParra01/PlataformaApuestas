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
    public partial class frmAutomatica : Form
    {
        int no;
        public frmAutomatica()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Estrategia conservadora");
            comboBox1.Items.Add("Estrategia arriesgada");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("Estrategia economizadora");
            comboBox2.Items.Add("Estrategia derrochadora");
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (int.TryParse(textBox1.Text, out int N0))
                {
                    if (frmMain.Saldo > 0)
                    {
                        double VA = 0, VG = 0, CA = 0;
                        Random Va = new Random();
                        Random Re = new Random();
                        
                        //Probabilidad de ganar
                        if (comboBox1.SelectedIndex == 0) //Estrategia conservadora
                        {
                            CA = 1d / ((float)Re.Next(60, 100) / 100d); //Calculamos directamente la cuota de apuesta
                        }
                        else //Estrategia arriesgada
                        {
                            CA = 1d / ((float)Re.Next(0, 60) / 100d);
                        }

                        //Valor apostado
                        if (comboBox2.SelectedIndex == 0) //Estrategia economizadora
                        {
                            VA = (double)(Va.Next(0, 30) * frmMain.Saldo) / 100d;
                        }
                        else //Estrategia derrochadora
                        {
                            VA = (double)(Va.Next(30, 100) * frmMain.Saldo) / 100d;
                        }

                        if (no == 0)
                        {
                            chart1.Series[0].Points.AddXY(no, frmMain.Saldo);
                        }
                        for (int i = 0; i < N0; i++) //N apuestas
                        {
                            if (frmMain.Saldo > VA)
                            {
                                if ((1d / CA) > ((double)Re.Next(0, 100) / 100d)) //Condicion de victoria (1 / CA = PG)
                                {
                                    VG = (double)(VA * CA);
                                }
                                frmMain.Saldo = frmMain.Saldo - VA + VG;
                                textBox2.Text = Math.Round(frmMain.Saldo) + "";
                                no++;
                                chart1.Series[0].Points.AddXY(no, frmMain.Saldo);
                                VG = 0;
                            }
                            else
                            {
                                MessageBox.Show("No puede seguir realizando apuestas ya que su VA supero su limite en la apuesta numero " + i);
                                //textBox2.Text = 0 + "";
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor a apostar debe ser mayor a cero");
                    }
                }
                else
                {
                    MessageBox.Show("No ha ingresado valores validos");
                }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
