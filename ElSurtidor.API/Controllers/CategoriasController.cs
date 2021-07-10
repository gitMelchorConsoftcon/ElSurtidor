using ElSurtidor.API.Data;
using ElSurtidor.API.DTO;
using ElSurtidor.API.Helpers;
using ElSurtidor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElSurtidor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController :ControllerBase
    {
        private readonly DataContext DB;
        Respuesta respuesta = new Respuesta();
        public CategoriasController(DataContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<CategoriaWithIdDTO> categorias = new List<CategoriaWithIdDTO>();
 
            
            try
            {
                foreach (var item in DB.Categoria)
                    categorias.Add(new CategoriaWithIdDTO(item));

                if (categorias.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = categorias;

            }
            catch (TException ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
            }
            catch(Exception ex)
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
                var categorias = (
                                    from c in DB.Categoria
                                    where c.Activo==true
                                    select new  
                                    {
                                        IdCategoria=c.Id,
                                        Nombre=c.Nombre,
                                    }
                                  ).ToList();


                if (categorias.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = categorias;

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
                var categorias = (
                                    from c in DB.Categoria
                                    where c.Activo == false
                                    orderby c.Nombre ascending
                                    select new
                                    {
                                        Id = c.Id,
                                        Nombre = c.Nombre,
                                    }
                                   
                                  ).ToList();


                if (categorias.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = categorias;

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
                var obj = DB.Categoria.Find(id);
                if (obj == null)
                    throw new TException("Categoria no encontrada");

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
                var obj = from c in DB.Categoria
                          where c.Nombre.Contains(nombre)
                          select new
                          {
                              IdCategoria = c.Id,
                              Nombre = c.Nombre,
                              Descripcion = c.Descripcion
                          };


               
                
                
                if (obj == null)
                    throw new TException("Categoria no encontrada");

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
        public IActionResult Post([FromBody] CategoriaDTO obj) 
        {
           
            try
            {
               if (ModelState.IsValid)
                {
                    Categoria categoria = new Categoria(obj);
                    DB.Categoria.Add(categoria);
                    DB.SaveChanges();

                    respuesta.Data = new CategoriaWithIdDTO(categoria);

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
            catch(Exception)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "Error de sistema..";
                return BadRequest(respuesta);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoriaDTO obj)
        {
            
            try
            {
                var modificar = DB.Categoria.Find(id);

                if (obj == null)
                    throw new TException("Categoria no encontrada");

                modificar.Nombre = obj.Nombre;
                modificar.Descripcion = obj.Descripcion;
               

                DB.Update( modificar);
                DB.SaveChanges();


                respuesta.Data = new CategoriaWithIdDTO(new Categoria( obj));

                return Ok(respuesta);
            }
            catch(TException ex)
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
                var borrar = DB.Categoria.Find(id);
                if (borrar == null)
                    throw new TException("Categoria no encontrada");


                borrar.Activo = false;
                //DB.Remove(borrar);
                DB.Update(borrar);
                DB.SaveChanges();
                return Ok(borrar);
            }
            catch(TException ex)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = ex.Message;
                return BadRequest(respuesta);
            }
            catch(Exception)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = "Error de sistema";
                return BadRequest(respuesta);
            }

                
        }



    }
}
