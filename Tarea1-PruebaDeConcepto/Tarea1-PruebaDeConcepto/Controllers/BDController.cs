﻿using Microsoft.AspNetCore.Mvc;
using Tarea1_PruebaDeConcepto.Modelos;

//Esta api controller se encarga de conectar la capa usuario con la capa de acceso a BD
//Es decir, ahora las stored procedures se pueden llamar desde la vista usuario, pero no se puede ver su contenido
//El api es de  ASP.NET Core , y expone por medio de https solicitudes a la capa de ususario

namespace Tarea1_PruebaDeConcepto.Controllers
{
    [Route("api/BDController")]
    [ApiController]
    public class BDController : ControllerBase
    {
        //Un controller de tipo POST para enviar la informacion
        [HttpPost("InsertarControlador")]
        public ActionResult<int> InsertarEmpleado([FromBody] Empleado empleado)
        {
            try
            {
                int result = AccesarBD.InsertarEmpleado(empleado.Nombre, empleado.Salario);
                if (result == 0) //El stored procedure devuelve 0 todo está bien
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = "Error al insertar empleado", codigoError = result });
                    //El stored procedure encuentra un error
                }
            }
            catch
            {
                return(null);
            }
        }

        


        //Un controller de tipo GET para recibir la información de la lista de empleados
        [HttpGet("MostrarControlador")]
        public ActionResult<List<Empleado>> MostrarEmpleados()
        {
            try
            {
                var empleados = AccesarBD.MostrarEmpleados();
                if (empleados.Count == 0) //No hay empleados en la tabla
                {
                    return BadRequest(new { message = "La tabla se encuentra vacía"});
                }
                return Ok(empleados);//El stored procedure devuelve la lista de empleados
            }
            catch
            {
                Console.WriteLine("No se muestra la tabla");
                return (null);
            }
        }
    }
}
