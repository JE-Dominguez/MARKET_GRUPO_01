using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocio;
using Capa_Negocios;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Detalle : Form
    {
        private bool formCargado = false;
        private int? ID;
        private int? IDd;

        private readonly N_PEDIDO nPedido;
        private readonly N_Productos nProductos;
        private readonly N_PedidoDetalle nPedidoDet;
        public V_Detalle(int? iD = null, int? iDd = null)
        {
            InitializeComponent();
            nProductos = new N_Productos();
            nPedido = new N_PEDIDO();
            nPedidoDet = new N_PedidoDetalle();
            ID = iD;
            IDd = iDd;

            if (iDd != null)
            {
                TxtId.Text = iDd.ToString();
                CargarDatosCliente();
            }
            if (iD != null) { Cargar(); }
        }

        private void Detalle_Load(object sender, EventArgs e)
        {
            cargarDGVProductos();
            formCargado = false;
        }
        private void cargarDGVProductos()
        {
            var productos = nProductos.ObtenerProductos();
            var listaPersonalizada = from r in productos
                                     select new
                                     {
                                         ID = r.ProductoId,
                                         r.Nombre,
                                         r.Codigo,
                                         Unidad = r.UnidadMedida.Descripcion,
                                         Porciento = r.Impuestos.Porcentaje,
                                         CodigoIVA = r.Impuestos.Codigo,
                                         Precio = r.PrecioCompra
                                     };

            DgvProductos.DataSource = listaPersonalizada.ToList();
        }
        private void Guardar()
        {
            string pedidoDetId = TxtPedidoDetId.Text;
            string Cantidad = TxtCantidad.Text;
            if (string.IsNullOrEmpty(TxtIdPRODCUTO.Text) || string.IsNullOrWhiteSpace(TxtIdPRODCUTO.Text))
            {
                errorProvider1.SetError(TxtIdPRODCUTO, "Debe seleccionar un producto");
                return;
            }
            if (string.IsNullOrEmpty(Cantidad) || string.IsNullOrWhiteSpace(Cantidad))
            {
                errorProvider1.SetError(TxtCantidad, "Debe colocar la cantida que desea");
                return;
            }
            if (TxtPedidoDetId.Text == "")
            {
                pedidoDetId = "0";
            }
            var detalle = new PedidoDetalle();
            if (int.Parse(pedidoDetId) != 0)
            {
                detalle.PedidoDetalleId = int.Parse(pedidoDetId);
            }

            detalle.PedidoId = int.Parse(TxtId.Text);
            detalle.ProductoId = int.Parse(TxtIdPRODCUTO.Text);
            detalle.Precio = decimal.Parse(TxtPrecio.Text);
            detalle.Cantidad = decimal.Parse(Cantidad);
            detalle.Total = decimal.Parse(TxtTotal.Text);
            detalle.Subtotal = decimal.Parse(TxtSubTotal.Text);
            detalle.Descripcion = TxtNombre.Text;
            detalle.Descuento = decimal.Parse(TxtDescuento.Text);
            detalle.CodigoProducto = TXTCodigoProd.Text;
            detalle.FechaPedido = DtpFechaPedido.Value;
            detalle.Impuesto = decimal.Parse(TxtImpuesto.Text);

            var pedido = new Pedido();
            pedido.PedidoId = int.Parse(TxtId.Text);
            pedido.ClienteId = int.Parse(txtIDcliente.Text);
            pedido.FechaPedido = DtpFechaPedido.Value;
            pedido.Estado = true;

            pedido.Subtotal = decimal.Parse(LblSubTotal.Text); ;
            pedido.Descuento = decimal.Parse(lbldescuento.Text); ;
            pedido.Impuesto = decimal.Parse(lblImpuesto.Text); ;
            pedido.Total = decimal.Parse(LblTotalPago.Text); ;


            nPedido.GuardarPedido(pedido);
            nPedidoDet.GuardarPedidoDetalle(detalle);
        }


        private void ObtenerDatos()
        {
            if (TxtDescuentoPorciento.Text != "")
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de agregar este producto al pedido?", "Confirmar Agregar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    TxtIdPRODCUTO.Text = DgvProductos.CurrentRow.Cells["ID"].Value.ToString();
                    TXTCodigoProd.Text = DgvProductos.CurrentRow.Cells["Codigo"].Value.ToString();
                    TxtNombre.Text = DgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                    TxtPrecio.Text = DgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                    TxtImpuestoPorciento.Text = DgvProductos.CurrentRow.Cells["Porciento"].Value.ToString();
                }
            }
            else
            {
                MessageBox.Show("Debe verificar que el cliente esté seleccionado correctamente. En caso de estar seleccionado, asegúrese de que el cliente pertenezca a algún grupo de descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Cargar()
        {
            var detalle = nPedidoDet.ObtenerPedidoDetalle().FirstOrDefault(g => g.PedidoDetalleId == ID);
            if (detalle != null)
            {
                TxtId.Text = detalle.PedidoId.ToString();
                TxtPedidoDetId.Text = detalle.PedidoDetalleId.ToString();
                TxtIdPRODCUTO.Text = detalle.ProductoId.ToString();
                TxtPrecio.Text = detalle.Precio.ToString();
                TxtCantidad.Text = detalle.Cantidad.ToString();
                TxtTotal.Text = detalle.Total.ToString();
                TxtSubTotal.Text = detalle.Subtotal.ToString();
                TxtNombre.Text = detalle.Descripcion;
                TxtDescuento.Text = detalle.Descuento.ToString();
                TXTCodigoProd.Text = detalle.CodigoProducto;
                DtpFechaPedido.Value = detalle.FechaPedido;
                TxtImpuesto.Text = detalle.Impuesto.ToString();
                TxtImpuestoPorciento.Text = detalle.Productos.Impuestos.Porcentaje.ToString();
                CargarDatosCliente();


            }

        }
        private void CargarDatosCliente()
        {
            var pedido = nPedido.ObtenerPedidos().FirstOrDefault(g => g.PedidoId == int.Parse(TxtId.Text));
            if (pedido != null)
            {
                TxtDescuentoPorciento.Text = pedido.Clientes.grupoDescuento.Porcentaje.ToString();
                txtIDcliente.Text = pedido.ClienteId.ToString();
                DtpFechaPedido.Value = pedido.FechaPedido;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Seguro que deseas Agregar este Producto al Pedido?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                TxtCantidad_TextChanged(sender, e);
                Guardar();
                this.Close();
            }
        }

        private void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (formCargado)
            {
                decimal SubtotalPedido = 0;
                decimal DescuentoPedido = 0;
                decimal ImpuestoPedido = 0;
                decimal TotalPedido = 0;

                decimal SubtotalPedidoD = 0;
                decimal DescuentoPedidoD = 0;
                decimal ImpuestoPedidoD = 0;
                decimal TotalPedidoD = 0;


                var detalle = nPedidoDet.ObtenerPedidoDetalle().FirstOrDefault(g => g.PedidoDetalleId == int.Parse(TxtPedidoDetId.Text));
                var pedido = nPedido.ObtenerPedidos().FirstOrDefault(g => g.PedidoId == int.Parse(TxtId.Text));

                if (pedido != null)
                {
                    SubtotalPedido = pedido.Subtotal;
                    DescuentoPedido = pedido.Descuento;
                    TotalPedido = pedido.Total;
                    ImpuestoPedido = pedido.Impuesto;
                }
                if (detalle != null)
                {
                    SubtotalPedidoD = detalle.Subtotal;
                    DescuentoPedidoD = detalle.Descuento;
                    TotalPedidoD = detalle.Total;
                    ImpuestoPedidoD = detalle.Impuesto;
                }

                decimal Cantidad = 0;
                if (TxtIdPRODCUTO.Text != "")
                {
                    if (!string.IsNullOrEmpty(TxtCantidad.Text) && decimal.TryParse(TxtCantidad.Text, out Cantidad))
                    {
                        if (TxtCantidad.Text == "")
                        {
                            TxtCantidad.Text = "0";
                        }
                        decimal IvaPorciento = decimal.Parse(TxtImpuestoPorciento.Text) / 100;
                        decimal PorcientoDesc = decimal.Parse(TxtDescuentoPorciento.Text) / 100;
                        decimal Precio = decimal.Parse(TxtPrecio.Text);
                        decimal SubtotalProducto = Precio * Cantidad;
                        decimal DescuentoProducto = SubtotalProducto * PorcientoDesc;
                        decimal ImpuestoProducto = (SubtotalProducto - DescuentoProducto) * IvaPorciento;
                        decimal TotalProducto = (SubtotalProducto - DescuentoProducto) + ImpuestoProducto;

                        TxtSubTotal.Text = SubtotalProducto.ToString("0.00");
                        TxtImpuesto.Text = ImpuestoProducto.ToString("0.00");
                        TxtDescuento.Text = DescuentoProducto.ToString("0.00");
                        TxtTotal.Text = TotalProducto.ToString("0.00");
                    }

                    decimal DescuentoOP = (DescuentoPedido - DescuentoPedidoD) + decimal.Parse(TxtDescuento.Text);
                    decimal ImpuestoOP = (ImpuestoPedido - ImpuestoPedidoD) + decimal.Parse(TxtImpuesto.Text);
                    decimal SubTotalOP = (SubtotalPedido - SubtotalPedidoD) + decimal.Parse(TxtSubTotal.Text);
                    decimal TotalOP = (TotalPedido - TotalPedidoD) + decimal.Parse(TxtTotal.Text);

                    lbldescuento.Text = DescuentoOP.ToString("0.00");
                    lblImpuesto.Text = ImpuestoOP.ToString("0.00");
                    LblSubTotal.Text = SubTotalOP.ToString("0.00");
                    LblTotalPago.Text = TotalOP.ToString("0.00");
                }

            }
        }


        private void V_Detalle_Shown(object sender, EventArgs e)
        {
            formCargado = true;
        }

        private void DgvProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DgvProductos.Columns[e.ColumnIndex].Name == "Agregar")
            {
                ObtenerDatos();
            }
        }

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            TxtCantidad_TextChanged(sender, e);
        }
    }
}
