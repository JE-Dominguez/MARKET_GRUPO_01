namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablasotras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PedidoDetalle", "CodigoProducto", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.PedidoDetalle", "Descripcion", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PedidoDetalle", "Descripcion");
            DropColumn("dbo.PedidoDetalle", "CodigoProducto");
        }
    }
}
