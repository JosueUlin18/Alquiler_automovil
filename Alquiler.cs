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
    public partial class Alquiler : Form
    {
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
    }
}
