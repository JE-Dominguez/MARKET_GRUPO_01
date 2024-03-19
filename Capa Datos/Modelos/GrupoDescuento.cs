using System;
using System.ComponentModel.DataAnnotations;

namespace Capa_Datos.Modelos
{
    public class GrupoDescuento
    {
        [Key]
        public int GrupoDescuentoId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public int Porcentaje { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
