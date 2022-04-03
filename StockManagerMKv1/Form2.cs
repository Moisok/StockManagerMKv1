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
    public partial class Form2 : Form
    {
        clasesextra.bbdd datosBase = new clasesextra.bbdd();
        public Form2()
        {
            
            InitializeComponent();
            ocultar();
            hideOcultar();
            datosBase.conectar();
            checkBox1.Checked = true;
            checkBox2.Checked = true;
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
            showOcultar(panel4);
        }

        private void Entidad_Click(object sender, EventArgs e)
        {
            showOcultar(panel3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            showOcultar(panel5);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            showOcultar(panel6);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            showOcultar(panel7);
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
                MessageBox.Show("Se ha creado la entidad " + textBox1.Text);
                panel7.Visible = false;
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
    }
}
