using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Modelos
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Clientes { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public decimal Total { get; set; }
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public decimal Descuento { get; set; }
        [Required]
        public decimal Impuesto { get; set; }

    }
}
