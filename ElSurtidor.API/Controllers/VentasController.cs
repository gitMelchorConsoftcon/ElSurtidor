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
    public class VentasController : ControllerBase
    {
        private readonly DataContext DB;
        Respuesta respuesta = new Respuesta();
        
        public VentasController(DataContext db)
        {
            DB = db;
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {

                var ventas = (from v in DB.Venta
                             join d in DB.VentaDetalle on v.Id equals d.IdVenta
                             select new
                             {
                                 v.Id,
                                 v.FechaHora,
                                 v.NumFactura,
                                 v.Impuesto,
                                 v.Total,
                                 Detalle = d
                             }).ToList();


                if (ventas.Count == 0)
                    throw new TException("No tenemos categorias para enviar");

                respuesta.Data = ventas;

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
        public IActionResult Post([FromBody] VentaNuevaDTO v)
        {
            var venta = new Venta
            {
                IdUsuario=v.IdUsuario,
                IdCliente=v.IdCliente,
                NumFactura=v.NumFactura,
                FechaHora = DateTime.Now,
                Impuesto=v.Impuesto,
                Total=v.Total,
            };

            DB.Venta.Add(venta);
            DB.SaveChanges();

            foreach (var item in v.Detalle)
            {
                var detalle = new VentaDetalle
                {
                    IdVenta = venta.Id,
                    IdProducto =item.IdProducto,
                    Cantidad=item.Cantidad,
                    Precio=item.Precio,
                    Descuento=item.Descuento
                };

                DB.VentaDetalle.Add(detalle);
                
            }
            DB.SaveChanges();

            return Ok(venta);


        }

    }
}
