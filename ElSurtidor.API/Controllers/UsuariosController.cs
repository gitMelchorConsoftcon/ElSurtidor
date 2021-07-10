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
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext DB;
        Respuesta respuesta = new Respuesta();
        public UsuariosController(DataContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {

                var usuarios = (from u in DB.Usuario
                                join r in DB.Rol on u.IdRol equals r.Id
                                select new
                                {
                                    u.Nombre,
                                    u.Telefono,
                                    u.Email,
                                    u.Direccion,
                                    u.IdRol,
                                    RolUsuario = r.Nombre
                                }).ToList();

                if (usuarios.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = usuarios;

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
        public IActionResult Post([FromBody] UsuarioDTO obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = new Usuario(obj);
                    DB.Usuario.Add(usuario);
                    DB.SaveChanges();

                    respuesta.Data = usuario;

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


        [HttpGet("[Action]/{id}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                var usuarios = (from u in DB.Usuario
                                join r in DB.Rol on u.IdRol equals r.Id
                                where u.Id==id
                                select new
                                {
                                    u.Nombre,
                                    u.Telefono,
                                    u.Email,
                                    u.Direccion,
                                    u.IdRol,
                                    RolUsuario = r.Nombre
                                }).ToList();

                if (usuarios.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = usuarios;
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
                var usuarios = (from u in DB.Usuario
                                join r in DB.Rol on u.IdRol equals r.Id
                                where u.Nombre.Contains(nombre)
                                select new
                                {
                                    u.Nombre,
                                    u.Telefono,
                                    u.Email,
                                    u.Direccion,
                                    u.IdRol,
                                    RolUsuario = r.Nombre
                                }).ToList();

                if (usuarios.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = usuarios;
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



        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioDTO obj)
        {

            try
            {
                var modificar = DB.Usuario.Find(id);

                if (obj == null)
                    throw new TException("Categoria no encontrada");

                modificar.Nombre = obj.Nombre;


                DB.Update(modificar);
                DB.SaveChanges();


                respuesta.Data = modificar;

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
                var borrar = DB.Usuario.Find(id);
                if (borrar == null)
                    throw new TException("Categoria no encontrada");


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
