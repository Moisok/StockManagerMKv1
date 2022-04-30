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
    public partial class Form3 : Form
    {
        clasesextra.bbdd datosBase = new clasesextra.bbdd();
        public Form3(String nombre_entidad)
        {
            InitializeComponent();
            try 
            {
              dataGridView1.DataSource = datosBase.tablaProveedores(nombre_entidad);
            }catch(Exception ex)
            {
                MessageBox.Show("No se ha podido cargar datos en la tabla de proveedores: " +ex.Message);
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dbappDataSet.entidades' Puede moverla o quitarla según sea necesario.
            //this.entidadesTableAdapter.Fill(this.dbappDataSet.entidades);
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
