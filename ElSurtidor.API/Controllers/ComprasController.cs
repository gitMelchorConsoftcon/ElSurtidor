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
    public class ComprasController : ControllerBase
    {
        private readonly DataContext DB;
        Respuesta respuesta = new Respuesta();

        public ComprasController(DataContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {

                var compras = (from v in DB.Compra
                              join d in DB.CompraDetalles on v.Id equals d.IdCompra
                              select new
                              {
                                  v.Id,
                                  v.FechaHora,
                                  v.NumFactura,
                                  v.Impuesto,
                                  v.Total,
                                  Detalle = d
                              }).ToList();


                if (compras.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = compras;

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
        public IActionResult Post([FromBody] CompraNuevaDTO v)
        {
            var compra = new Compra
            {
                IdUsuario = v.IdUsuario,
                IdProveedor = v.IdProveedor,
                NumFactura = v.NumFactura,
                FechaHora = DateTime.Now,
                Impuesto = v.Impuesto,
                Total = v.Total,
            };

            DB.Compra.Add(compra);
            DB.SaveChanges();

            foreach (var item in v.Detalle)
            {
                var detalle = new CompraDetalle
                {
                    IdCompra = compra.Id,
                    IdProducto = item.IdProducto,
                    Cantidad = item.Cantidad,
                    Precio = item.Precio,
                };

                DB.CompraDetalles.Add(detalle);

            }
            DB.SaveChanges();

            return Ok(compra);


        }

    }
}
