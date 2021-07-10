namespace ElSurtidor.API.DTO
{
    public class ProductoDTO
    {
     

        public int IdCategoria { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public decimal PrecioVenta { get; set; }

        public string Descripcion { get; set; }


        public ProductoDTO()
        {

        }

        public ProductoDTO(ProductoDTO obj)
        {
            Nombre = obj.Nombre;
            PrecioVenta = obj.PrecioVenta;
            Descripcion = obj.Descripcion;
            Codigo = obj.Codigo;
        }
    }
}
