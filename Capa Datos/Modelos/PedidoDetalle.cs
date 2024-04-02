using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Modelos
{
     public class PedidoDetalle
    {
        [Key]
        public int PedidoDetalleId { get; set; }

        [Required]
        public int PedidoId { get; set; }


        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public int PProductoId { get; set; }
        [Required]
        public DateTime FechaPedido { get; set; }
        [Required]
        public decimal  Precio { get; set; }
        [Required]
        public decimal Total { get; set; }s
        [Required]
        public decimal Subtotal { get; set; }
        [Required]
        public decimal Descuento { get; set; }

    }
}
