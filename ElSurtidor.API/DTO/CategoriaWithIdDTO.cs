using ElSurtidor.API.Models;

namespace ElSurtidor.API.DTO
{
    public class CategoriaWithIdDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public CategoriaWithIdDTO()
        {

        }
        public CategoriaWithIdDTO(Categoria obj)
        {
            Id = obj.Id;
            Nombre = obj.Nombre;
            Descripcion = obj.Descripcion;
        }

    }
}
