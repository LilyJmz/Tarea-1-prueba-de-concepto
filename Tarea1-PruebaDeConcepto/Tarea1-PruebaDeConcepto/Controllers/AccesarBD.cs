using Microsoft.Data.SqlClient;
using System.Data;
using Tarea1_PruebaDeConcepto.Modelos;

public class AccesarBD
{
    public static int InsertarEmpleado(string nombre, double salario)
    {
        //String de conexión a BD
        string SringConexion = "Server=25.55.61.33;Database=Prueba;Trusted_Connection=True;TrustServerCertificate=True;";

        try
        {
            using (SqlConnection con = new SqlConnection(SringConexion))
            {
                //Abre conexión y se crea el comando insertar
                con.Open();
                using (SqlCommand insertar = new SqlCommand("InsertarEmpleado", con))
                {
                    //Envia parámetros de entrada
                    insertar.CommandType = CommandType.StoredProcedure;
                    insertar.Parameters.Add("@inNombre", SqlDbType.VarChar).Value = nombre;
                    insertar.Parameters.Add("@inSalario", SqlDbType.Money).Value = salario;

                    //Recibe el código de error
                    SqlParameter outCodigoError = new SqlParameter();
                    outCodigoError.ParameterName = "@outCodigoError";
                    outCodigoError.SqlDbType = SqlDbType.Int;
                    outCodigoError.Direction = ParameterDirection.Output;
                    insertar.Parameters.Add(outCodigoError);

                    //Se ejecuta el Stored procedure
                    insertar.ExecuteNonQuery();

                    //Devuelve el código de error
                    return (int)outCodigoError.Value;
                }
            }
        }
        catch (Exception ex)
        {
            //Error en capa lógica
            Console.WriteLine("Error al insertar empleado: " + ex.Message);
            return 50005;
        }
    }

    public static List<Empleado> MostrarEmpleados()
    {
        string SringConexion = "Server=25.55.61.33;Database=Prueba;Trusted_Connection=True;TrustServerCertificate=True;";

        //Crea una lista de empleados vacía
        List<Empleado> empleados = new List<Empleado>();

        try
        {
            using (SqlConnection con = new SqlConnection(SringConexion))
            {
                con.Open();
                using (SqlCommand mostrar = new SqlCommand("MostrarEmpleados", con))
                {
                    mostrar.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = mostrar.ExecuteReader())
                    {
                        //Mientras haya registros en la tabla, los va almacenando como empleados
                        while (reader.Read())
                        {
                            empleados.Add(new Empleado(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2)));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //Error en capa lógica
            Console.WriteLine("Error al mostrar empleados: " + ex.Message);
        }
        return empleados;
    }
}
