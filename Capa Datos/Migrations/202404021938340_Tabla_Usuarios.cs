namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Usuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Contraseña = c.String(nullable: false, maxLength: 50),
                        Correo = c.String(nullable: false, maxLength: 100),
                        RolID = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        UsuarioCreador = c.String(nullable: false, maxLength: 50),
                        UsuarioModifica = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RolID)
                .Index(t => t.RolID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RolID = c.Int(nullable: false, identity: true),
                        NombreRol = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 100),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        UsuarioCreador = c.String(nullable: false, maxLength: 50),
                        UsuarioModifica = c.String(nullable: false, maxLength: 50),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RolID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "RolID", "dbo.Roles");
            DropIndex("dbo.Usuarios", new[] { "RolID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
        }
    }
}
