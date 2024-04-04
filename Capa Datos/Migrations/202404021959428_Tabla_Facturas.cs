namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Facturas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        FacturaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                        UnidadMedidaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaFactura = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .ForeignKey("dbo.Pedido", t => t.PedidoId)
                .ForeignKey("dbo.UnidadMedida", t => t.UnidadMedidaId)
                .Index(t => t.ClienteId)
                .Index(t => t.PedidoId)
                .Index(t => t.UnidadMedidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "UnidadMedidaId", "dbo.UnidadMedida");
            DropForeignKey("dbo.Factura", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Factura", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Factura", new[] { "PedidoId" });
            DropIndex("dbo.Factura", new[] { "ClienteId" });
            DropTable("dbo.Factura");
        }
    }
}
