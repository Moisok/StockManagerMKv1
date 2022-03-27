using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace StockManager.Clases
{
    public class bbdd
    {
        //Cadena de conexion
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public void conectar()
        {
            connection.Open();
            Console.WriteLine(connection.State);
        }

        //Metodo para crear usuarios
        public void crearUsuario(String nombre, String password)
        {

            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
                connection.Open();
                string query = "INSERT INTO usuarios (Nombre,password) VALUES ('" + nombre + "','" + password + "')";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.Parameters.AddWithValue("@nombre", nombre);
                ejecutar.Parameters.AddWithValue("@password", password);
                ejecutar.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message);
            }

        }

    }
}
