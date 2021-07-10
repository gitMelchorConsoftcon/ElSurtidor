using System.Collections.Generic;

namespace ElSurtidor.API.DTO
{
    public class VentaNuevaDTO
    {

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public int NumFactura { get; set; }

        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }


        public List<VentaDetalleNuevaDTO> Detalle { get; set; }

        public VentaNuevaDTO()
        {

        }

        
    }
}
