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
    public partial class Alquiler : Form
    {
        List<C_vehiculo> vehiculos = new List<C_vehiculo>();
        List<C_cliente> clientes = new List<C_cliente>();
   
        public Alquiler()
        {
            InitializeComponent();
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form principal = new Form1();
            principal.Show();
            this.Close();
        }
        private void guardar()
        {
            C_cliente temp = new C_cliente();
            temp.Nit = txt_nit.Text;
            temp.Placa = comboBox_placa.SelectedValue.ToString();
            temp.FechaAlquiler = dateTimePicker_alquilado.Value;
            temp.FechaDevolucion = dateTimePicker_devuelto.Value;
            temp.Kilometros = Convert.ToInt32(txt_kmRecorridos.Text);
            clientes.Add(temp);
            FileStream stream = new FileStream(@"..\..\clientes.txt", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            foreach (var alquiler in clientes)
            {
                writer.WriteLine(alquiler.Nit);
                writer.WriteLine(alquiler.Placa);
                writer.WriteLine(alquiler.FechaAlquiler);
                writer.WriteLine(alquiler.FechaDevolucion);
                writer.WriteLine(alquiler.Kilometros);

            }
            writer.Close();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();

        }
        private void Alquiler_Load(object sender, EventArgs e)
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

                    vehiculos.Add(Temp);
                }
                reader.Close();
            }
            if (File.Exists(@"..\..\clientes.txt"))
            {
                FileStream stream = new FileStream(@"..\..\clientes.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    C_cliente Temp = new C_cliente();
                    Temp.Nit = reader.ReadLine();
                    Temp.Placa = reader.ReadLine();
                    Temp.FechaAlquiler = Convert.ToDateTime(reader.ReadLine());
                    Temp.FechaDevolucion = Convert.ToDateTime(reader.ReadLine());
                    Temp.Kilometros = Convert.ToInt32(reader.ReadLine());

                    clientes.Add(Temp);
                }
                reader.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = clientes;
                dataGridView1.Refresh();
            }

            comboBox_placa.ValueMember = "Placa";
            comboBox_placa.DataSource = null;
            comboBox_placa.DataSource = vehiculos;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
