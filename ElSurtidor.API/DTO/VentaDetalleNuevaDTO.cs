namespace ElSurtidor.API.DTO
{
    public class VentaDetalleNuevaDTO
    {

        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }

        public VentaDetalleNuevaDTO()
        {

        }
    }
}
