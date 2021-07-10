using ElSurtidor.API.Models;

namespace ElSurtidor.API.DTO
{
    public class ProveedorDTO
    {
    
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string RFC { get; set; }


        public ProveedorDTO()
        {


        }


        public ProveedorDTO(Proveedor obj) 
        {
            Nombre = obj.Nombre;
            Direccion = obj.Direccion;
            Telefono = obj.Telefono;
            Email = obj.Email;
            RFC = obj.RFC;
        }

    }
}
