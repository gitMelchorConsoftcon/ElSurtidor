using ElSurtidor.API.Models;

namespace ElSurtidor.API.DTO
{
    public class UsuarioDTO
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


        public UsuarioDTO()
        {

        }
        public UsuarioDTO(Usuario  obj)
        {
            IdRol = obj.IdRol;
            Nombre = obj.Nombre;
            Direccion = obj.Direccion;
            Telefono = obj.Telefono;
            Email = obj.Email;
        }
    }
}
