﻿namespace Capa_Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tabla_Pedidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaPedido = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropTable("dbo.Pedido");
        }
    }
}
