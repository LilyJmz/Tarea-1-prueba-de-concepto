using Microsoft.AspNetCore.Mvc;
using Tarea1_PruebaDeConcepto.Modelos;

//Esta api controller se encarga de conectar la capa usuario con la capa de acceso a BD
//Es decir, ahora las stored procedures se pueden llamar desde la vista usuario, pero no se puede ver su contenido
//El api es de  ASP.NET Core , y expone por medio de https solicitudes a la capa de ususario

namespace Tarea1_PruebaDeConcepto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BDController : ControllerBase
    {
        //Un controller de tipo POST para enviar la informacion
        [HttpPost("Insertar")]
        public ActionResult<int> InsertarEmpleado([FromBody] Empleado empleado)
        {
            int result = AccesarBD.InsertarEmpleado(empleado.Nombre, empleado.Salario);
            if (result != 0)
            {
                return Ok(result); 
            }
            return BadRequest("Error al insertar empleado");
        }

        


        //Un controller de tipo GET para recibir la información de la lista de empleados
        [HttpGet("Mostrar")]
        public ActionResult<List<Empleado>> MostrarEmpleados()
        {
            var empleados = AccesarBD.MostrarEmpleados();
            return Ok(empleados);
        }
    }
}
