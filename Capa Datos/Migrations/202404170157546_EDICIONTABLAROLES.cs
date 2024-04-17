namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EDICIONTABLAROLES : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "p_pedidos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "p_detalles", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "p_facturas", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "p_detallesFac", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "pr_productos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "pr_categorias", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "pr_unidadMedida", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "pr_impuesto", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "cl_clientes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "cl_grupodescuentos", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "cl_condicionpago", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "seg_usuarios", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "seg_roles", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "seg_roles");
            DropColumn("dbo.Roles", "seg_usuarios");
            DropColumn("dbo.Roles", "cl_condicionpago");
            DropColumn("dbo.Roles", "cl_grupodescuentos");
            DropColumn("dbo.Roles", "cl_clientes");
            DropColumn("dbo.Roles", "pr_impuesto");
            DropColumn("dbo.Roles", "pr_unidadMedida");
            DropColumn("dbo.Roles", "pr_categorias");
            DropColumn("dbo.Roles", "pr_productos");
            DropColumn("dbo.Roles", "p_detallesFac");
            DropColumn("dbo.Roles", "p_facturas");
            DropColumn("dbo.Roles", "p_detalles");
            DropColumn("dbo.Roles", "p_pedidos");
        }
    }
}
