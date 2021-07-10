using ElSurtidor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElSurtidor.API.DTO
{
    public class RolDTO
    {

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
       
        
        public RolDTO()
        {

        }


        public RolDTO(Rol obj )
        {
            Nombre = obj.Nombre;
            Descripcion = obj.Descripcion;
            

              
        }
    }
}
