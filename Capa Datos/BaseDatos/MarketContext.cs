using Capa_Datos.Modelos;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Capa_Datos.BaseDatos
{
    public class MarketContext : DbContext
    {
        public MarketContext() : base("name=Market")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Roles> Rol { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<GrupoDescuento> GrupoDescuentos { get; set; }
        public DbSet<Productos> Producto { get; set; }
        public DbSet<CondicionPago> CondicionPagos { get; set; }
    }
}
