using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Productos : Form
    {
        AbrirForm AF;
        public V_Inicio inicio;
        N_Productos nProductos;
        N_UnidadMedida nUnidadMedida;
        N_Categoria nCategoria;

        //contructor
        public V_Productos(V_Inicio ini)
        {
            InitializeComponent();
            inicio = ini;
            AF = new AbrirForm();
            nProductos = new N_Productos();
            nUnidadMedida = new N_UnidadMedida();
            nCategoria = new N_Categoria();

        }

        void SeleccionarSoloUno(DataGridViewCellEventArgs e, DataGridView dgv)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell otherChk = (DataGridViewCheckBoxCell)row.Cells[e.ColumnIndex];
                    otherChk.Value = (row.Index == e.RowIndex);
                }
            }
        }

        void HabilitarSoloColumnaSeleccion(DataGridView dgv)
        {
            if (DgvDatos.DataSource != null)
            {
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.ReadOnly = true;
                }
                dgv.Columns[0].ReadOnly = false;
            }
        }

        void ConsultarCategoria(int CategoriaID)
        {
            V_Categoria vcategoria = new V_Categoria();
            var categoria = nCategoria.ObtenerCategoria().FirstOrDefault(g => g.CategoriaId == CategoriaID);
            if (categoria != null)
            {
                vcategoria.LblTitulo.Text = "Editar Categoria";
                vcategoria.TxtIdCategoria.Text = categoria.CategoriaId.ToString();
                vcategoria.TxtDescripcion.Text = categoria.Descripcion;
                vcategoria.TxtCodigo.Text = categoria.Codigo;
                vcategoria.ChkActivo.Checked = categoria.Estado;
                AF.VentanaEmergente(vcategoria, inicio, true);
            }
        }
        void ConsultarUnidadMedida(int unidadMedidaID)
        {
            V_UnidadMedida vUnidadMedida = new V_UnidadMedida();
            var unidadMedida = nUnidadMedida.ObtenerUnidadesMedida().FirstOrDefault(g => g.UnidadMedidaId == unidadMedidaID);
            if (unidadMedida != null)
            {
                vUnidadMedida.LblTitulo.Text = "Editar Unidad Medida";
                vUnidadMedida.TxtIdUnidadMedida.Text = unidadMedida.UnidadMedidaId.ToString();
                vUnidadMedida.TxtDescripcion.Text = unidadMedida.Descripcion;
                vUnidadMedida.TxtCodigo.Text = unidadMedida.Codigo;
                vUnidadMedida.ChkActivo.Checked = unidadMedida.Estado;
                AF.VentanaEmergente(vUnidadMedida, inicio, true);
            }
        }
        void ConsultarProducto(int Idproducto)
        {
            V_Producto vProducto = new V_Producto();
            var producto = nProductos.ObtenerProductos().FirstOrDefault(g => g.ProductoId == Idproducto);
            if (producto != null)
            {
                vProducto.LblTitulo.Text = "Editar producto";
                vProducto.TxtIdProducto.Text = producto.ProductoId.ToString();
                vProducto.TxtPrecioCompra.Text = producto.PrecioCompra.ToString();
                vProducto.ChkActivo.Checked = producto.Estado;
                vProducto.CmbCategoria.SelectedValue = producto.CategoriaId;
                vProducto.CmbUnidadMedida.SelectedValue = producto.UnidadMedidaId;
                AF.VentanaEmergente(vProducto, inicio, true);
            }
        }
        private void BtnProductos_Click(object sender, EventArgs e)
        {
            Recargar();
        }
        private void BtnCategoria_Click(object sender, EventArgs e)
        {
            Recargar();
        }
        private void BtnUnidadMedida_Click(object sender, EventArgs e)
        {
            Recargar();
        }

        private void V_Productos_Load(object sender, EventArgs e)
        {
            Recargar();
        }
        void editar()
        {
            if (DgvDatos.SelectedCells.Count > 0)
            {
                int rowIndex = DgvDatos.SelectedCells[0].RowIndex;
                DataGridViewCheckBoxCell checkBoxCell = DgvDatos.Rows[rowIndex].Cells["Selecion"] as DataGridViewCheckBoxCell;

                if (checkBoxCell?.Value is true)
                {
                    if (BtnProductos.Checked == true)
                    {
                        if (DgvDatos.Rows[rowIndex].Cells["ProductoId"].Value is int id)
                        {
                            ConsultarProducto(id);
                        }
                    }

                    if (BtnCategoria.Checked == true)
                    {
                        if (DgvDatos.Rows[rowIndex].Cells["ID"].Value is int id)
                        {
                            ConsultarCategoria(id);
                        }
                    }

                    if (BtnUnidadMedida.Checked == true)
                    {
                        if (DgvDatos.Rows[rowIndex].Cells["ID"].Value is int id)
                        {
                            ConsultarUnidadMedida(id);
                        }
                    }
                }
            }
        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvDatos);
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            editar();
            Recargar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (BtnProductos.Checked == true)
            {
                AF.VentanaEmergente(new V_Producto(), inicio, true);
            }
            if (BtnCategoria.Checked == true)
            {
                AF.VentanaEmergente(new V_Categoria(), inicio, true);
            }
            if (BtnUnidadMedida.Checked == true)
            {
                AF.VentanaEmergente(new V_UnidadMedida(), inicio, true);
            }
            Recargar();
        }
        #region HELPER
        private void Recargar()
        {
            if (BtnProductos.Checked == true)
            {
                DgvDatos.DataSource = nProductos.ObtenerProductos();
            }
            if (BtnCategoria.Checked == true)
            {
                DgvDatos.DataSource = nCategoria.ObtenerCategoriaGrid();
            }
            if (BtnUnidadMedida.Checked == true)
            {
                DgvDatos.DataSource = nUnidadMedida.ObtenerUnidadesMedidaGrid();
            }

        }
        #endregion

        private void BtnEiminar_Click(object sender, EventArgs e)
        {
            Recargar();
        }
    }
}
