using System;
using System.Collections.Generic;
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


        [Required]
        public DateTime FechaCreacion { get; set; }

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


    }
}
