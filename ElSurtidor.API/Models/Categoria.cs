using ElSurtidor.API.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElSurtidor.API.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(256)]
        public string Descripcion { get; set; }
        
        [Required]
        public bool Activo { get; set; }


        //public List<Producto> Productos { get; set; }


        public Categoria()
        {

        }

        public Categoria( string nombre, string descripcion, bool activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
        }

        public Categoria(CategoriaWithIdDTO dto)
        {
            Id = dto.Id;
            Nombre = dto.Nombre;
            Descripcion = dto.Descripcion;

        }
        public Categoria(CategoriaDTO dto)
        {
            Nombre = dto.Nombre;
            Descripcion = dto.Descripcion;
            Activo = true;
        }
    }
}
