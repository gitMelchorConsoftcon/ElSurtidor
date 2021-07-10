using ElSurtidor.API.Data;
using ElSurtidor.API.DTO;
using ElSurtidor.API.Helpers;
using ElSurtidor.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElSurtidor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext DB;
        Respuesta respuesta = new Respuesta();
        public ProductosController(DataContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
           
            try
            {
                //List<Producto> productos = DB.Producto.Include(x => x.Categoria).Where(x => x.Activo).ToList();


                var productos = (from p in DB.Producto
                                 join c in DB.Categoria on p.IdCategoria equals c.Id
                                 select new
                                 {
                                     Id = p.Id,
                                     Nombre = p.Nombre,
                                     Descripcion = p.Descripcion,
                                     PrecioVenta = p.PrecioVenta,
                                     Codigo = p.Codigo,
                                     Existencia = p.Existencia,
                                     IdCategoria = p.IdCategoria,
                                     NombreCategoria = p.Categoria.Nombre
                                 }).ToList();


                
               //var lista= productos.Select( p=>  new ProductoGetAllDTO
               //                            {
               //                               Id=p.Id,
               //                               Nombre=p.Nombre,
               //                               Descripcion=p.Descripcion,
               //                               PrecioVenta=p.PrecioVenta,
               //                               Codigo=p.Codigo,
               //                               Existencia=p.Existencia,
               //                               IdCategoria=p.IdCategoria,
               //                               NombreCategoria=p.Categoria.Nombre

               //                            });
                       

                if (productos.Count == 0)
                    throw new Exception("No tenemos productos para enviar");

                respuesta.Data = productos;

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
                var obj = (from p in DB.Producto
                          join c in DB.Categoria on p.IdCategoria equals c.Id
                          where p.Id==id
                          select new
                          {
                              Id = p.Id,
                              Nombre = p.Nombre,
                              Descripcion = p.Descripcion,
                              PrecioVenta = p.PrecioVenta,
                              Codigo = p.Codigo,
                              Existencia = p.Existencia,
                              IdCategoria = p.IdCategoria,
                              NombreCategoria = p.Categoria.Nombre
                          }).ToList();


                if (obj.Count<=0)
                    throw new TException("producto no encontrada");

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
                var obj = (from p in DB.Producto
                          join c in DB.Categoria on p.IdCategoria equals c.Id
                          where p.Nombre.Contains(nombre)
                          select new
                          {
                              Id = p.Id,
                              Nombre = p.Nombre,
                              Descripcion = p.Descripcion,
                              PrecioVenta = p.PrecioVenta,
                              Codigo = p.Codigo,
                              Existencia = p.Existencia,
                              IdCategoria = p.IdCategoria,
                              NombreCategoria = p.Categoria.Nombre
                          }).ToList();


                if (obj.Count <=0)
                    throw new TException("producto no encontrada");

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
        public IActionResult Post([FromBody] ProductoDTO obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Producto producto = new Producto(obj);
                    DB.Producto.Add(producto);
                    DB.SaveChanges();

                    respuesta.Data = obj;

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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductoDTO obj)
        {

            try
            {


                var modificar = DB.Producto.Find(id);

                if (obj == null)
                    throw new TException("producto no encontrada");

                modificar.Nombre = obj.Nombre;
                modificar.IdCategoria = obj.IdCategoria;
                modificar.PrecioVenta = obj.PrecioVenta;
                modificar.Descripcion = obj.Descripcion;

                DB.Update(modificar);
                DB.SaveChanges();


                respuesta.Data = new ProductoDTOWithId(modificar);

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
                var borrar = DB.Producto.Find(id);
                if (borrar == null)
                    throw new TException("producto no encontrada");


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
