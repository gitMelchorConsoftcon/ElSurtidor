using ElSurtidor.API.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElSurtidor.API.Models
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }


        public Rol()
        {

        }

        public Rol(RolDTO dto)
        {
            Nombre = dto.Nombre;
            Descripcion = dto.Descripcion;
            Activo = true;
        }
    }
}
