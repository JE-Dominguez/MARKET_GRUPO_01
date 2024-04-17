using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocios;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Rol : Form
    {
        int? ID;
        N_Roles n_roles;
        public V_Rol(int? iD = null)
        {
            InitializeComponent();
            n_roles = new N_Roles();
            ID = iD;

            if (iD != null) { ConsultarPorId(); }
        }
        private void Limpiar()
        {
            TxtIdRol.Text = "";
            TxtNombre.Text = "";
            TxtDescripcion.Text = "";
            ChkActivo.Checked = false;

            ChkPedidos.Checked = false;
            ChkDetalles.Checked = false;
            ChkFacturas.Checked = false;
            ChkDetallesFac.Checked = false;

            ChkProductos.Checked = false;
            ChkCategorias.Checked = false;
            ChkUnidadMedida.Checked = false;
            ChkImpuesto.Checked = false;

            ChkClientes.Checked = false;
            ChkGrupoDescuentos.Checked = false;
            ChkCondicionPago.Checked = false;

            ChkUsuarios.Checked = false;
            ChkRoles.Checked = false;
        }
        private void ConsultarPorId()
        {
            var roles = n_roles.ObtenerRoles().FirstOrDefault(g => g.RolID == ID);
            if (roles != null)
            {
                LblTitulo.Text = "Editar Usuario";
                TxtIdRol.Text = roles.RolID.ToString();
                TxtNombre.Text = roles.NombreRol;
                TxtDescripcion.Text = roles.Descripcion;
                ChkActivo.Checked = roles.Estado;

                // Configuración de las casillas de verificación
                ChkPedidos.Checked = roles.p_pedidos;
                ChkDetalles.Checked = roles.p_detalles;
                ChkFacturas.Checked = roles.p_facturas;
                ChkDetallesFac.Checked = roles.p_detallesFac;

                ChkProductos.Checked = roles.pr_productos;
                ChkCategorias.Checked = roles.pr_categorias;
                ChkUnidadMedida.Checked = roles.pr_unidadMedida;
                ChkImpuesto.Checked = roles.pr_impuesto;

                ChkClientes.Checked = roles.cl_clientes;
                ChkGrupoDescuentos.Checked = roles.cl_grupodescuentos;
                ChkCondicionPago.Checked = roles.cl_condicionpago;

                ChkUsuarios.Checked = roles.seg_usuarios;
                ChkRoles.Checked = roles.seg_roles;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string RolId = TxtIdRol.Text;
            string Nombre = TxtNombre.Text;
            string Descripcion = TxtDescripcion.Text;

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrWhiteSpace(Nombre))
            {
                errorProvider1.SetError(TxtNombre, "Debe colocar la descripcion");
                return;
            }
            if (string.IsNullOrEmpty(RolId) || string.IsNullOrWhiteSpace(RolId))
            {
                RolId = "0";
            }

            var roles = new Roles();
            if (int.TryParse(RolId, out int id) && id != 0)
            {
                roles.RolID = id;
            }
            roles.NombreRol = Nombre;
            roles.Descripcion = Descripcion;
            roles.Estado = ChkActivo.Checked;

            // Configuración de las propiedades booleanas
            roles.p_pedidos = ChkPedidos.Checked;
            roles.p_detalles = ChkDetalles.Checked;
            roles.p_facturas = ChkFacturas.Checked;
            roles.p_detallesFac = ChkDetallesFac.Checked;

            roles.pr_productos = ChkProductos.Checked;
            roles.pr_categorias = ChkCategorias.Checked;
            roles.pr_unidadMedida = ChkUnidadMedida.Checked;
            roles.pr_impuesto = ChkImpuesto.Checked;

            roles.cl_clientes = ChkClientes.Checked;
            roles.cl_grupodescuentos = ChkGrupoDescuentos.Checked;
            roles.cl_condicionpago = ChkCondicionPago.Checked;

            roles.seg_usuarios = ChkUsuarios.Checked;
            roles.seg_roles = ChkRoles.Checked;

            n_roles.GuardarRol(roles);

            Limpiar();
            this.Close();
        }

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
