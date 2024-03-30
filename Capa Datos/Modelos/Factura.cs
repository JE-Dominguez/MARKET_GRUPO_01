using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Capa_Datos.Modelos
{
    public class Factura
    {
        [Key]
        public int  FacturaId { get; set; }

        [Required]
        public int  ClienteId { get; set; }

        [Required]
        public int  PedidoId { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }


        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public DateTime FechaFactura { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public decimal  Total{ get; set; }
        [Required]
        public decimal  Subtotal{ get; set; }
        [Required]
        public decimal  Descuento { get; set; }

        public static int EliminarFactura(int facturaId)
        {
            throw new NotImplementedException();
        }
    }
}