using ElSurtidor.API.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElSurtidor.API.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public byte[] Password_hash { get; set; }
        public byte[] Password_salt { get; set; }
        public bool Activo { get; set; }




        public Usuario()
        {
        }

        public Usuario(UsuarioDTO dto)
        {
            IdRol = dto.IdRol;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Telefono = dto.Telefono;
            Email = dto.Telefono;
            Password_hash = new byte[20];//Encoding.Default.GetBytes("ABC123*");
            Password_salt = new byte[16];
            Activo = true;
        }
    }
}
