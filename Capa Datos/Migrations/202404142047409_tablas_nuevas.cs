namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas_nuevas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Impuestos",
                c => new
                    {
                        ImpuestoId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 10),
                        Porcentaje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ImpuestoId);
            
            AddColumn("dbo.Pedido", "Impuesto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Productos", "ImpuestoId", c => c.Int(nullable: false));
            AddColumn("dbo.PedidoDetalle", "Impuesto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Productos", "ImpuestoId");
            AddForeignKey("dbo.Productos", "ImpuestoId", "dbo.Impuestos", "ImpuestoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "ImpuestoId", "dbo.Impuestos");
            DropIndex("dbo.Productos", new[] { "ImpuestoId" });
            DropColumn("dbo.PedidoDetalle", "Impuesto");
            DropColumn("dbo.Productos", "ImpuestoId");
            DropColumn("dbo.Pedido", "Impuesto");
            DropTable("dbo.Impuestos");
        }
    }
}
