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
            Form1 principal = new Form1();
            principal.Show();
            this.Close();
        }

        private void Vehiculos_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void agregar()
        {
           
            C_vehiculo Temp = new C_vehiculo();
            bool existe = ingreso.Exists(v => v.Placa == txt_placa.Text);
            if (!(existe))
            {
                Temp.Placa = txt_placa.Text;
                Temp.Marca = txt_marca.Text;
                Temp.Modelo = txt_modelo.Text;
                Temp.Color = txt_color.Text;
                Temp.Precio = Convert.ToInt32(txt_precio.Text);
                ingreso.Add(Temp);
                FileStream stream = new FileStream(@"..\..\IngresoVehiculo.txt", FileMode.OpenOrCreate, FileAccess.Write);
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
            else
                MessageBox.Show("Esta placa ya existe");
            

        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            agregar();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ingreso;
            dataGridView1.Refresh();
        }
         private void cargar()
        {
            if (File.Exists(@"..\..\IngresoVehiculo.txt"))
            {
                FileStream stream = new FileStream(@"..\..\IngresoVehiculo.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    C_vehiculo Temp = new C_vehiculo();
                    Temp.Placa = reader.ReadLine();
                    Temp.Marca = reader.ReadLine();
                    Temp.Modelo = reader.ReadLine();
                    Temp.Color = reader.ReadLine();
                    Temp.Precio = Convert.ToInt32(reader.ReadLine());
                    ingreso.Add(Temp);
                }
                reader.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ingreso;
                dataGridView1.Refresh();
            }
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
