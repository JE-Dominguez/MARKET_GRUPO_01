using Capa_Datos.Modelos;
using Capa_Negocio;
using Capa_Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Seguridad : Form
    {
        private V_Login login = null;
        private readonly AbrirForm AF;
        private readonly V_Inicio inicio;
        private readonly N_Usuarios nUsuario;
        private readonly N_Roles nRoles;
        private string tituloListado;
        private string TextoBoton;

        public V_Seguridad(V_Inicio ini)
        {
            InitializeComponent();
            AF = new AbrirForm();
            nUsuario = new N_Usuarios();
            nRoles = new N_Roles();
            inicio = ini;
            TextoBoton = "NUEVO USUARIO";
            tituloListado = "LISTADO USUARIOS";
        }
        private void V_Seguridad_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            PnlSubMenu.Visible = false;
            Recargar();
        }
        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Recargar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            Recargar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Editar();
            Recargar();
        }

        private void BtnEiminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Recargar();
        }

        private void BtnUsuarios_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO USUARIO";
            tituloListado = "LISTADO USUARIOS";
            Recargar();
        }

        private void BtnRoles_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO ROL";
            tituloListado = "LISTADO ROLES";
            Recargar();
        }
        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvDatos);
        }
        private void Recargar()
        {
            DgvDatos.DataSource = null;
            if (BtnUsuarios.Checked)
            {
                N_Usuarios nUsuarios = new N_Usuarios();
                DgvDatos.DataSource = nUsuarios.ObtenerUsuariosGrid();
            }

            else if (BtnRoles.Checked)
            {
                N_Roles nRoles = new N_Roles();
                DgvDatos.DataSource = nRoles.ObtenerRolesGrid();
            }
            HabilitarSoloColumnaSeleccion(DgvDatos);
            LblTituloTab.Text = tituloListado;
            BtnNuevo.Text = TextoBoton;
        }

        private void SeleccionarSoloUno(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow Fila in dgv.Rows)
                {
                    DataGridViewCheckBoxCell OtroChk = (DataGridViewCheckBoxCell)Fila.Cells[e.ColumnIndex];
                    OtroChk.Value = (Fila.Index == e.RowIndex);
                }
            }
        }

        private void HabilitarSoloColumnaSeleccion(DataGridView dgv)
        {
            if (DgvDatos.DataSource != null)
            {
                foreach (DataGridViewColumn Columna in dgv.Columns)
                {
                    Columna.ReadOnly = true;
                }
                dgv.Columns[0].ReadOnly = false;
            }
        }

        private void Editar()
        {
            if (DgvDatos.SelectedCells.Count > 0)
            {
                int LineaID = DgvDatos.SelectedCells[0].RowIndex;
                DataGridViewCheckBoxCell ChkCelda = DgvDatos.Rows[LineaID].Cells["Selecion"] as DataGridViewCheckBoxCell;

                if (ChkCelda?.Value is true)
                {
                    int id = ObtenerID(LineaID);

                    if (BtnUsuarios.Checked)
                        AF.VentanaEmergente(new V_Usuario(id), inicio, D_ParametrosActivos.seg_usuarios);
                    else if (BtnRoles.Checked)
                        AF.VentanaEmergente(new V_Rol(id), inicio, D_ParametrosActivos.seg_roles);
                }
            }
        }

        private void Nuevo()
        {
            if (BtnUsuarios.Checked)
                AF.VentanaEmergente(new V_Usuario(), inicio, D_ParametrosActivos.seg_usuarios);
            else if (BtnRoles.Checked)
                AF.VentanaEmergente(new V_Rol(), inicio, D_ParametrosActivos.seg_roles);
        }

        private void Eliminar()
        {
            if (DgvDatos.SelectedCells.Count > 0)
            {
                int LiniaID = DgvDatos.SelectedCells[0].RowIndex;
                DataGridViewCheckBoxCell ChkCelda = DgvDatos.Rows[LiniaID].Cells["Selecion"] as DataGridViewCheckBoxCell;

                if (ChkCelda?.Value is true)
                {
                    int id = ObtenerID(LiniaID);

                    DialogResult resultado = MessageBox.Show($"¿Está seguro de eliminar este {(BtnUsuarios.Checked ? "Usuario" : "Rol")}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        try
                        {
                            if (BtnUsuarios.Checked && D_ParametrosActivos.seg_usuarios == true)
                                nUsuario.EliminarUsuario(id);
                            else if (BtnRoles.Checked && D_ParametrosActivos.seg_roles == true)
                                nRoles.EliminarRol(id);
                            else
                            {
                                MessageBox.Show("Permisos Insuficientes", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
            }
        }

        private int ObtenerID(int LiniaID)
        {
            int id = -1;
            if (BtnUsuarios.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["UsuarioID"].Value;
            else if (BtnRoles.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["RolID"].Value;
            return id;
        }

        private void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }
        void filtro()
        {
            string filtro = TxtFiltro.Text.ToLower();

            if (DgvDatos.DataSource is List<object> dataSource)
            {
                if (string.IsNullOrWhiteSpace(filtro))
                {
                    Recargar();
                }
                else
                {
                    // Filtrar la lista de objetos según el filtro ingresado
                    var resultadoFiltro = dataSource.Where(item =>
                    {
                        var properties = item.GetType().GetProperties();
                        foreach (var property in properties)
                        {
                            var value = property.GetValue(item);
                            if (value != null && value.ToString().ToLower().Contains(filtro))
                            {
                                return true;
                            }
                        }
                        return false;
                    }).ToList();

                    DgvDatos.DataSource = resultadoFiltro;
                }
            }
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (BtnMenu.Checked == false)
            {
                PnlSubMenu.Visible = false;
            }
            else
            {
                PnlSubMenu.Visible = true;
            }
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }
        private void CerrarSesion()
        {
            // Pregunta al usuario si está seguro de cerrar sesión
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (login == null || login.IsDisposed)
                {
                    login = new V_Login();
                }

                login.Show();
                inicio.Close();
            }
        }

        private void BtnMyUsuario_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Usuario(D_ParametrosActivos.UsuarioID, true), inicio, true);
            BtnMenu.Checked = false;
        }

        private void BTNMANUEAL_Click(object sender, EventArgs e)
        {
            string Ruta = "Manual de uso Grupo 1.pdf";
            Process.Start(Ruta);
        }
    }
}
