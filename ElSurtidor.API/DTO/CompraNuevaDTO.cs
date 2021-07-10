using System.Collections.Generic;

namespace ElSurtidor.API.DTO
{
    public class CompraNuevaDTO
    {
        public int IdProveedor { get; set; }

        public int IdUsuario { get; set; }

        public int NumFactura { get; set; }

        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }


        public List<CompraDetalleNuevaDTO> Detalle { get; set; }

        public CompraNuevaDTO()
        {

        }
    }
}
