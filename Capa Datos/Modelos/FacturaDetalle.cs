using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Modelos
{
    public class FacturaDetalle
    {
        [Key]
        public int FacturaDetalleId { get; set; }

        [Required]
        public int FacturaId { get; set; }

        [ForeignKey("FacturaId")]
        public virtual Factura Factura { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Productos { get; set; }

        [Required]
        public DateTime FechaFactura { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public decimal Descuento { get; set; }



    }
}
