using Capa_Datos.Modelos;
using Capa_Negocios;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Seguridad : Form
    {
        AbrirForm AF;
        public V_Inicio inicio;
        N_Usuarios nUsuario;
        public V_Seguridad(V_Inicio ini)
        {
            InitializeComponent();
            AF = new AbrirForm();
            nUsuario = new N_Usuarios();
            HabilitarSoloColumnaSeleccion();
            inicio = ini;
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            TabControlMain.SelectedTab = TabUsuarios;
        }
        private void BtnRoles_Click(object sender, EventArgs e)
        {
            TabControlMain.SelectedTab = TabRoles;
        }

        private void BtnPermisos_Click(object sender, EventArgs e) { }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e);


        }
        void SeleccionarSoloUno(DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) // 1 es el índice de la columna de CheckBox
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)DgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                for (int i = 0; i < DgvDatos.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        DataGridViewCheckBoxCell otherChk = (DataGridViewCheckBoxCell)DgvDatos.Rows[i].Cells[e.ColumnIndex];
                        otherChk.Value = false;
                    }
                }
            }
        }
        void HabilitarSoloColumnaSeleccion()
        {
            foreach (DataGridViewColumn column in DgvDatos.Columns)
            {
                column.ReadOnly = true;
            }

            // Establecer la primera columna como no de solo lectura
            DgvDatos.Columns[0].ReadOnly = false;
        }

        private void BtnNuevoUsuario_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Usuario(), inicio, true);
        }

        private void BtnNuevoRol_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Rol(), inicio, true);
        }
        void ConsultarPorId(int IdUsuario)
        {
            if (BtnUsuarios.Checked == true)
            {
                V_Usuario vUsuario = new V_Usuario();
                var usuario = nUsuario.ObtenerUsuarios().FirstOrDefault(g => g.ID == IdUsuario);
                if (usuario != null)
                {
                    vUsuario.LblTitulo.Text = "Editar Usuario";
                    vUsuario.TxtIdUsuario.Text = usuario.ID.ToString();
                    vUsuario.TxtNombre.Text = usuario.Nombre;
                    vUsuario.TxtApellido.Text = usuario.Apellido;
                    vUsuario.TxtContraseña.Text = usuario.Contraseña;
                    vUsuario.TxtCorreo.Text = usuario.Correo;
                    vUsuario.TxtUsuario.Text = usuario.Usuario;
                    vUsuario.ChkActivo.Checked = usuario.Estado;
                    vUsuario.CmbRol.SelectedValue = usuario.RolID;
                    AF.VentanaEmergente(vUsuario, inicio, true);
                }
            }
        }

        void CargarDatos()
        {
            DgvDatos.DataSource = nUsuario.ObtenerUsuarios();
        }

        private void V_Seguridad_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DgvDatos.SelectedCells.Count > 0)
            {
                int rowIndex = DgvDatos.SelectedCells[0].RowIndex;
                DataGridViewCheckBoxCell checkBoxCell = DgvDatos.Rows[rowIndex].Cells["Selecion"] as DataGridViewCheckBoxCell;

                if (checkBoxCell?.Value is true)
                {
                    // Obtener el ID directamente de la celda
                    if (DgvDatos.Rows[rowIndex].Cells["ID"].Value is int id)
                    {
                        ConsultarPorId(id);
                    }
                }
            }
        }
    }
}
