using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Producto : Form
    {
        N_Categoria nCategoria;
        N_UnidadMedida nUnidadMedida;
        N_Productos nProductos;
        public V_Producto()
        {
            InitializeComponent();
            nCategoria = new N_Categoria();
            nUnidadMedida = new N_UnidadMedida();
            nProductos = new N_Productos();
        }
        private void Limpiar()
        {
            TxtIdProducto.Text = "";
            TxtPrecioCompra.Text = "";
            CmbCategoria.SelectedValue = -1;
            CmbUnidadMedida.SelectedValue = -1;
            ChkActivo.Checked = false;
            errorProvider1.Clear();
        }
        void guardar()
        {
            string ProductoID = TxtIdProducto.Text;
            string PrecioCompra = TxtPrecioCompra.Text;
            int UnidadMedida = Convert.ToInt32(CmbUnidadMedida.SelectedValue);
            int Categoria = Convert.ToInt32(CmbCategoria.SelectedValue);

            if (string.IsNullOrEmpty(PrecioCompra) || string.IsNullOrWhiteSpace(PrecioCompra))
            {
                errorProvider1.SetError(TxtPrecioCompra, "Debe colocar el preecio compra del producto");
                return;
            }

            if (string.IsNullOrEmpty(ProductoID) || string.IsNullOrWhiteSpace(ProductoID))
            {
                ProductoID = "0";
            }
            var producto = new Productos();
            if (int.Parse(ProductoID) != 0)
            {
                producto.ProductoId = int.Parse(ProductoID);
            }
            producto.PrecioCompra = decimal.Parse(PrecioCompra);
            producto.UnidadMedidaId = UnidadMedida;
            producto.CategoriaId = Categoria;
            producto.Estado = ChkActivo.Checked;
            nProductos.GuardarProducto(producto);

            Limpiar();
        }
        void Combos()
        {
            try
            {
                var UnidadesMedida = nUnidadMedida.ObtenerUnidadesMedida();
                var Categorias = nCategoria.ObtenerCategoria();

                if (Categorias != null && Categorias.Any())
                {
                    CmbCategoria.DataSource = Categorias;
                    CmbCategoria.DisplayMember = "Descripcion";
                    CmbCategoria.ValueMember = "CategoriaId";
                }
                else
                {
                    MessageBox.Show("No hay Categorias disponibles. Debe agregar alguna Categoria.");
                }
                if (UnidadesMedida != null && UnidadesMedida.Any())
                {
                    CmbUnidadMedida.DataSource = UnidadesMedida;
                    CmbUnidadMedida.DisplayMember = "Descripcion";
                    CmbUnidadMedida.ValueMember = "UnidadMedidaId";
                }
                else
                {
                    MessageBox.Show("No hay Unidades de medida disponibles. Debe agregar Unidades de Medida.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al cargar los datos: {ex.Message}");
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void V_Producto_Load(object sender, EventArgs e)
        {
            Combos();
        }
    }
}
