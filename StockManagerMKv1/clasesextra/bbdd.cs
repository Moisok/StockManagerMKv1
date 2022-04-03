using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace StockManagerMKv1.clasesextra
{
    public class bbdd
    {
        //Cadena de conexion
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        public void conectar()
        {
            connection.Open();
            Console.WriteLine(connection.State);
        }

        //Metodo para comprobar si la conexion esta o no abierta
        public void verificarConexion()
        {
            Console.WriteLine(connection.State);
            if (connection.State != ConnectionState.Open)
            {
                conectar();
            }
        }

        //Metodo para crear usuarios
        public void crearUsuario(String nombre, String password)
        {
            verificarConexion();
            try
            {
                string query = "INSERT INTO entidades (nombre,password) VALUES ('" + nombre + "','" + password + "')";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.Parameters.AddWithValue("@nombre", nombre);
                ejecutar.Parameters.AddWithValue("@password", password);
                ejecutar.ExecuteNonQuery();
                string query2 = "CREATE TABLE proveedores"+nombre+"" +
                "(Id INT IDENTITY(1,1) NOT NULL," +
                "Nombre_Proveedor VARCHAR(20) NOT NULL PRIMARY KEY," +
                "Telefono INT NOT NULL,  " +
                "Contacto VARCHAR(25) NULL, " +
                "PaginaWeb VARCHAR(20) NULL)";
                ejecutar = new SqlCommand(query2, connection);
                ejecutar.ExecuteNonQuery();
                string query3 = "CREATE TABLE productos" + nombre + " " +
                "(Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY," +
                "Nombre VARCHAR(20) NOT NULL," +
                "Cantidad INT NOT NULL,  " +
                "Ubicacion VARCHAR(25) NULL, " +
                "Nombre_Proveedor VARCHAR(20) NOT NULL," +
                "Foto IMAGE NULL," +
                "CONSTRAINT FK_nombre_proveedor FOREIGN KEY (Nombre_Proveedor) REFERENCES " +
                "proveedores"+nombre+ " (Nombre_Proveedor) ON UPDATE CASCADE ON DELETE CASCADE)";
                ejecutar = new SqlCommand(query3, connection);
                ejecutar.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message);
            }

        }

        //Metodo para iniciar sesion
        public void iniciarSesion(String nombre, String password)
        {
            String V_nombre;
            String V_password;
            verificarConexion();
            try
            {
                string query = "SELECT nombre, password FROM entidades WHERE nombre='" + nombre + "' AND password='" + password+"'";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.Parameters.AddWithValue("@nombre", nombre);
                ejecutar.Parameters.AddWithValue("@password", password);
                ejecutar.ExecuteNonQuery();

                //Ahora verificamos si existe o no el usuario
                SqlDataAdapter verif = new SqlDataAdapter(ejecutar);
                DataTable datos = new DataTable();
                verif.Fill(datos);
                if(datos.Rows.Count > 0)
                {
                    MessageBox.Show("Se ha iniciado sesion en: " + nombre);
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("No se ha podido iniciar sesion, el usuario o la contraseña no coincide ");
                    connection.Close();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido iniciar sesion, quizas el usuario o la contraseña esten mal " + ex.Message );
            }
        }

        //Metodo para crear las tablas
        public void crearProveedores(String nombre)
        {
            
        }

    }
}
