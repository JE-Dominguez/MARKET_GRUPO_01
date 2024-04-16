namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminacioncolimnaunidadid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Factura", "UnidadMedidaId", "dbo.UnidadMedida");
            DropIndex("dbo.Factura", new[] { "UnidadMedidaId" });
            DropColumn("dbo.Factura", "UnidadMedidaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Factura", "UnidadMedidaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Factura", "UnidadMedidaId");
            AddForeignKey("dbo.Factura", "UnidadMedidaId", "dbo.UnidadMedida", "UnidadMedidaId");
        }
    }
}
