using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace Capa_Datos.Modelos
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public virtual UnidadMedida UnidadMedida { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaFactura { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public decimal Descuento { get; set; }
    }
}