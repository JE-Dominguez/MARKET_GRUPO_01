using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Factura : Form
    {
        private int? ID;
        private bool formCargado = false;
        private readonly N_Factura nFactura;
        private readonly N_PEDIDO nPedido;
        private readonly N_PedidoDetalle nPedidoDet;
        public V_Factura(int? iD = null)
        {
            InitializeComponent();
            nFactura = new N_Factura();
            nPedido = new N_PEDIDO();
            nPedidoDet = new N_PedidoDetalle();
            ID = iD;
        }
        private void CargarClientes()
        {
            CmbPedido.DataSource = nPedido.ObtenerPedidos();
            CmbPedido.DisplayMember = "PedidoId";
            CmbPedido.ValueMember = "PedidoId";
        }

        private void CmbPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formCargado && CmbPedido.SelectedIndex != -1 && CmbPedido.DataSource != null)
            {
                int valor = Convert.ToInt32(CmbPedido.SelectedValue);
                cargardatosDGV(valor);
                ActualizarTotales();
                var dato = nPedido.ObtenerPedidos().FirstOrDefault(d => d.PedidoId == valor);
                if (dato != null)
                {
                    txtIDcliente.Text = dato.ClienteId.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún dato con el valor seleccionado.");
                }
            }
        }
        private void ActualizarTotales()
        {
            decimal Descuebto = 0;
            decimal Total = 0;
            decimal SubTotal = 0;
            foreach (DataGridViewRow fila in DgvDatos.Rows)
            {
                Descuebto += decimal.Parse(fila.Cells["Descuento"].Value.ToString());
                SubTotal += decimal.Parse(fila.Cells["Subtotal"].Value.ToString());
                Total += decimal.Parse(fila.Cells["Total"].Value.ToString());

            }
            LblDescuento.Text = Descuebto.ToString();
            LblTotalPago.Text = Total.ToString();
            LblSubTotal.Text = SubTotal.ToString();
        }
        private void cargardatosDGV(int idPedido)
        {
            var detalles = nPedidoDet.ObtenerPedidoDetalle()
                            .Where(u => u.PedidoId == idPedido)
                            .Select(u => new { u.ProductoId, u.Precio, u.Descuento, u.Subtotal, u.Total })
                            .ToList();
            DgvDatos.DataSource = detalles;

        }
        private void Guardar()
        {
            if (DgvDatos.Rows.Count > 0)
            {
                Factura factura = new Factura();
                factura.ClienteId = int.Parse(txtIDcliente.Text);
                factura.PedidoId = Convert.ToInt32(CmbPedido.SelectedValue);
                factura.FechaCreacion = DateTime.Now;
                factura.FechaFactura = DateTime.Now;
                factura.Estado = ChkActivo.Checked;
                decimal Descuebto = 0;
                decimal Total = 0;
                decimal SubTotal = 0;

                List<FacturaDetalle> detalle = new List<FacturaDetalle>();

                foreach (DataGridViewRow fila in DgvDatos.Rows)
                {
                    Descuebto += decimal.Parse(fila.Cells["Descuento"].Value.ToString());
                    SubTotal += decimal.Parse(fila.Cells["Subtotal"].Value.ToString());
                    Total += decimal.Parse(fila.Cells["Total"].Value.ToString());

                    FacturaDetalle det = new FacturaDetalle();
                    det.FacturaId = factura.FacturaId;
                    det.Factura = factura;
                    det.FechaCreacion = DateTime.Now;
                    det.FechaFactura = DateTime.Now;
                    det.ProductoId = int.Parse(fila.Cells["ProductoId"].Value.ToString());
                    det.Precio = decimal.Parse(fila.Cells["Precio"].Value.ToString());
                    det.Total = decimal.Parse(fila.Cells["Total"].Value.ToString());
                    det.Subtotal = decimal.Parse(fila.Cells["Subtotal"].Value.ToString());
                    det.Descuento = decimal.Parse(fila.Cells["Descuento"].Value.ToString());
                    detalle.Add(det);
                }
                factura.Total = Total;
                factura.Subtotal = SubTotal;
                factura.Descuento = Descuebto;

                nFactura.CrearFactura(factura, detalle);
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no se han agreagdo detalles a la Factura", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void V_Factura_Load(object sender, EventArgs e)
        {
            CargarClientes();
            formCargado = false;
        }

        private void V_Factura_Shown(object sender, EventArgs e)
        {
            formCargado = true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
    }
}
