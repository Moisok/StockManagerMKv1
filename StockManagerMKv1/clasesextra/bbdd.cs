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
        //Otras variables
        public Boolean CSesion = false;

        //Cadena de conexion
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        String V_nombre;
        String V_password;

        //Variables para el proveedor
        public String P_id;
        public String P_nombre;
        public String P_telefono;
        public String P_contacto;
        public String P_web;

        //Variables de producto
        public String Prod_id;
        public String Prod_nombre;
        public String Prod_cantidad;
        public String Prod_ubicacion;
        public String Prod_proveedor;
        public String Prod_barcode;
        public String Prod_date;
        public String Prod_datemod;
        public System.IO.MemoryStream ms2;


        public void conectar()
        {
            connection.Open();
        }

        public void cerrar()
        {
            connection.Close();
        }

        //Metodo para comprobar si la conexion esta o no abierta
        public void verificarConexion()
        {
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
                string query2 = "CREATE TABLE proveedores" + nombre + "" +
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
                "Codigo_barras VARCHAR(13) NOT NULL," +
                "Fecha VARCHAR(40) NULL, " +
                "Fecha_mod VARCHAR(40) NULL, " +
                //"Ultima_Modificacion VARCHAR(25) NULL," +
                "CONSTRAINT FK_nombre_proveedor" + nombre + " FOREIGN KEY (Nombre_Proveedor) REFERENCES " +
                "proveedores" + nombre + " (Nombre_Proveedor) ON UPDATE CASCADE ON DELETE CASCADE)";
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
            //Guardamos el nombre en esta variable, ya que la usaremos para modificar y consultar las tablas
            V_nombre = nombre;

            verificarConexion();
            try
            {
                string query = "SELECT nombre, password FROM entidades WHERE nombre='" + nombre + "' AND password='" + password + "'";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.Parameters.AddWithValue("@nombre", nombre);
                ejecutar.Parameters.AddWithValue("@password", password);
                ejecutar.ExecuteNonQuery();
                //Ahora verificamos si existe o no el usuario
                SqlDataAdapter verif = new SqlDataAdapter(ejecutar);
                DataTable datos = new DataTable();
                verif.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    MessageBox.Show("Se ha iniciado sesion en: " + nombre);
                    connection.Close();
                    CSesion = true;
                }
                else
                {
                    MessageBox.Show("No se ha podido iniciar sesion, el usuario o la contraseña no coincide ");
                    connection.Close();
                    CSesion = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido iniciar sesion, quizas el usuario o la contraseña esten mal " + ex.Message);
            }
        }

        //Metodo para insertar en proveedores las tablas de proveedores
        public void insertarProveedores(String nombre, int telefono, String contacto, String web)
        {
            verificarConexion();
            try
            {
                //Creamos la query
                string query = "INSERT INTO proveedores" + V_nombre + " (Nombre_Proveedor,Telefono,Contacto,PaginaWeb)" +
                    "VALUES('" + nombre + "','" + telefono + "','" + contacto + "','" + web + "');";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
                MessageBox.Show("Se han insertado los datos del proveedor");
                connection.Close();
                ordenarProveedores();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido insertar los datos del proveedor" + ex.Message);
                connection.Close();
            }



        }

        //Metodo para consultar proveedores por id 
        public void consultarProveedor(int id)
        {
            verificarConexion();
            try
            {
                String query = "SELECT * FROM proveedores" + V_nombre + " ";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection); //REVISAR
                ejecutar.ExecuteNonQuery();
                DataTable datos = new DataTable();
                SqlDataAdapter verif = new SqlDataAdapter(ejecutar);
                verif.Fill(datos);
                P_id = datos.Rows[id][0].ToString();
                P_nombre = datos.Rows[id][1].ToString();
                P_telefono = datos.Rows[id][2].ToString();
                P_contacto = datos.Rows[id][3].ToString();
                P_web = datos.Rows[id][4].ToString();
                connection.Close();
                ordenarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido consultar los datos del proveedor " + ex.Message);
                connection.Close();
            }
        }

        //Metodo para consultar proveedores por nombre
        public void consultarProveedorNombre(String nombre)
        {
            verificarConexion();
            try
            {
                String query = "SELECT * FROM proveedores" + V_nombre + " " +
                     "WHERE Nombre_Proveedor = '" + nombre + "';";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection); //REVISAR
                ejecutar.ExecuteNonQuery();
                DataTable datos = new DataTable();
                SqlDataAdapter verif = new SqlDataAdapter(ejecutar);
                verif.Fill(datos);
                P_id = datos.Rows[0][0].ToString();
                P_nombre = datos.Rows[0][1].ToString();
                P_telefono = datos.Rows[0][2].ToString();
                P_contacto = datos.Rows[0][3].ToString();
                P_web = datos.Rows[0][4].ToString();
                connection.Close();
                ordenarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido consultar los datos del proveedor " + ex.Message);
                connection.Close();
            }
        }

        //Metodo para la consulta de proveedores por tablas
        public DataTable tablaProveedores(String nombreEntidad)
        {
            verificarConexion();
            String query = "SELECT * FROM proveedores" + nombreEntidad + " " +
                "ORDER BY Id ASC";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            connection.Close();
        }

        //Metodo para actualizar (o modificar) la tabla de proveedores
        public void modificarProveedores(int id, String nombre, int telefono, String contacto, String web)
        {
            verificarConexion();
            try
            {
                String query = "UPDATE proveedores" + V_nombre + " " +
                "               SET Nombre_Proveedor = '" + nombre + "', Telefono=" + telefono + ", Contacto='" + contacto + "', PaginaWeb='" + web + "' " +
                "               WHERE Id=" + id + ";";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
                MessageBox.Show("Se han actualizado los datos del proveedor");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido actualizar los datos: " + ex.Message);
                connection.Close();
            }
            ordenarProveedores();

        }

        //Metodo para eliminar registros de la tabla proveedores
        public void eliminarProveedores(String nombre)
        {
            verificarConexion();
            try
            {
                String query = "DELETE FROM proveedores" + V_nombre + " " +
                    "WHERE Nombre_Proveedor ='" + nombre + "';";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
                MessageBox.Show("Se ha eliminado el registro");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido eliminar el registro: " + ex.Message);
                connection.Close();
            }
        }

        //OPERACIONES Y CONSULTAS DE STOCK
        //Metodo para insertar en Stock las tablas de proveedores
        public void insertarStock(String nombre, int cantidad, String ubicacion, String proveedor, String code, String fecha)
        {
            verificarConexion();
            try
            {
                //Creamos la query
                string query = "INSERT INTO productos" + V_nombre + " (Nombre,Cantidad,Ubicacion,Nombre_Proveedor,Codigo_barras,Fecha)" +
                    "VALUES('" + nombre + "'," + cantidad + ",'" + ubicacion + "','" + proveedor + "','"+code+"','"+fecha+"');"; //Probar con comillas y sin comillas
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
                MessageBox.Show("Se han insertado los datos del producto");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido insertar los datos del producto: " + ex.Message);
                connection.Close();
            }



        }

        //Metodo para cosultar los productos por ID
        public void consultarProducto(int id)
        {
            verificarConexion();
            try
            {
                String query = "SELECT * FROM productos" + V_nombre + " " +
                    "ORDER BY Id ASC";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection); 
                ejecutar.ExecuteNonQuery();
                DataTable datos = new DataTable();
                SqlDataAdapter verif = new SqlDataAdapter(ejecutar);
                verif.Fill(datos);
                Prod_id = datos.Rows[id][0].ToString();
                Prod_nombre = datos.Rows[id][1].ToString();
                Prod_cantidad = datos.Rows[id][2].ToString();
                Prod_ubicacion = datos.Rows[id][3].ToString();
                Prod_proveedor = datos.Rows[id][4].ToString();
                Prod_barcode = datos.Rows[id][5].ToString();
                Prod_date = datos.Rows[id][6].ToString();
                Prod_datemod = datos.Rows[id][7].ToString();    
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido consultar los datos del producto " + ex.Message);
                connection.Close();
            }
        }

        //Metodo para cosultar los productos por nombre
        public void consultarProductoNombre(String nombre)
        {
            verificarConexion();
            try
            {
                String query = "SELECT * FROM productos" + V_nombre + " " +
                    "ORDER BY Id ASC " +
                     "WHERE Nombre = '" + nombre + "';";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection); 
                ejecutar.ExecuteNonQuery();
                DataTable datos = new DataTable();
                SqlDataAdapter verif = new SqlDataAdapter(ejecutar);
                verif.Fill(datos);
                Prod_id = datos.Rows[0][0].ToString();
                Prod_nombre = datos.Rows[0][1].ToString();
                Prod_cantidad = datos.Rows[0][2].ToString();
                Prod_ubicacion = datos.Rows[0][3].ToString();
                Prod_proveedor = datos.Rows[0][4].ToString();
                Prod_barcode = datos.Rows[0][5].ToString();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido consultar los datos del proveedor " + ex.Message);
                connection.Close();
            }
        }

        //Metodo para la consulta de productos por tablas
        public DataTable tablaProductos(String nombreEntidadprod)
        {
            verificarConexion();
            String query = "SELECT * FROM productos" + nombreEntidadprod + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            connection.Close();
        }

        //Metodo para actualizar la tabla de Stock
        public void actualizarStock(String nombre, int cantidad, String ubicacion, String proveedor, int id, String fecha)
        {
            verificarConexion();
            try
            {
                String query = "UPDATE productos" + V_nombre + " " +
                "               SET Nombre = '" + nombre + "', Cantidad=" + cantidad + ", Ubicacion='" + ubicacion + "', Nombre_Proveedor='" + proveedor + "'" + ",Fecha_mod='"+fecha+"'"+
                "               WHERE Id=" + id + ";";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
                MessageBox.Show("Se han actualizado los datos del producto");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido actualizar los datos: " + ex.Message);
                connection.Close();
            }
            
        }

        //Metodo para eliminar registros de la tabla productos
        public void eliminarProducto(String nombre)
        {
            verificarConexion();
            try
            {
                String query = "DELETE FROM productos" + V_nombre + " " +
                    "WHERE Nombre ='" + nombre + "';";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
                MessageBox.Show("Se ha eliminado el producto");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido eliminar el producto: " + ex.Message);
                connection.Close();
            }
        }

        //Metodo para reordenar los proveedores
        public void ordenarProveedores()
        {
            verificarConexion();
            try
            {
                String query = "SELECT * " +
                    "FROM proveedores" + V_nombre + " " +
                    "ORDER BY Id ASC;"; 
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
            }catch (Exception ex)
            {
                MessageBox.Show("No se ha podido reordenar el proveedor" + ex.Message);
            }
        }

        //Metodo para reordenar los productos
        public void ordenarProductos()
        {
            verificarConexion();
            try
            {
                String query = "SELECT * FROM proveedores" + V_nombre + " " +
                    "ORDER BY Id ASC;";
                SqlCommand ejecutar = new SqlCommand(query, connection);
                ejecutar = new SqlCommand(query, connection);
                ejecutar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido reordenar el producto" + ex.Message);
            }
        }

    }


}
