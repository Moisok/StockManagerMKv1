using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using IronBarCode;

namespace StockManagerMKv1
{
    public partial class Form2 : Form
    {
        //Variables
        clasesextra.bbdd datosBase = new clasesextra.bbdd();
        Random r;
        int idProveedor = -1;
        int idProveedor2 = -1;
        int idPorducto = -1;
        int idPorducto2 = -1;
        Form3 tablasProveedores;
        Form4 tablasProductos;
        Form5 exportar;
        Form6 importar;
        String ruta;
        String ruta2;
        String theDate;
        String theDate2;
        public Form2()
        {
            
            InitializeComponent();
            ocultar();
            hideOcultar();
            datosBase.conectar();
            checkBox1.Checked = true;
            checkBox2.Checked = true;
           label36.ForeColor = System.Drawing.Color.White;
           label37.ForeColor = System.Drawing.Color.White;
           label38.ForeColor = System.Drawing.Color.White;
           label39.ForeColor = System.Drawing.Color.White;
           label46.ForeColor = System.Drawing.Color.White;

            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel9.Visible = true;


        }

        private void ocultar()
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;    
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
        }

        private void hideOcultar()
        {
            /*if (panel3.Visible)
            {
                panel3.Visible = false;
            }
            if (panel4.Visible)
            {
                panel4.Visible = false;
            }
            if (panel5.Visible)
            {
                panel5.Visible = false;
            }
            if (panel6.Visible)
            {
                panel6.Visible = false;
            }*/
            if (panel8.Visible)
            {
                panel8.Visible = false;
            }
            if (panel9.Visible)
            {
                panel9.Visible = false;
            }
            if (panel10.Visible)
            {
                panel10.Visible = false;
            }
            if (panel11.Visible)
            {
                panel11.Visible = false;
            }
            if (panel12.Visible)
            {
                panel12.Visible=false;
            }
            if (panel13.Visible)
            {
                panel13.Visible=false;
            }
            if (panel14.Visible)
            {
                panel14.Visible=false;
            }
            if (panel15.Visible)
            {
                panel15.Visible=false;
            }
        }


        private void showOcultar(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideOcultar();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            showOcultar(panel8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showOcultar(panel9);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //showOcultar(panel4);
        }

        private void Entidad_Click(object sender, EventArgs e)
        {
            //showOcultar(panel3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //showOcultar(panel5);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //showOcultar(panel6);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //showOcultar(panel7);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text && textBox1.Text.Length > 0)
            {
                datosBase.crearUsuario(textBox1.Text, textBox2.Text);
                Image Imagen = pictureBox2.Image;
                ruta = Directory.GetCurrentDirectory() + "/Fotos" + textBox1.Text;
                ruta2 = Directory.GetCurrentDirectory() + "/Codigosb" + textBox1.Text;
                Directory.CreateDirectory(ruta);
                Directory.CreateDirectory(ruta2);
                MessageBox.Show("Se ha creado la entidad " + textBox1.Text);
            }
            else
            {
                MessageBox.Show("No se ha podido crear el usuario");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '*';
                textBox3.PasswordChar = '*';

            }
            else
            {
                textBox2.PasswordChar = '\0';
                textBox3.PasswordChar = '\0';
            }

        }

        private void limpiarTexts (TextBox texto)
        {
            texto.Text = " ";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este programa ha sido creado por Moises Sepulveda Segarra\n" +
                "para un proyecto de FPGS actualmente se encuentra en su version 1.0.");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar = '*';
        }

        private void button17_Click(object sender, EventArgs e)
        {
            datosBase.iniciarSesion(textBox6.Text, textBox5.Text);
            //Modificar mas adelante y comprobar
            if (datosBase.CSesion)
            {
                label22.Text = "Sesion de: " + textBox6.Text;
                ruta = Directory.GetCurrentDirectory() + "/Fotos" + textBox6.Text+"/";
            }
            else
            {
                label22.Text = "Sesion no iniciada";
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox5.PasswordChar = '*';
            }
            else
            {
                textBox5.PasswordChar = '\0';
            }

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showOcultar(panel10);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            limpiarTexts(textBox4);
            limpiarTexts(textBox7);
            limpiarTexts(textBox8);
            limpiarTexts(textBox9);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            //Añadir excepcion
            int num_var = Int32.Parse(textBox7.Text);
            datosBase.insertarProveedores(textBox4.Text,num_var,textBox8.Text,textBox9.Text);
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            showOcultar(panel11);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            datosBase.consultarProveedorNombre(textBox10.Text);
            nombre.Text = datosBase.P_nombre;
            telefono.Text = datosBase.P_telefono;
            contacto.Text = datosBase.P_contacto;
            web.Text = datosBase.P_web;
           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void nombre_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            idProveedor--;
            datosBase.consultarProveedor(idProveedor);
            nombre.Text = datosBase.P_nombre;
            telefono.Text = datosBase.P_telefono;
            contacto.Text = datosBase.P_contacto;
            web.Text = datosBase.P_web;

           
        }

        private void button24_Click(object sender, EventArgs e)
        {
            idProveedor++;
            datosBase.consultarProveedor(idProveedor);
            nombre.Text = datosBase.P_nombre;
            telefono.Text = datosBase.P_telefono;
            contacto.Text = datosBase.P_contacto;
            web.Text = datosBase.P_web;

        }

        private void button27_Click(object sender, EventArgs e)
        {
                tablasProveedores = new Form3(textBox6.Text);
                tablasProveedores.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            datosBase.ordenarProveedores();
            idProveedor2++;
            Console.WriteLine(idProveedor2);
            datosBase.consultarProveedor(idProveedor2);
            textBox12.Text = datosBase.P_nombre;
            textBox13.Text = datosBase.P_telefono;
            textBox14.Text = datosBase.P_contacto;
            textBox15.Text = datosBase.P_web;
            label25.Text = datosBase.P_id;
            
        }

        private void button28_Click(object sender, EventArgs e)
        {
            datosBase.ordenarProveedores();
            idProveedor2--;
            datosBase.consultarProveedor(idProveedor2);
            textBox12.Text = datosBase.P_nombre;
            textBox13.Text = datosBase.P_telefono;
            textBox14.Text = datosBase.P_contacto;
            textBox15.Text = datosBase.P_web;
            label25.Text = datosBase.P_id;


        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            showOcultar(panel12);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            datosBase.ordenarProveedores();
            datosBase.consultarProveedorNombre(textBox11.Text);
            idProveedor2 = Int32.Parse(datosBase.P_id);
            textBox12.Text = datosBase.P_nombre;
            textBox13.Text = datosBase.P_telefono;
            textBox14.Text = datosBase.P_contacto;
            textBox15.Text = datosBase.P_web;
            label25.Text = datosBase.P_id;

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            datosBase.modificarProveedores(idProveedor2+1, textBox12.Text,Int32.Parse(textBox13.Text),textBox14.Text,textBox15.Text);
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Seguro que quieres borrar al proveedor?", "Confirmar borrar",MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                datosBase.eliminarProveedores(textBox12.Text);
            }
            else
            {
                // If 'No', do something here.
            }

            
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            showOcultar(panel13);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto_prod = new OpenFileDialog();
            DialogResult rs = foto_prod.ShowDialog();
            if(rs == DialogResult.OK)
            {
                string picLoc = foto_prod.FileName.ToString();
                pictureBox2.ImageLocation = picLoc;
            }
        }

        //Insertar Stock
        private void button32_Click(object sender, EventArgs e)
        {
                theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                datosBase.insertarStock(textBox16.Text, Int32.Parse(textBox19.Text), textBox17.Text, textBox18.Text, textBox26.Text, theDate);
                SaveFileDialog Guardar = new SaveFileDialog();
                Guardar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP";
                Image foto = pictureBox2.Image;
                foto.Save(ruta + textBox16.Text + ".JPEG");
                BarcodeWriter.CreateBarcode(textBox26.Text, BarcodeWriterEncoding.Code128).SaveAsJpeg(ruta2 + "/" + textBox26.Text + ".jpg");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = StockManagerMKv1.Properties.Resources.no_image;
            textBox16.Text = null;
            textBox19.Text = null;
            textBox17.Text = null;
            textBox18.Text = null;

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            datosBase.consultarProductoNombre(textBox20.Text);
            idPorducto = Int32.Parse(datosBase.Prod_id);
            label36.Text = datosBase.Prod_nombre;
            label37.Text = datosBase.Prod_cantidad;
            label38.Text = datosBase.Prod_ubicacion;
            label39.Text = datosBase.Prod_proveedor;
            label46.Text = datosBase.Prod_barcode;
            label50.Text = datosBase.Prod_date;
            label51.Text = datosBase.Prod_datemod;
            try
            {
                pictureBox3.Image = Image.FromFile(ruta + label36.Text + ".JPEG");
                pictureBox1.Image = Image.FromFile(ruta2 + "/" + label46.Text + ".jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la foto");
            }
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            showOcultar(panel14);
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            idPorducto--;
            datosBase.consultarProducto(idPorducto);
            label36.Text = datosBase.Prod_nombre;
            label37.Text = datosBase.Prod_cantidad;
            label38.Text = datosBase.Prod_ubicacion;
            label39.Text = datosBase.Prod_proveedor;
            label46.Text = datosBase.Prod_barcode;
            label50.Text = datosBase.Prod_date;
            label51.Text = datosBase.Prod_datemod;
            try
            {
                pictureBox3.Image = Image.FromFile(ruta + label36.Text + ".JPEG");
                pictureBox1.Image = Image.FromFile(ruta2 + "/" + label46.Text + ".jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la foto");
            };
        }

        private void button36_Click(object sender, EventArgs e)
        {
                idPorducto++;
                datosBase.consultarProducto(idPorducto);
                label36.Text = datosBase.Prod_nombre;
                label37.Text = datosBase.Prod_cantidad;
                label38.Text = datosBase.Prod_ubicacion;
                label39.Text = datosBase.Prod_proveedor;
                label46.Text = datosBase.Prod_barcode;
                label50.Text = datosBase.Prod_date;
                label51.Text = datosBase.Prod_datemod;
            try
            {
                pictureBox3.Image = Image.FromFile(ruta + label36.Text + ".JPEG");
                pictureBox1.Image = Image.FromFile(ruta2 + "/" + label46.Text + ".jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la foto");
            }
            
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button38_Click(object sender, EventArgs e)
        {
            tablasProductos = new Form4(textBox6.Text);
            tablasProductos.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            showOcultar(panel15);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {
            idPorducto2--;
            Console.WriteLine(idPorducto2);
            datosBase.consultarProducto(idPorducto2);
            textBox21.Text = datosBase.Prod_nombre;
            textBox22.Text = datosBase.Prod_cantidad;
            textBox23.Text = datosBase.Prod_ubicacion;
            textBox24.Text = datosBase.Prod_proveedor;
            pictureBox4.Image = Image.FromFile(ruta + textBox21.Text + ".JPEG");

        }

        private void button41_Click(object sender, EventArgs e)
        {
            idPorducto2++;
            Console.WriteLine(idPorducto2);
            datosBase.consultarProducto(idPorducto2);
            textBox21.Text = datosBase.Prod_nombre;
            textBox22.Text = datosBase.Prod_cantidad;
            textBox23.Text = datosBase.Prod_ubicacion;
            textBox24.Text = datosBase.Prod_proveedor;
            pictureBox4.Image = Image.FromFile(ruta + textBox21.Text + ".JPEG");
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button42_Click(object sender, EventArgs e)
        {
            datosBase.consultarProductoNombre(textBox25.Text);
            idPorducto2 = Int32.Parse(datosBase.Prod_id);
            textBox21.Text = datosBase.Prod_nombre;
            textBox22.Text = datosBase.Prod_cantidad;
            textBox23.Text = datosBase.Prod_ubicacion;
            textBox24.Text = datosBase.Prod_proveedor;
            pictureBox4.Image = Image.FromFile(ruta + textBox21.Text + ".JPEG");
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        //Modificar
        private void button43_Click(object sender, EventArgs e)
        {
            theDate2 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            datosBase.actualizarStock(textBox21.Text, Int32.Parse(textBox22.Text), textBox23.Text, textBox24.Text, idPorducto2+1, theDate2);
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP";
            Image foto = pictureBox4.Image;
            //File.Delete(ruta + textBox21.Text + ".JPEG");
            foto.Save(ruta + textBox21.Text + ".JPEG");

        }

        private void button39_Click(object sender, EventArgs e)
        {
            OpenFileDialog foto_prod = new OpenFileDialog();
            DialogResult rs = foto_prod.ShowDialog();
            if (rs == DialogResult.OK)
            {
                string picLoc = foto_prod.FileName.ToString();
                pictureBox4.ImageLocation = picLoc;
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Seguro que quieres borrar el producto?", "Confirmar borrar", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
                datosBase.eliminarProducto(textBox21.Text);
            }
            else
            {
                // If 'No', do something here.
            }
     
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button45_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            ShowInTaskbar = true;
        }
        //Aqui se cargaran las fotos de los codigos de barras
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        //Fecha producto
        private void label50_Click(object sender, EventArgs e)
        {

        }

        //Fecha modificacion
        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        //Codigo de barras a mano
        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }
        //Codigo de barras
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("se ha cerrado la sesion para poder realizar exportaciones");
            datosBase.cerrar();
            exportar = new Form5();
            exportar.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=yLWBZmdVMzc");
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            importar = new Form6();
            importar.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://stockmanagervk.odoo.com");
        }
    }
}
