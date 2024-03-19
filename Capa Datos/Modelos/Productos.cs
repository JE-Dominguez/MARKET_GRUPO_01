using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capa_Datos.Modelos
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required]
        public int UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida UnidadMedida { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public decimal PrecioCompra { get; set; }
    }
}
