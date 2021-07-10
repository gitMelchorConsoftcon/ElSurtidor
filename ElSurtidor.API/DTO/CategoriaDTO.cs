using ElSurtidor.API.Models;
using System.ComponentModel.DataAnnotations;

namespace ElSurtidor.API.DTO
{
    public class CategoriaDTO
    {
        [Required]
        [StringLength(30,MinimumLength =5)]
        public string Nombre { get; set; }

        [StringLength(256)]
        public string Descripcion { get; set; }


        public CategoriaDTO()
        {

        }

        public CategoriaDTO(Categoria obj)
        {
            Nombre = obj.Nombre;
            Descripcion = obj.Descripcion;
        }


    }
}
