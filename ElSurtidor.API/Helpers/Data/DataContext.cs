using ElSurtidor.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ElSurtidor.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext( DbContextOptions<DataContext> options):base (options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<VentaDetalle> VentaDetalle { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CompraDetalle> CompraDetalles { get; set; }



    }
}
