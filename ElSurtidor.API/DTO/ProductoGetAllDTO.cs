namespace ElSurtidor.API.DTO
{
    public class ProductoGetAllDTO
    {

        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public decimal PrecioVenta { get; set; }

        public int Existencia { get; set; }

        public string Descripcion { get; set; }


        public ProductoGetAllDTO()
        {
           
        }
    }
}
