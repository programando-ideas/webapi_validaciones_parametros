using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_validaciones_parametros.Models;

namespace webapi_validaciones_parametros.Controllers
{
    [Route("api/direcciones")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        /*
            GET http://localhost:5000/api/Direcciones/verificar
            {
                "Id": 1,
                "Calle": "Avenida AAAA",
                "Numero": "32",
                "Piso": "3",
                "Depto": "3",
                "CP": "43423"
            }
        */

        [HttpGet]
        [Route("verificarnormal")]
        public IActionResult VerificarDireccion([FromBody] Direccion direccion)
        {
            if (string.IsNullOrWhiteSpace(direccion.Calle))
            {
                return BadRequest(new
                {
                    code = false,
                    message = "La calle es un dato requerido"
                });
            }

            if (string.IsNullOrWhiteSpace(direccion.Numero))
            {
                return BadRequest(new
                {
                    code = false,
                    message = "El número de la calle es un dato requerido"
                });
            }

            return Ok(new
            {
                code = true,
                message = "La dirección es correcta",
                direccion
            });
        }

        [HttpGet]
        [Route("verificar")]
        public IActionResult VerificarDireccion([FromBody] RequestDireccionWithValidation direccion)
        {
            return Ok(new
            {
                code = true,
                message = "La dirección es correcta",
                direccion
            });
        }
    }
}
