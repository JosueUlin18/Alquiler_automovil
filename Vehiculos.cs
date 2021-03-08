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
    public partial class Vehiculos : Form
    {
        List<C_vehiculo> ingreso = new List<C_vehiculo>();
        public Vehiculos()
        {
            InitializeComponent();
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form principal = new Form1();
            principal.Show();
            this.Close();
        }

        private void Vehiculos_Load(object sender, EventArgs e)
        {

        }
        private void agregar()
        {
            C_vehiculo Temp = new C_vehiculo();
            Temp.Placa = txt_placa.Text;
            Temp.Marca = txt_marca.Text;
            Temp.Modelo = txt_modelo.Text;
            Temp.Color = txt_color.Text;
            Temp.Precio = Convert.ToInt32(txt_precio);
            ingreso.Add(Temp);

        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {

        }
    }
}
