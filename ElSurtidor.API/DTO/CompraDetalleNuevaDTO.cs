using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElSurtidor.API.DTO
{
    public class CompraDetalleNuevaDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }


        public CompraDetalleNuevaDTO()
        {

        }
    }
}
