using System;
using System.ComponentModel.DataAnnotations;

namespace Capa_Datos.Modelos
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreRol { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public DateTime FechaModificacion { get; set; }

        [Required]
        [StringLength(50)]
        public string UsuarioCreador { get; set; }

        [Required]
        [StringLength(50)]
        public string UsuarioModifica { get; set; }

        [Required]
        public bool Estado { get; set; }

        public bool p_pedidos { get; set; }
        public bool p_detalles { get; set; }
        public bool p_facturas { get; set; }
        public bool p_detallesFac { get; set; }

        public bool pr_productos { get; set; }
        public bool pr_categorias { get; set; }
        public bool pr_unidadMedida { get; set; }
        public bool pr_impuesto { get; set; }

        public bool cl_clientes { get; set; }
        public bool cl_grupodescuentos { get; set; }
        public bool cl_condicionpago { get; set; }

        public bool seg_usuarios { get; set; }
        public bool seg_roles { get; set; }

    }
}
