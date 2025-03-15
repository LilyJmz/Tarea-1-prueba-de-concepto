using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Tarea1_PruebaDeConcepto.AccesoBD
{
    public class AccesarBD
    {
        static void Main(string[] args)
        {
            //String de conexión a BD
            string connectionString = "Server=25.55.61.33;Database=Prueba;Trusted_Connection=True;TrustServerCertificate=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    //Abre conexión
                    conn.Open();

                    //Valores vacíos de parámetros
                    String Nombre = null;
                    double Salario;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error de conexión: " + ex.Message);
                    //Si algo sale mal escribe un mensaje de error
                }
            }
        }


        private void InsertarDatos(object sender, EventArgs e, SqlConnection conn, String Nombre, double Salario)
        {
            //Asocia la variable Insertar empleado a el stored procedure InsertarEmpleado
            using (SqlCommand InsertarEmpleado = new SqlCommand("InsertarEmpleado", conn))
            {
                //Crea un tipo de comando stored procedure
                InsertarEmpleado.CommandType = CommandType.StoredProcedure;

                //Agrega los parámetros
                InsertarEmpleado.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                InsertarEmpleado.Parameters.Add("@Salario", SqlDbType.Money).Value = Salario;

                conn.Open();
                InsertarEmpleado.ExecuteNonQuery();
            }
        }

        private void AccesarEmpleados(SqlConnection conn)
        {
            //Asocia la variable Insertar empleado a el stored procedure InsertarEmpleado
            using (SqlCommand MostrarEmpleados = new SqlCommand("MostrarEmpleados", conn))
            {
                //Crea un tipo de comando stored procedure
                MostrarEmpleados.CommandType = CommandType.StoredProcedure;

                conn.Open();
                MostrarEmpleados.ExecuteNonQuery();


            }
        }
    }
}


