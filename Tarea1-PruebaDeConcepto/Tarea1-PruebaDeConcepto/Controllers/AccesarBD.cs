using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Tarea1_PruebaDeConcepto.Modelos;

[Route("api/[controller]")]
[ApiController]
public class AccesarBD : ControllerBase
{
    //String de conexión a BD
    string connectionString = "Server=25.55.61.33;Database=Prueba;Trusted_Connection=True;TrustServerCertificate=True;";

    //Api que se encarga de llamar el stored procesure de la base de datos, y espera a ser llamado para ejecutarse
    [HttpGet("InsertarEmpleado")]
    //Insertar Empleados conectado a controlador
    public async Task<IActionResult> InsertarEmpleado([FromBody] String Nombre, double Salario)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                //Abre conexión
                await conn.OpenAsync();

                //Asocia la variable Insertar empleado a el stored procedure InsertarEmpleado
                using (SqlCommand InsertarEmpleado = new SqlCommand("InsertarEmpleado", conn))
                {
                    //Crea un tipo de comando stored procedure
                    InsertarEmpleado.CommandType = CommandType.StoredProcedure;

                    //Agrega los parámetros
                    InsertarEmpleado.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
                    InsertarEmpleado.Parameters.Add("@Salario", SqlDbType.Money).Value = Salario;

                    await InsertarEmpleado.ExecuteNonQueryAsync();
                    return Ok("Exito llamando a insertar");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión al insertar");
                return Ok("");
                //Si algo sale mal escribe un mensaje de error
            }
        }
    }



    [HttpGet("MostrarEmpleados")]
    //Insertar Empleados conectado a controlador
    public async Task<IActionResult> MostrarEmpleados()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                //Abre conexión
                await conn.OpenAsync();

                //Asocia la variable Insertar empleado a el stored procedure InsertarEmpleado
                using (SqlCommand MostrarEmpleados = new SqlCommand("MostrarEmpleados", conn))
                {
                    //Crea un tipo de comando stored procedure
                    MostrarEmpleados.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = await MostrarEmpleados.ExecuteReaderAsync())
                    {
                        var resultados = new List<Empleado>();
                        while (await reader.ReadAsync())
                        {
                            resultados.Add(new Empleado(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2)));
                        }
                        return Ok(resultados);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión al mostrar");
                return Ok("");
                //Si algo sale mal escribe un mensaje de error
            }
        }
    }
}