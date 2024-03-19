using System;
using System.ComponentModel.DataAnnotations;

namespace Capa_Datos.Modelos
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
