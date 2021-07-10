using ElSurtidor.API.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElSurtidor.API.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }
        public bool Activo { get; set; }


        public Cliente()
        {

        }

        public Cliente(ClienteDTO dto )
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Telefono = dto.Telefono;
            Email = dto.Email;
            RFC = dto.RFC;
            Activo = true;
        }
    }
}
