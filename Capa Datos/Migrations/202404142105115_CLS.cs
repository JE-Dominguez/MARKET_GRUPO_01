namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CLS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "Codigo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productos", "Codigo");
        }
    }
}
