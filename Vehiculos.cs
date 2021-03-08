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
    }
}
