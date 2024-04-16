using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocio;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Pedido : Form
    {
        private bool formCargado = false;
        private N_Clientes nClientes;
        private N_Productos nProductos;
        private N_PEDIDO nPedido;
        private N_Factura nFactura;

        public V_Pedido()
        {
            InitializeComponent();
            nProductos = new N_Productos();
            nClientes = new N_Clientes();
            nPedido = new N_PEDIDO();
            nFactura = new N_Factura();
        }

        private void V_Pedido_Load(object sender, EventArgs e)
        {
            CargarFormulario();
            formCargado = false;
        }

        private void CargarFormulario()
        {
            CargarClientes();
            ConfigurarDGVProductos();
            SubTotalesEn0();
            CmbCliente.SelectedIndex = -1;
        }

        private void CargarClientes()
        {
            CmbCliente.DataSource = nClientes.ObtenerClientesCmb();
            CmbCliente.DisplayMember = "Cliente";
            CmbCliente.ValueMember = "ClienteId";
        }

        private void ConfigurarDGVProductos()
        {
            var productos = nProductos.ObtenerProductos();
            var listaPersonalizada = from r in productos
                                     select new
                                     {
                                         ID = r.ProductoId,
                                         r.Nombre,
                                         r.Codigo,
                                         Unidad = r.UnidadMedida.Descripcion,
                                         UnidadID = r.UnidadMedidaId,
                                         Porciento = r.Impuestos.Porcentaje,
                                         CodigoIVA = r.Impuestos.Codigo,
                                         Precio = r.PrecioCompra
                                     };

            DgvProductos.DataSource = listaPersonalizada.ToList();
            DgvProductos.EditingControlShowing += DgvProductos_EditingControlShowing;
            ConfigurarColumnasDGV();
        }

        private void ConfigurarColumnasDGV()
        {
            DgvProductos.Columns["Agregar"].DisplayIndex = 9;
            DgvProductos.Columns["Cantidad"].DisplayIndex = 7;
            DgvProductos.Columns["SubTotal"].DisplayIndex = 8;
            DgvProductos.Columns["Precio"].DisplayIndex = 6;
            DgvProductos.Columns["ID"].Width = 20;
            DgvProductos.Columns["Cantidad"].DefaultCellStyle.BackColor = Color.DarkGray;
            DgvProductos.Columns["Agregar"].DefaultCellStyle.BackColor = Color.CornflowerBlue;

            foreach (DataGridViewRow row in DgvProductos.Rows)
            {
                row.Cells["Cantidad"].Style.BackColor = Color.DarkGray;
                row.Cells["Agregar"].Style.BackColor = Color.CornflowerBlue;
            }

            DgvDatos.Columns["Eliminar"].DefaultCellStyle.BackColor = Color.Salmon;
            foreach (DataGridViewRow row in DgvDatos.Rows)
            {
                row.Cells["Eliminar"].Style.BackColor = Color.Salmon;
            }
        }

        private void SubTotalesEn0()
        {
            foreach (DataGridViewRow fila in DgvProductos.Rows)
            {
                DataGridViewTextBoxCell celdaTotal = fila.Cells["SubTotal"] as DataGridViewTextBoxCell;
                if (celdaTotal != null)
                {
                    celdaTotal.Value = "0";
                }
            }
        }

        private void DgvProductos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvProductos.CurrentCell.ColumnIndex == DgvProductos.Columns["Cantidad"].Index && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.KeyPress -= TextBox_KeyPress;
                textBox.KeyPress += TextBox_KeyPress;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void DgvProductos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvProductos.Columns["Agregar"].Index && e.RowIndex != -1)
            {
                DataGridViewRow fila = DgvProductos.Rows[e.RowIndex];
                DataGridViewTextBoxCell CeldaCantidad = fila.Cells["Cantidad"] as DataGridViewTextBoxCell;
                string valorTextBox = CeldaCantidad.Value != null ? CeldaCantidad.Value.ToString() : "";

                if (string.IsNullOrWhiteSpace(valorTextBox))
                {
                    MessageBox.Show("Porfavor, Antes de agregar el producto debe agregar la cantidad deseada", "Seleccione la cantidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        DgvProductos.CurrentCell = CeldaCantidad;
                        DgvProductos.BeginEdit(true);
                    });
                }
                else
                {
                    ObtenerDetalles(CeldaCantidad);
                }
            }
        }

        private void DgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string ColCantidad = "Cantidad";
            int FilaCantidad = -1;

            if (FilaCantidad == -1)
            {
                foreach (DataGridViewColumn columna in DgvProductos.Columns)
                {
                    if (columna.Name == ColCantidad)
                    {
                        FilaCantidad = columna.Index;
                        break;
                    }
                }
            }

            if (e.ColumnIndex == FilaCantidad && e.RowIndex != -1)
            {
                DataGridViewRow fila = DgvProductos.Rows[e.RowIndex];
                DataGridViewTextBoxCell celdaCantidad = fila.Cells[FilaCantidad] as DataGridViewTextBoxCell;
                string valorCantidad = celdaCantidad.Value != null ? celdaCantidad.Value.ToString() : "";

                if (!string.IsNullOrWhiteSpace(valorCantidad))
                {
                    CalcularTotal(e.RowIndex);
                }
                else
                {
                    DataGridViewTextBoxCell celdaTotal = fila.Cells["SubTotal"] as DataGridViewTextBoxCell;
                    celdaTotal.Value = "0";
                }
            }
        }

        private void CalcularTotal(int FilaSeleccionada)
        {
            DataGridViewRow fila = DgvProductos.Rows[FilaSeleccionada];
            DataGridViewTextBoxCell celdaCantidad = fila.Cells["Cantidad"] as DataGridViewTextBoxCell;
            string valorCantidad = celdaCantidad.Value != null ? celdaCantidad.Value.ToString() : "";
            DataGridViewTextBoxCell celdaPrecio = fila.Cells["Precio"] as DataGridViewTextBoxCell;
            string valorPrecio = celdaPrecio.Value != null ? celdaPrecio.Value.ToString() : "";

            if (decimal.TryParse(valorCantidad, out decimal cantidad) && decimal.TryParse(valorPrecio, out decimal precio))
            {
                decimal total = cantidad * precio;
                DataGridViewTextBoxCell celdaTotal = fila.Cells["SubTotal"] as DataGridViewTextBoxCell;
                celdaTotal.Value = total.ToString();
            }
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (formCargado && CmbCliente.SelectedIndex != -1 && CmbCliente.DataSource != null)
            {
                int valorSeleccionado = Convert.ToInt32(CmbCliente.SelectedValue);
                var dato = nClientes.ObtenerClientes().FirstOrDefault(d => d.ClienteId == valorSeleccionado);

                if (dato != null)
                {
                    TxtDescuento.Text = dato.grupoDescuento.Porcentaje.ToString();
                    TxtCondicionId.Text = dato.CondicionPagoId.ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró ningún dato con el valor seleccionado.");
                }
            }
        }

        private void V_Pedido_Shown(object sender, EventArgs e)
        {
            formCargado = true;
        }
        DataGridViewRow BuscarProducto(int idProducto)
        {
            foreach (DataGridViewRow fila in DgvDatos.Rows)
            {
                if ((int)fila.Cells["IDProducto"].Value == idProducto)
                {
                    return fila;
                }
            }
            return null;
        }
        private void ObtenerDetalles(DataGridViewTextBoxCell celda)
        {
            int id = (int)DgvProductos.CurrentRow.Cells["ID"].Value;
            DataGridViewRow filaExistente = BuscarProducto(id);

            if (filaExistente != null)
            {
                MessageBox.Show("Ya hay productos agregados de este tipo, Si decea agregar mas de este tipo, debe eliminar el detalle anterior y agregar el nuevo", "Producto Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (TxtDescuento.Text != "")
                {
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de agregar este producto al pedido?", "Confirmar Agregar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        int ProductoId = (int)DgvProductos.CurrentRow.Cells["ID"].Value;
                        string Codigo = DgvProductos.CurrentRow.Cells["Codigo"].Value.ToString();
                        string Descripcion = DgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                        decimal PrecioUnd = (decimal)DgvProductos.CurrentRow.Cells["Precio"].Value;
                        decimal Cantidad = decimal.Parse(DgvProductos.CurrentRow.Cells["Cantidad"].Value.ToString());
                        decimal SubTotal = decimal.Parse(DgvProductos.CurrentRow.Cells["SubTotal"].Value.ToString());
                        decimal Descuento = SubTotal * (decimal.Parse(TxtDescuento.Text) / 100);
                        decimal Impuesto = (SubTotal - Descuento) * ((decimal)DgvProductos.CurrentRow.Cells["Porciento"].Value / 100);
                        decimal Total = (SubTotal - Descuento) + Impuesto;

                        DgvDatos.Rows.Add(ProductoId, Codigo, Descripcion, PrecioUnd.ToString("0.00"), Cantidad.ToString("0.00"), SubTotal.ToString("0.00"), Descuento.ToString("0.00"), Impuesto.ToString("0.00"), Total.ToString("0.00"));

                        celda.Value = "";
                        ActualizarTotales();
                    }
                }
                else
                {
                    MessageBox.Show("Debe verificar que el cliente esté seleccionado correctamente. En caso de estar seleccionado, asegúrese de que el cliente pertenezca a algún grupo de descuento.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void ActualizarTotales()
        {
            decimal Cantidad = 0;
            decimal Total = 0;
            decimal SubTotal = 0;
            foreach (DataGridViewRow fila in DgvDatos.Rows)
            {
                Cantidad += decimal.Parse(fila.Cells["CantidadPROD"].Value.ToString());
                SubTotal += decimal.Parse(fila.Cells["SubTotalPROD"].Value.ToString());
                Total += decimal.Parse(fila.Cells["Total"].Value.ToString());

            }
            LblUnidades.Text = Cantidad.ToString();
            LblTotalPago.Text = Total.ToString();
            LblSubTotal.Text = SubTotal.ToString();
        }

        private void DgvDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DgvDatos.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult result = MessageBox.Show("¿Seguro que deseas Eliminar el  Producto de este Pedido?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow filaEliminar = DgvDatos.Rows[e.RowIndex];
                    DgvDatos.Rows.Remove(filaEliminar);
                }
            }
        }
        private void CREARPEDIDO()
        {
            if (DgvDatos.Rows.Count > 0)
            {
                Pedido pedido = new Pedido();
                pedido.ClienteId = int.Parse(CmbCliente.SelectedValue.ToString());
                pedido.FechaCreacion = DateTime.Now;
                pedido.FechaPedido = DtpFechaPedido.Value;
                pedido.Estado = true;
                decimal total = 0;
                decimal subtotal = 0;
                decimal impuestoTotal = 0;
                decimal DescuentoTotal = 0;


                List<PedidoDetalle> detalle = new List<PedidoDetalle>();

                foreach (DataGridViewRow fila in DgvDatos.Rows)
                {
                    impuestoTotal += decimal.Parse(fila.Cells["Impuesto"].Value.ToString());
                    subtotal += decimal.Parse(fila.Cells["SubTotalPROD"].Value.ToString());
                    total += decimal.Parse(fila.Cells["Total"].Value.ToString());
                    DescuentoTotal += decimal.Parse(fila.Cells["Descuento"].Value.ToString());

                    PedidoDetalle det = new PedidoDetalle();
                    det.PedidoId = pedido.PedidoId;
                    det.Pedido = pedido;
                    det.FechaCreacion = DateTime.Now;
                    det.ProductoId = int.Parse(fila.Cells["IDProducto"].Value.ToString());
                    det.Precio = decimal.Parse(fila.Cells["PrecioUnd"].Value.ToString());
                    det.Cantidad = decimal.Parse(fila.Cells["CantidadPROD"].Value.ToString());
                    det.Total = decimal.Parse(fila.Cells["Total"].Value.ToString());
                    det.Subtotal = decimal.Parse(fila.Cells["SubTotalPROD"].Value.ToString());
                    det.Descripcion = fila.Cells["Descripcion"].Value.ToString();
                    det.Descuento = decimal.Parse(fila.Cells["Descuento"].Value.ToString());
                    det.CodigoProducto = fila.Cells["Codigo"].Value.ToString();
                    det.FechaPedido = DtpFechaPedido.Value;
                    det.Impuesto = decimal.Parse(fila.Cells["Impuesto"].Value.ToString());
                    detalle.Add(det);
                }
                pedido.Total = total;
                pedido.Subtotal = subtotal;
                pedido.Impuesto = impuestoTotal;
                pedido.Descuento = DescuentoTotal;

                nPedido.CrearPedido(pedido, detalle);
                GuardarFactura(pedido.PedidoId);
                DgvDatos.Rows.Clear();
                limpiar();

            }
            else
            {
                MessageBox.Show("Aun no se han agreagdo detalles al pedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void GuardarFactura(int PEDIDO)
        {
            if (DgvDatos.Rows.Count > 0)
            {
                Factura factura = new Factura();
                factura.ClienteId = Convert.ToInt32(CmbCliente.SelectedValue);
                factura.PedidoId = PEDIDO;
                factura.FechaCreacion = DateTime.Now;
                factura.FechaFactura = DateTime.Now;
                factura.Estado = true;
                decimal Descuebto = 0;
                decimal Total = 0;
                decimal SubTotal = 0;

                List<FacturaDetalle> detalle = new List<FacturaDetalle>();

                foreach (DataGridViewRow fila in DgvDatos.Rows)
                {
                    Descuebto += decimal.Parse(fila.Cells["Descuento"].Value.ToString());
                    SubTotal += decimal.Parse(fila.Cells["SubTotalPROD"].Value.ToString());
                    Total += decimal.Parse(fila.Cells["Total"].Value.ToString());

                    FacturaDetalle det = new FacturaDetalle();
                    det.FacturaId = factura.FacturaId;
                    det.Factura = factura;
                    det.FechaCreacion = DateTime.Now;
                    det.FechaFactura = DateTime.Now;
                    det.ProductoId = int.Parse(fila.Cells["IDProducto"].Value.ToString());
                    det.Precio = decimal.Parse(fila.Cells["PrecioUnd"].Value.ToString());
                    det.Total = decimal.Parse(fila.Cells["Total"].Value.ToString());
                    det.Subtotal = decimal.Parse(fila.Cells["SubTotalPROD"].Value.ToString());
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            CREARPEDIDO();
        }
        void limpiar()
        {
            TxtCondicionId.Text = "";
            TxtDescuento.Text = "";
            CmbCliente.SelectedValue = -1;
            DtpFechaPedido.Value = DateTime.Now;
            LblSubTotal.Text = "0";
            LblTotalPago.Text = "0";
            LblUnidades.Text = "0";
        }
    }
}
