using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocio;
using Capa_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Pedidos : Form
    {
        private readonly AbrirForm AF;
        private readonly V_Inicio inicio;
        private readonly N_PEDIDO nPedido;
        private readonly N_Factura nFactura;
        private readonly N_FacturaDetalle nFacturaDet;
        private readonly N_PedidoDetalle nPedidoDet;
        private string tituloListado;
        private string TextoBoton;
        public V_Pedidos(V_Inicio ini)
        {
            InitializeComponent();
            inicio = ini;
            AF = new AbrirForm();
            nPedido = new N_PEDIDO();
            nPedidoDet = new N_PedidoDetalle();
            nFactura = new N_Factura();
            nFacturaDet = new N_FacturaDetalle();
            TextoBoton = "NUEVO PEDIDO";
            tituloListado = "LISTADO PEDIDOS";
            CmbPedido.SelectedValue = -1;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            Recargar();
        }

        private void V_Pedidos_Load(object sender, EventArgs e)
        {
            Recargar();
            cargarComboClinetes();
            CargarFacturas();
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Recargar();
            cargarComboClinetes();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Editar();
            Recargar();
            cargarComboClinetes();
        }

        private void BtnEiminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Recargar();
            cargarComboClinetes();
        }

        private void BtnPedidos_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO PEDIDO";
            tituloListado = "LISTADO PEDIDOS";
            Recargar();
            cargarComboClinetes();
            BtnNuevo.Visible = true;
        }

        private void BtnPedidosDet_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO DETALLE";
            tituloListado = "LISTADO DETALLES PEDIDOS";
            Recargar();
            cargarComboClinetes();
            BtnNuevo.Visible = true;
        }
        private void BtnFactura_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVA FACTURA";
            tituloListado = "LISTADO FACTURAS";
            Recargar();
            CargarFacturas();
            BtnNuevo.Visible = true;
        }

        private void BtnDetalleFact_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO DETALLE FACTURA";
            tituloListado = "LISTADO DETALLES FACTURAS";
            Recargar();
            CargarFacturas();
            BtnNuevo.Visible = false;
        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvDatos);
        }
        private void Recargar()
        {
            DgvDatos.DataSource = null;
            if (BtnPedidos.Checked)
            {
                TxtFiltro.Visible = true;
                CmbPedido.Visible = false;
                CmbFcturas.Visible = false;
                N_PEDIDO nPedido = new N_PEDIDO();
                DgvDatos.DataSource = nPedido.ObtenerPedidosGrid();
            }

            else if (BtnPedidosDet.Checked)
            {
                TxtFiltro.Visible = false;
                CmbPedido.Visible = true;
                CmbFcturas.Visible = false;

                int ID = Convert.ToInt32(CmbPedido.SelectedValue);

                N_PedidoDetalle nPedidoDet = new N_PedidoDetalle();

                DgvDatos.DataSource = nPedidoDet.ObtenerPedidoDetalleGrid(ID);
            }
            else if (BtnFactura.Checked)
            {
                TxtFiltro.Visible = true;
                CmbPedido.Visible = false;
                CmbFcturas.Visible = false;
                N_Factura nFactura = new N_Factura();
                DgvDatos.DataSource = nFactura.ObtenerFacturaGrid();
            }
            else if (BtnDetalleFact.Checked)
            {
                TxtFiltro.Visible = false;
                CmbPedido.Visible = false;
                CmbFcturas.Visible = true;

                int ID = Convert.ToInt32(CmbFcturas.SelectedValue);
                N_FacturaDetalle nFacturaDet = new N_FacturaDetalle();

                DgvDatos.DataSource = nFacturaDet.ObtenerFacturaDetalleGrid(ID);
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

                    if (BtnPedidos.Checked)
                        AF.VentanaEmergente(new V_PedidoEdit(id), inicio, true);
                    else if (BtnPedidosDet.Checked)
                        AF.VentanaEmergente(new V_Detalle(id), inicio, true);
                }
            }
        }

        private void Nuevo()
        {
            int idnulo = 0;
            int id = Convert.ToInt32(CmbPedido.SelectedValue);
            if (BtnPedidos.Checked)
                AF.VentanaEmergente(new V_Pedido(), inicio, true);
            else if (BtnPedidosDet.Checked)
                AF.VentanaEmergente(new V_Detalle(idnulo, id), inicio, true);
            else if (BtnFactura.Checked)
                AF.VentanaEmergente(new V_Factura(), inicio, true);
        }
        private void cargarComboClinetes()
        {
            try
            {
                N_PEDIDO nPedido = new N_PEDIDO();
                CmbPedido.SelectedValue = -1;
                CmbPedido.DataSource = nPedido.ObtenerPedidosGrid();
                CmbPedido.DisplayMember = "PedidoId";
                CmbPedido.ValueMember = "PedidoId";
            }
            catch { }
        }
        private void CargarFacturas()
        {
            try
            {
                N_Factura nFactura = new N_Factura();
                CmbFcturas.SelectedValue = -1;
                CmbFcturas.DataSource = nFactura.ObtenerFactura();
                CmbFcturas.DisplayMember = "FacturaId";
                CmbFcturas.ValueMember = "FacturaId";
            }
            catch { }
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

                    DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea resgistro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        try
                        {
                            if (BtnPedidos.Checked)
                                EliminarPedido(id);
                            else if (BtnPedidosDet.Checked)
                                Actualizar(id);
                            else if (BtnFactura.Checked)
                                EliminarFactura(id);

                        }
                        catch (Exception ex) { MessageBox.Show("Debe eliminar cualquier registros relacionado con este antes de eliminarlo." + ex.Message, "Eliminando Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                }
            }
        }
        void EliminarFactura(int ID)
        {
            var facturaDetalles = nFacturaDet.ObtenerFacturaDetalle().Where(g => g.FacturaId == ID).ToList();

            if (facturaDetalles.Any())
            {
                // Elimina los detalles de la factura uno por uno
                foreach (var detalle in facturaDetalles.ToList())
                {
                    nFacturaDet.EliminarFacturaDetalle(detalle.FacturaDetalleId);
                }

                // Verifica si ya no hay detalles de factura para esa factura
                if (!nFacturaDet.ObtenerFacturaDetalle().Any(g => g.FacturaId == ID))
                {
                    // Si no hay detalles de factura para esa factura, elimina la factura
                    nFactura.EliminarFactura(ID);
                }
            }
            else
            {
                nFactura.EliminarFactura(ID);
            }
        }


        void EliminarPedido(int ID)
        {
            var PedidosS = nPedidoDet.ObtenerPedidoDetalle().Where(g => g.PedidoId == ID).ToList();
            var facturas = nFactura.ObtenerFactura().Where(g => g.PedidoId == ID).ToList();

            if (PedidosS.Any())
            {
                foreach (var detalle in PedidosS.ToList())
                {
                    nPedidoDet.EliminarPedidoDetalle(detalle.PedidoDetalleId);
                }
            }

            if (facturas.Any())
            {
                foreach (var detalle in facturas.ToList())
                {
                    EliminarFactura(detalle.FacturaId);
                }
            }

            if (!nPedidoDet.ObtenerPedidoDetalle().Any(g => g.PedidoId == ID))
            {
                nPedido.EliminarPedido(ID);
            }
        }



        private int ObtenerID(int LiniaID)
        {
            int id = -1;
            if (BtnPedidos.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["PedidoId"].Value;
            else if (BtnPedidosDet.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["PedidoDetalleId"].Value;
            else if (BtnFactura.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["FacturaId"].Value;
            else if (BtnDetalleFact.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["FacturaDetalleId"].Value;
            return id;
        }

        private void Actualizar(int ID)
        {
            N_PedidoDetalle nPedidoDet = new N_PedidoDetalle();
            N_PEDIDO nPedido = new N_PEDIDO();
            var pedidoDet = nPedidoDet.ObtenerPedidoDetalle().FirstOrDefault(g => g.PedidoDetalleId == ID);
            var pedido = nPedido.ObtenerPedidos().FirstOrDefault(g => g.PedidoId == pedidoDet.PedidoId);
            if (pedido == null)
            {
                MessageBox.Show("No se encontró el pedido especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pedido.ClienteId = pedido.ClienteId;
            pedido.FechaPedido = pedido.FechaPedido;
            pedido.Subtotal = pedido.Subtotal - pedidoDet.Subtotal;
            pedido.Descuento = pedido.Descuento - pedidoDet.Descuento;
            pedido.Impuesto = pedido.Impuesto - pedidoDet.Impuesto;
            pedido.Total = pedido.Total - pedidoDet.Total;
            pedido.Estado = pedido.Estado;
            nPedido.GuardarPedido(pedido);
            nPedidoDet.EliminarPedidoDetalle(ID);
        }



        private void CmbPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recargar();
        }

        private void CmbFcturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Recargar();
        }
    }
}
