using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Clientes : Form
    {
        AbrirForm AF;
        public V_Inicio inicio;
        N_Clientes ncliente;
        N_GrupoDescuento nGrupoDescuento;
        N_CondicionPago nCondicionPago;
        public V_Clientes(V_Inicio ini)
        {
            InitializeComponent();
            AF = new AbrirForm();
            ncliente = new N_Clientes();
            nGrupoDescuento = new N_GrupoDescuento();
            nCondicionPago = new N_CondicionPago();
            inicio = ini;
        }
        void SeleccionarSoloUno(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell otherChk = (DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex];
                    otherChk.Value = (row.Index == e.RowIndex);
                }
            }
        }
        void HabilitarSoloColumnaSeleccion(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.ReadOnly = true;
            }
            dgv.Columns[0].ReadOnly = false;
        }
        void cargar()
        {

            if (BtnClientes.Checked)
            {
                HabilitarSoloColumnaSeleccion(DgvClientes);
                DgvClientes.DataSource = ncliente.ObtenerClientes();
            }
            else if (BtnCondicionPago.Checked)
            {
                HabilitarSoloColumnaSeleccion(DgvCondicionesPago);
                DgvCondicionesPago.DataSource = nCondicionPago.ObtenerCondicionesPago();
            }
            else if (BtnGrupoDescuento.Checked)
            {
                HabilitarSoloColumnaSeleccion(DgvGruposDesscuento);
                DgvGruposDesscuento.DataSource = nGrupoDescuento.ObtenerGruposDescuento();
            }
        }
        void ConsultarClinete(int Idcliente)
        {
            V_Cliente vcliente = new V_Cliente();
            var cliente = ncliente.ObtenerClientes().FirstOrDefault(g => g.ClienteId == Idcliente);
            if (cliente != null)
            {
                vcliente.LblTitulo.Text = "Editar cliente";
                vcliente.TxtIdCliente.Text = cliente.ClienteId.ToString();
                vcliente.TxtNombre.Text = cliente.Nombres;
                vcliente.TxtApellido.Text = cliente.Apellidos;
                vcliente.TxtCodigo.Text = cliente.Codigo;
                vcliente.ChkActivo.Checked = cliente.Estado;
                vcliente.CmbGrupoDescuento.SelectedValue = cliente.GrupoDescuentoId;
                vcliente.CmbCondicoonPAGO.SelectedValue = cliente.CondicionPagoId;
                AF.VentanaEmergente(vcliente, inicio, true);
            }
        }
        void ConsultargrupoDescuento(int grupoDescuentoID)
        {
            V_GrupoDescuento vGrupoDescuento = new V_GrupoDescuento();
            var grupoDescuento = nGrupoDescuento.ObtenerGruposDescuento().FirstOrDefault(g => g.GrupoDescuentoId == grupoDescuentoID);
            if (grupoDescuento != null)
            {
                vGrupoDescuento.LblTitulo.Text = "Editar Grupo Descuento";
                vGrupoDescuento.TxtIdGrupoDescuento.Text = grupoDescuento.GrupoDescuentoId.ToString();
                vGrupoDescuento.TxtDescipcion.Text = grupoDescuento.Descripcion;
                vGrupoDescuento.TxtCodigo.Text = grupoDescuento.Codigo;
                vGrupoDescuento.TxtPorcentaje.Text = grupoDescuento.Porcentaje.ToString();
                vGrupoDescuento.ChkACTIVO.Checked = grupoDescuento.Estado;
                AF.VentanaEmergente(vGrupoDescuento, inicio, true);
            }
        }
        void ConsultarCondicionPAGO(int CondicionPagoId)
        {
            V_CondicionPago vcondicionPago = new V_CondicionPago();
            var condicionPago = nCondicionPago.ObtenerCondicionesPago().FirstOrDefault(g => g.CondicionPagoId == CondicionPagoId);
            if (condicionPago != null)
            {
                vcondicionPago.LblTitulo.Text = "Editar condicionPago";
                vcondicionPago.TxtIdCondicionPAGO.Text = condicionPago.CondicionPagoId.ToString();
                vcondicionPago.TxtDescripcion.Text = condicionPago.Descripcion;
                vcondicionPago.TxtDias.Text = condicionPago.Dias.ToString();
                vcondicionPago.TxtCodigo.Text = condicionPago.Codigo;
                vcondicionPago.ChkActivo.Checked = condicionPago.Estado;
                AF.VentanaEmergente(vcondicionPago, inicio, true);
            }
        }

        private void BtnGrupoDescuento_Click(object sender, EventArgs e)
        {
            TabControlMain.SelectedTab = TabGrupoDescuento;
            cargar();
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            TabControlMain.SelectedTab = TabClientes;
            cargar();
        }

        private void BtnCondicionPago_Click(object sender, EventArgs e)
        {
            TabControlMain.SelectedTab = tabCondicionPAGO;
            cargar();
        }

        private void V_Clientes_Load(object sender, EventArgs e)
        {
            cargar();
        }
        void editar()
        {
            if (BtnClientes.Checked == true)
            {
                if (DgvClientes.SelectedCells.Count > 0)
                {
                    int rowIndex = DgvClientes.SelectedCells[0].RowIndex;
                    DataGridViewCheckBoxCell checkBoxCell = DgvClientes.Rows[rowIndex].Cells["Selecion"] as DataGridViewCheckBoxCell;

                    if (checkBoxCell?.Value is true)
                    {
                        // Obtener el ID directamente de la celda
                        if (DgvClientes.Rows[rowIndex].Cells["ClienteId"].Value is int id)
                        {
                            ConsultarClinete(id);
                        }
                    }
                }
            }
            else if (BtnCondicionPago.Checked == true)
            {
                if (DgvCondicionesPago.SelectedCells.Count > 0)
                {
                    int rowIndex = DgvCondicionesPago.SelectedCells[0].RowIndex;
                    DataGridViewCheckBoxCell checkBoxCell = DgvCondicionesPago.Rows[rowIndex].Cells["SeleccionCondicion"] as DataGridViewCheckBoxCell;

                    if (checkBoxCell?.Value is true)
                    {
                        // Obtener el ID directamente de la celda
                        if (DgvCondicionesPago.Rows[rowIndex].Cells["CondicionPagoId"].Value is int id)
                        {
                            ConsultarCondicionPAGO(id);
                        }
                    }
                }
            }
            else if (BtnGrupoDescuento.Checked == true)
            {
                if (DgvGruposDesscuento.SelectedCells.Count > 0)
                {
                    int rowIndex = DgvGruposDesscuento.SelectedCells[0].RowIndex;
                    DataGridViewCheckBoxCell checkBoxCell = DgvGruposDesscuento.Rows[rowIndex].Cells["SeleccionGrupo"] as DataGridViewCheckBoxCell;

                    if (checkBoxCell?.Value is true)
                    {
                        // Obtener el ID directamente de la celda
                        if (DgvGruposDesscuento.Rows[rowIndex].Cells["GrupoDescuentoId"].Value is int id)
                        {
                            ConsultargrupoDescuento(id);
                        }
                    }
                }
            }

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvClientes);
        }

        private void DgvGruposDesscuento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvGruposDesscuento);
        }

        private void DgvCondicionesPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvCondicionesPago);
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Cliente(), inicio, true);
        }

        private void BtnNuevoGrupoDescuento_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_GrupoDescuento(), inicio, true);
        }

        private void BtnNuevaCondicionPago_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_CondicionPago(), inicio, true);
        }
    }
}
