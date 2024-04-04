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
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<GrupoDescuento> GrupoDescuentos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<CondicionPago> CondicionPagos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
