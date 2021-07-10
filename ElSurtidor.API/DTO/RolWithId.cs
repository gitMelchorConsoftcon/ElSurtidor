using ElSurtidor.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElSurtidor.API.DTO
{
    public class RolWithId
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public RolWithId()
        {

        }

        public RolWithId(Rol obj)
        {
            Id = obj.Id;
            Nombre = obj.Nombre;
            Descripcion = obj.Descripcion;

        }
    }
}
