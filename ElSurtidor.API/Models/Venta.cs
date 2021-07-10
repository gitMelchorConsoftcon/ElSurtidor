using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElSurtidor.API.Models
{
    [Table("Ventas")]
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        [Column(name: "num_factura")]
        public int NumFactura { get; set; }

        [Column(name: "fecha_hora")]
        public DateTime FechaHora { get; set; }

        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }


        public Venta()
        {

        }

    }
}
