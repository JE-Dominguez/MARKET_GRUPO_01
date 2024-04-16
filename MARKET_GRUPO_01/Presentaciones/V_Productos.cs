using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Productos : Form
    {
        private readonly AbrirForm AF;
        private readonly V_Inicio inicio;
        private readonly N_Productos nProductos;
        private readonly N_UnidadMedida nUnidadMedida;
        private readonly N_Categoria nCategoria;
        private string tituloListado;
        private string TextoBoton;

        public V_Productos(V_Inicio ini)
        {
            InitializeComponent();
            inicio = ini;
            AF = new AbrirForm();
            nProductos = new N_Productos();
            nUnidadMedida = new N_UnidadMedida();
            nCategoria = new N_Categoria();
            tituloListado = "LISTADO PRODUCTOS";
            TextoBoton = "NUEVO PRODUCTO";
        }

        private void V_Productos_Load(object sender, EventArgs e)
        {
            Recargar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Editar();
            Recargar();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            Recargar();
        }

        private void BtnEiminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            Recargar();
        }

        private void BtnProductos_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO PRODUCTO";
            tituloListado = "LISTADO PRODUCTOS";
            Recargar();
        }

        private void BtnCategoria_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVA CATEGORIA";
            tituloListado = "LISTADO CATEGORIAS";
            Recargar();
        }

        private void BtnUnidadMedida_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVA UNIDAD MEDIDA";
            tituloListado = "LISTADO UNIDADES MEDIDAS";
            Recargar();
        }

        private void Recargar()
        {
            DgvDatos.DataSource = null;
            if (BtnProductos.Checked)
            {
                N_Productos nProductos = new N_Productos();
                DgvDatos.DataSource = nProductos.ObtenerProductosGrid();
            }

            else if (BtnCategoria.Checked)
            {
                N_Categoria nCategoria = new N_Categoria();
                DgvDatos.DataSource = nCategoria.ObtenerCategoriaGrid();
            }

            else if (BtnUnidadMedida.Checked)
            {
                N_UnidadMedida nUnidadMedida = new N_UnidadMedida();
                DgvDatos.DataSource = nUnidadMedida.ObtenerUnidadesMedidaGrid();
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

                    if (BtnProductos.Checked)
                        AF.VentanaEmergente(new V_Producto(id), inicio, true);
                    else if (BtnCategoria.Checked)
                        AF.VentanaEmergente(new V_Categoria(id), inicio, true);
                    else if (BtnUnidadMedida.Checked)
                        AF.VentanaEmergente(new V_UnidadMedida(id), inicio, true);
                }
            }
        }

        private void Nuevo()
        {
            if (BtnProductos.Checked)
                AF.VentanaEmergente(new V_Producto(), inicio, true);
            else if (BtnCategoria.Checked)
                AF.VentanaEmergente(new V_Categoria(), inicio, true);
            else if (BtnUnidadMedida.Checked)
                AF.VentanaEmergente(new V_UnidadMedida(), inicio, true);
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

                    DialogResult resultado = MessageBox.Show($"¿Está seguro de eliminar este {(BtnProductos.Checked ? "producto" : (BtnCategoria.Checked ? "categoría" : "unidad de medida"))}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        if (BtnProductos.Checked)
                            nProductos.EliminarProducto(id);
                        else if (BtnCategoria.Checked)
                            nCategoria.EliminarCategoria(id);
                        else if (BtnUnidadMedida.Checked)
                            nUnidadMedida.EliminarUnidadMedida(id);
                    }
                }
            }
        }

        private int ObtenerID(int LiniaID)
        {
            int id = -1;
            if (BtnProductos.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["ProductoId"].Value;
            else if (BtnCategoria.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["CategoriaId"].Value;
            else if (BtnUnidadMedida.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["UnidadMedidaId"].Value;
            return id;
        }

        private void DgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarSoloUno(e, DgvDatos);
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Recargar();
        }
    }
}
