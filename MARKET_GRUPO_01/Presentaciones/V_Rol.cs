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
            TxtDescripcion.Text = "";
            TxtNombre.Text = "";
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
            if (int.Parse(RolId) != 0)
            {
                roles.RolID = int.Parse(RolId);
            }
            roles.NombreRol = Nombre;
            roles.Descripcion = Descripcion;
            roles.Estado = ChkActivo.Checked;
            n_roles.GuardarRol(roles);

            Limpiar();
        }
    }
}
