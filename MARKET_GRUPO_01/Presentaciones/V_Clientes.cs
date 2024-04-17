using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Clientes : Form
    {
        private V_Login login = null;
        private readonly AbrirForm AF;
        private readonly V_Inicio inicio;
        private readonly N_Clientes ncliente;
        private readonly N_GrupoDescuento nGrupoDescuento;
        private readonly N_CondicionPago nCondicionPago;
        private string tituloListado;
        private string TextoBoton;

        public V_Clientes(V_Inicio ini)
        {
            InitializeComponent();
            inicio = ini;
            AF = new AbrirForm();
            ncliente = new N_Clientes();
            nGrupoDescuento = new N_GrupoDescuento();
            nCondicionPago = new N_CondicionPago();
            tituloListado = "LISTADO CLIENTES";
            TextoBoton = "NUEVO CLIENTE";
        }

        private void V_Clientes_Load(object sender, EventArgs e)
        {
            LblFecha.Text = DateTime.Now.ToString("dd MMMM, yyyy");
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

        private void BtnClientes_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO CLIENTE";
            tituloListado = "LISTADO CLIENTES";
            Recargar();
        }

        private void BtnGrupoDescuento_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO GRUPO DESCUENTO";
            tituloListado = "LISTADO GRUPOS DESCUENTO";
            Recargar();
        }

        private void BtnCondicionPago_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVA CONDICION PAGO";
            tituloListado = "LISTADO CONDICIONES PAGO";
            Recargar();
        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvDatos);
        }
        private void Recargar()
        {
            DgvDatos.DataSource = null;
            if (BtnClientes.Checked)
            {
                N_Clientes nClientes = new N_Clientes();
                DgvDatos.DataSource = nClientes.ObtenerClientesGrid();
            }

            else if (BtnGrupoDescuento.Checked)
            {
                N_GrupoDescuento nGrupo = new N_GrupoDescuento();
                DgvDatos.DataSource = nGrupo.ObtenerGruposDescuento();
            }

            else if (BtnCondicionPago.Checked)
            {
                N_CondicionPago nCondicion = new N_CondicionPago();
                DgvDatos.DataSource = nCondicion.ObtenerCondicionesPago();
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

                    if (BtnClientes.Checked)
                        AF.VentanaEmergente(new V_Cliente(id), inicio, D_ParametrosActivos.cl_clientes);
                    else if (BtnGrupoDescuento.Checked)
                        AF.VentanaEmergente(new V_GrupoDescuento(id), inicio, D_ParametrosActivos.cl_grupodescuentos);
                    else if (BtnCondicionPago.Checked)
                        AF.VentanaEmergente(new V_CondicionPago(id), inicio, D_ParametrosActivos.cl_condicionpago);
                }
            }
        }

        private void Nuevo()
        {
            if (BtnClientes.Checked)
                AF.VentanaEmergente(new V_Cliente(), inicio, D_ParametrosActivos.cl_clientes);
            else if (BtnGrupoDescuento.Checked)
                AF.VentanaEmergente(new V_GrupoDescuento(), inicio, D_ParametrosActivos.cl_grupodescuentos);
            else if (BtnCondicionPago.Checked)
                AF.VentanaEmergente(new V_CondicionPago(), inicio, D_ParametrosActivos.cl_condicionpago);
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

                    DialogResult resultado = MessageBox.Show($"¿Está seguro de eliminar este {(BtnClientes.Checked ? "cliente" : (BtnGrupoDescuento.Checked ? "grupo descuento" : "condicion de pago"))}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        if (BtnClientes.Checked && D_ParametrosActivos.cl_clientes == true)
                            ncliente.EliminarCliente(id);
                        else if (BtnGrupoDescuento.Checked && D_ParametrosActivos.cl_grupodescuentos == true)
                            nGrupoDescuento.EliminarGrupoDescuento(id);
                        else if (BtnCondicionPago.Checked && D_ParametrosActivos.cl_condicionpago == true)
                            nCondicionPago.EliminarCondicionPago(id);
                        else
                        {
                            MessageBox.Show("Permisos Insuficientes", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private int ObtenerID(int LiniaID)
        {
            int id = -1;
            if (BtnClientes.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["ClienteId"].Value;
            else if (BtnGrupoDescuento.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["GrupoDescuentoId"].Value;
            else if (BtnCondicionPago.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["CondicionPagoId"].Value;
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
                                return true; // Devolver verdadero si se encuentra una coincidencia en cualquier propiedad
                            }
                        }
                        return false; // Si no se encuentra ninguna coincidencia en ninguna propiedad, devolver falso
                    }).ToList();

                    // Asignar los resultados del filtro al origen de datos del DataGridView
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

        private void BTNCERRAR_Click(object sender, EventArgs e)
        {
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
