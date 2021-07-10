using ElSurtidor.API.Data;
using ElSurtidor.API.DTO;
using ElSurtidor.API.Helpers;
using ElSurtidor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ElSurtidor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly DataContext DB;
        Respuesta respuesta = new Respuesta();
        public RolesController(DataContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {           
            try
            {

                var Rols = (from r in DB.Rol
                            select new
                            {
                                r.Id,
                                r.Nombre,
                                r.Descripcion,

                            }).ToList();


                if (Rols.Count == 0)
                    throw new TException("No tenemos Rols para enviar");

                respuesta.Data = Rols;

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


        [HttpGet("[Action]")]
        public IActionResult Activas()
        {

            try
            {
                var Rols = (
                                    from c in DB.Rol
                                    where c.Activo == true
                                    select new
                                    {
                                        IdRol = c.Id,
                                        Nombre = c.Nombre,
                                        Descripcion=c.Descripcion
                                    }
                                  ).ToList();


                if (Rols.Count == 0)
                    throw new TException("No tenemos Rols para enviar");

                respuesta.Data = Rols;

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


        [HttpGet("[Action]")]
        public IActionResult Canceladas()
        {

            try
            {
                var Rols = (
                                    from c in DB.Rol
                                    where c.Activo == false
                                    orderby c.Nombre ascending
                                    select new
                                    {
                                        Id = c.Id,
                                        Nombre = c.Nombre,
                                    }

                                  ).ToList();


                if (Rols.Count == 0)
                    throw new TException("No tenemos Rols para enviar");

                respuesta.Data = Rols;

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



        [HttpGet("[Action]/{id}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                var obj = DB.Rol.Find(id);
                if (obj == null)
                    throw new TException("Rol no encontrada");

                respuesta.Data = obj;
                return Ok(respuesta);

            }
            catch (TException ex)
            {

                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            catch (Exception)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "Error de sistema..";
                return BadRequest(respuesta);
            }
        }


        [HttpGet("[Action]/{nombre}")]
        public IActionResult BuscarNombre(string nombre)
        {
            try
            {
                var obj = from c in DB.Rol
                          where c.Nombre.Contains(nombre)
                          select new
                          {
                              IdRol = c.Id,
                              Nombre = c.Nombre,
                              Descripcion = c.Descripcion
                          };





                if (obj == null)
                    throw new TException("Rol no encontrada");

                respuesta.Data = obj;
                return Ok(respuesta);

            }
            catch (TException ex)
            {

                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            catch (Exception)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "Error de sistema..";
                return BadRequest(respuesta);
            }
        }




        [HttpPost]
        public IActionResult Post([FromBody] RolDTO obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Rol rol = new Rol(obj);
                    DB.Rol.Add(rol);
                    DB.SaveChanges();

                    respuesta.Data = new RolWithId(rol);

                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Estado = false;
                    // string MensajeError = ModelState.Values.First().Errors[0].ErrorMessage;
                    string MensajeError = "";
                    foreach (var valor in ModelState.Values)
                    {
                        MensajeError += $" | {valor.Errors[0].ErrorMessage} ";
                    }
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RolDTO obj)
        {

            try
            {
                var modificar = DB.Rol.Find(id);

                if (obj == null)
                    throw new TException("Rol no encontrada");

                modificar.Nombre = obj.Nombre;
                modificar.Descripcion = obj.Descripcion;


                DB.Update(modificar);
                DB.SaveChanges();


                respuesta.Data = new RolWithId(new Rol(obj));

                return Ok(respuesta);
            }
            catch (TException ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            catch (Exception)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "Error de distema...";
                return BadRequest(respuesta);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {


            try
            {
                var borrar = DB.Rol.Find(id);
                if (borrar == null)
                    throw new TException("Rol no encontrada");


                borrar.Activo = false;
                //DB.Remove(borrar);
                DB.Update(borrar);
                DB.SaveChanges();
                return Ok(borrar);
            }
            catch (TException ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            catch (Exception)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "Error de sistema";
                return BadRequest(respuesta);
            }


        }



    }
}
