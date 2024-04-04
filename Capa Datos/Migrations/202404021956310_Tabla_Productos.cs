namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        UnidadMedidaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        PrecioCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .ForeignKey("dbo.UnidadMedida", t => t.UnidadMedidaId)
                .Index(t => t.CategoriaId)
                .Index(t => t.UnidadMedidaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "UnidadMedidaId", "dbo.UnidadMedida");
            DropForeignKey("dbo.Productos", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Productos", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Productos", new[] { "CategoriaId" });
            DropTable("dbo.Productos");
        }
    }
}
