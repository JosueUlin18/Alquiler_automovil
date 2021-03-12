using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alquiler_automovil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            Vehiculos registrar = new Vehiculos();
            registrar.Show();
            this.Hide();
        }

        private void btn_alquilar_Click(object sender, EventArgs e)
        {
            Alquiler alquilar = new Alquiler();
            alquilar.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
