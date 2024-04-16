using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_PedidoEdit : Form
    {
        private int? ID;
        private readonly N_PEDIDO nPedido;
        private readonly N_Clientes nClientes;

        public V_PedidoEdit(int? iD = null)
        {
            InitializeComponent();
            nPedido = new N_PEDIDO();
            nClientes = new N_Clientes();
            ID = iD;

            if (iD != null)
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            var pedido = nPedido.ObtenerPedidos().FirstOrDefault(g => g.PedidoId == ID);
            if (pedido != null)
            {
                LblTitulo.Text = "Editar Pedido";
                TxtIdPedido.Text = pedido.PedidoId.ToString();
                CmbClientes.SelectedValue = pedido.ClienteId;
                DtpFechaPedido.Value = pedido.FechaPedido;
                ChkActivo.Checked = pedido.Estado;
                TxtSubTotal.Text = pedido.Subtotal.ToString();
                TxtDescuento.Text = pedido.Descuento.ToString();
                TxtImpuesto.Text = pedido.Impuesto.ToString();
                TxtTotal.Text = pedido.Total.ToString();
            }
        }

        private void CargarComboClientes()
        {
            try
            {
                CmbClientes.DataSource = nClientes.ObtenerClientesCmb();
                CmbClientes.DisplayMember = "Cliente";
                CmbClientes.ValueMember = "ClienteId";
            }
            catch { }
        }

        private void GuardarPedido()
        {
            string pedidoId = TxtIdPedido.Text;
            if (string.IsNullOrEmpty(TxtIdPedido.Text))
            {
                pedidoId = "0";
            }

            var pedido = new Pedido
            {
                PedidoId = int.Parse(pedidoId),
                ClienteId = Convert.ToInt32(CmbClientes.SelectedValue),
                FechaPedido = DtpFechaPedido.Value,
                Estado = ChkActivo.Checked,
                Subtotal = decimal.Parse(TxtSubTotal.Text),
                Descuento = decimal.Parse(TxtDescuento.Text),
                Impuesto = decimal.Parse(TxtImpuesto.Text),
                Total = decimal.Parse(TxtTotal.Text)
            };

            nPedido.GuardarPedido(pedido);
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            TxtIdPedido.Text = string.Empty;
            CmbClientes.SelectedIndex = -1;
            DtpFechaPedido.Value = DateTime.Now;
            ChkActivo.Checked = false;
            TxtSubTotal.Text = string.Empty;
            TxtDescuento.Text = string.Empty;
            TxtImpuesto.Text = string.Empty;
            TxtTotal.Text = string.Empty;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPedido();
        }

        private void V_Detalles_Load(object sender, EventArgs e)
        {
            CargarComboClientes();
        }
    }
}
