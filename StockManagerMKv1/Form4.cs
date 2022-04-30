using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagerMKv1
{
    public partial class Form4 : Form
    {
        clasesextra.bbdd datosBase = new clasesextra.bbdd();
        public Form4(String nombre_entidad)
        {
            InitializeComponent();
            try
            {
                dataGridView1.DataSource = datosBase.tablaProductos(nombre_entidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido cargar datos en la tabla de proveedores: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //this.entidadesTableAdapter.Fill(this.dbappDataSet.entidades);
        }
    }
}
