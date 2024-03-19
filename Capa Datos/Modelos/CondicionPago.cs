using System;
using System.ComponentModel.DataAnnotations;

namespace Capa_Datos.Modelos
{
    public class CondicionPago
    {
        [Key]
        public int CondicionPagoId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public int Dias { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
