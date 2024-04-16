namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablaotracantidaddato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PedidoDetalle", "Cantidad", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PedidoDetalle", "Cantidad");
        }
    }
}
