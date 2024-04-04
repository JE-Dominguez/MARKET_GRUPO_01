namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Categorias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 100),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categoria");
        }
    }
}
