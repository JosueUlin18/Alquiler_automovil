using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Temp.Precio = Convert.ToInt32(txt_precio.Text);
            ingreso.Add(Temp);
            FileStream stream = new FileStream("IngresoVehiculo.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var p in ingreso)
            {
                writer.WriteLine(p.Placa);
                writer.WriteLine(p.Marca);
                writer.WriteLine(p.Modelo);
                writer.WriteLine(p.Color);
                writer.WriteLine(p.Precio);
            }
            writer.Close();

        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            agregar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ingreso;
            dataGridView1.Refresh();
        }
    }
}
