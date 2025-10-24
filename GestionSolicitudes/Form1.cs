using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionSolicitudes
{
    public partial class Form1 : Form
    {
        //Cola para manejar las solicitudes (FIFO)
        Queue<string> colaSolicitudes = new Queue<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string solicitud = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(solicitud))
            {
                colaSolicitudes.Enqueue(solicitud); // Agregar solicitud a la cola
                listBox1.Items.Add("Solicitud agregada: " + solicitud);
                textBox1.Clear();

            }
            else
            {

                MessageBox.Show("Por favor, ingrese una solicitud válida.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colaSolicitudes.Count > 0)
            {
                string solicitudAtendida = colaSolicitudes.Dequeue(); // Sacar la solicitud más antigua de la cola
                listBox1.Items.Add("Solicitud atendida: " + solicitudAtendida);
            }
            else
            {
                MessageBox.Show("No hay solicitudes para atender.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Solicitudes pendientes: ");

            if (colaSolicitudes.Count > 0)
            {
                foreach (string solicitud in colaSolicitudes)
                {
                    listBox1.Items.Add(" - " + solicitud);
                }
            }
            else
            {
                listBox1.Items.Add("No hay solicitudes pendientes.");
            }

            listBox1.Items.Add("-------------------------");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}   
