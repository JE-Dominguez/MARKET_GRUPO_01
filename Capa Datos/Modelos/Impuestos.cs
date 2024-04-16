using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Modelos
{
    public class Impuestos
    {
        [Key]
        public int ImpuestoId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Codigo { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Estado { get; set; }
    }
}
