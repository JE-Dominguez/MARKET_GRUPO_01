using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public static class D_ParametrosActivos
    {
        // Propiedades de Roles
        public static bool p_pedidos { get; set; }
        public static bool p_detalles { get; set; }
        public static bool p_facturas { get; set; }
        public static bool p_detallesFac { get; set; }
        public static bool pr_productos { get; set; }
        public static bool pr_categorias { get; set; }
        public static bool pr_unidadMedida { get; set; }
        public static bool pr_impuesto { get; set; }
        public static bool cl_clientes { get; set; }
        public static bool cl_grupodescuentos { get; set; }
        public static bool cl_condicionpago { get; set; }
        public static bool seg_usuarios { get; set; }
        public static bool seg_roles { get; set; }

        // Propiedades de Usuario
        public static int UsuarioID { get; set; }
        public static string Usuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string Rol { get; set; }
        public static string FechaInicio { get; set; }
    }
}
