using ElSurtidor.API.Models;

namespace ElSurtidor.API.DTO
{
    public class ProductoDTOWithId
    {
        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public decimal PrecioVenta { get; set; }

        public string Descripcion { get; set; }

        public ProductoDTOWithId()
        {

        }

        public ProductoDTOWithId(Producto obj)
        {
            Id = obj.Id;
            IdCategoria = obj.IdCategoria;
            Codigo = obj.Codigo;
            Nombre = obj.Nombre;
            PrecioVenta = obj.PrecioVenta;
            Descripcion = obj.Descripcion;

        }

    }
}
