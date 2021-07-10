using ElSurtidor.API.Data;
using ElSurtidor.API.DTO;
using ElSurtidor.API.Helpers;
using ElSurtidor.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElSurtidor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly DataContext DB;
        Respuesta respuesta = new Respuesta();
        public ProveedoresController(DataContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {

                var proveedores = DB.Proveedor.ToList();

                if (proveedores.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = proveedores;

            }
            catch (TException ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
            }
            catch (Exception ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
            }


            return Ok(respuesta);
        }


        [HttpPost]
        public IActionResult Post([FromBody] ProveedorDTO obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Proveedor proveedor = new Proveedor(obj);
                    DB.Proveedor.Add(proveedor);
                    DB.SaveChanges();

                    respuesta.Data = proveedor;

                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Estado = false;
                    string MensajeError = ModelState.Values.First().Errors[0].ErrorMessage;
                    respuesta.Mensaje = MensajeError;
                    return BadRequest(respuesta);
                }

            }
            catch (Exception)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "Error de sistema..";
                return BadRequest(respuesta);
            }

        }

    }
}
