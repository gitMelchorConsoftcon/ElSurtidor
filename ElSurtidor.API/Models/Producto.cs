using ElSurtidor.API.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElSurtidor.API.Models
{
    [Table("Productos")]
    public class Producto
    {

        [Key]
        public int Id { get; set; }
        
        public int IdCategoria { get; set; }
        
        public string Codigo { get; set; }
        
        public string Nombre { get; set; }
        
        [Column(name:"Precio_venta")]
        public decimal PrecioVenta { get; set; }
        
        public int Existencia { get; set; }
        
        public string Descripcion { get; set; }
        
        public bool Activo { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        public Producto()
        {

        }

        public Producto(ProductoDTO dto)
        {
            IdCategoria = dto.IdCategoria;
            Codigo = dto.Codigo;
            Nombre = dto.Nombre;
            PrecioVenta = dto.PrecioVenta;
            Existencia = 0;
            Descripcion = dto.Descripcion;
            Activo = true;
             
        }

    }
}
