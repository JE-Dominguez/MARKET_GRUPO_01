using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Productos : Form
    {
        private V_Login login = null;
        private readonly AbrirForm AF;
        private readonly V_Inicio inicio;
        private readonly N_Productos nProductos;
        private readonly N_UnidadMedida nUnidadMedida;
        private readonly N_Categoria nCategoria;
        private readonly N_Impuestos nImpuestos;
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
            nImpuestos = new N_Impuestos();
            tituloListado = "LISTADO PRODUCTOS";
            TextoBoton = "NUEVO PRODUCTO";
        }

        private void V_Productos_Load(object sender, EventArgs e)
        {
            LblFecha.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            PnlSubMenu.Visible = false;
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
        private void TxtImpuestos_CheckedChanged(object sender, EventArgs e)
        {
            TextoBoton = "NUEVO IMPUESTOS";
            tituloListado = "LISTADO IMPUESTOS";
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
            else if (TxtImpuestos.Checked)
            {
                N_Impuestos nImpuestos = new N_Impuestos();
                DgvDatos.DataSource = nImpuestos.ObtenerImpuestoss();
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
                        AF.VentanaEmergente(new V_Producto(id), inicio, D_ParametrosActivos.pr_productos);
                    else if (BtnCategoria.Checked)
                        AF.VentanaEmergente(new V_Categoria(id), inicio, D_ParametrosActivos.pr_categorias);
                    else if (BtnUnidadMedida.Checked)
                        AF.VentanaEmergente(new V_UnidadMedida(id), inicio, D_ParametrosActivos.pr_unidadMedida);
                    else if (TxtImpuestos.Checked)
                        AF.VentanaEmergente(new V_Impuesto(id), inicio, D_ParametrosActivos.pr_impuesto);
                }
            }
        }

        private void Nuevo()
        {
            if (BtnProductos.Checked)
                AF.VentanaEmergente(new V_Producto(), inicio, D_ParametrosActivos.pr_productos);
            else if (BtnCategoria.Checked)
                AF.VentanaEmergente(new V_Categoria(), inicio, D_ParametrosActivos.pr_categorias);
            else if (BtnUnidadMedida.Checked)
                AF.VentanaEmergente(new V_UnidadMedida(), inicio, D_ParametrosActivos.pr_unidadMedida);
            else if (TxtImpuestos.Checked)
                AF.VentanaEmergente(new V_Impuesto(), inicio, D_ParametrosActivos.pr_impuesto);
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
                        if (BtnProductos.Checked && D_ParametrosActivos.pr_productos == true)
                            nProductos.EliminarProducto(id);
                        else if (BtnCategoria.Checked && D_ParametrosActivos.pr_categorias == true)
                            nCategoria.EliminarCategoria(id);
                        else if (BtnUnidadMedida.Checked && D_ParametrosActivos.pr_unidadMedida == true)
                            nUnidadMedida.EliminarUnidadMedida(id);
                        else if (TxtImpuestos.Checked && D_ParametrosActivos.pr_impuesto == true)
                            nImpuestos.EliminarImpuestos(id);
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
            if (BtnProductos.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["ProductoId"].Value;
            else if (BtnCategoria.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["CategoriaId"].Value;
            else if (BtnUnidadMedida.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["UnidadMedidaId"].Value;
            else if (TxtImpuestos.Checked)
                id = (int)DgvDatos.Rows[LiniaID].Cells["ImpuestoId"].Value;
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

        private void btncerrar_Click(object sender, EventArgs e)
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
    }
}
