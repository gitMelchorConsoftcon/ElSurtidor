using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElSurtidor.API.Models
{
    [Table("Compras_detalles")]
    public class CompraDetalle
    {
        [Key]
        public int Id { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public CompraDetalle()
        {

        }
    }
}
