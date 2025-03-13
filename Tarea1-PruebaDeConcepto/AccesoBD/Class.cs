using Microsoft.Data.SqlClient;

namespace Tarea1_PruebaDeConcepto.AccesoBD
{
    public class Class
    {
        static void Main(string[] args)
        {
            // String que guarda datos con los que se hace el login
            string connectionString = "Server=25.55.61.33;Database=Prueba;Trusted_Connection=True;TrustServerCertificate=True;";

            // Crear la conexión
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); //Abre la base de datos
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error de conexión: " + ex.Message);
                }
            }
        }
    }
}
