using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capa_Datos.Modelos
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Required]
        public int GrupoDescuentoId { get; set; }

        [ForeignKey("GrupoDescuentoId")]
        public virtual GrupoDescuento grupoDescuento { get; set; }

        [Required]
        public int CondicionPagoId { get; set; }

        [ForeignKey("CondicionPagoId")]
        public virtual CondicionPago condicionPago { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
