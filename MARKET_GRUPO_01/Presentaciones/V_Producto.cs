using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Producto : Form
    {
        int? ID;
        N_Categoria nCategoria;
        N_UnidadMedida nUnidadMedida;
        N_Productos nProductos;
        N_Impuestos nImpuestos;
        public V_Producto(int? iD = null)
        {
            InitializeComponent();
            nCategoria = new N_Categoria();
            nUnidadMedida = new N_UnidadMedida();
            nProductos = new N_Productos();
            nImpuestos = new N_Impuestos();
            ID = iD;

            if (ID != null) { CargarPorId(); }
        }
        private void Limpiar()
        {
            TxtIdProducto.Text = "";
            TxtPrecioCompra.Text = "";
            TxtNombre.Text = "";
            TxtCodigo.Text = "";
            CmbCategoria.SelectedValue = -1;
            CmbUnidadMedida.SelectedValue = -1;
            CmbImpuesto.SelectedValue = -1;
            ChkActivo.Checked = false;
            errorProvider1.Clear();
        }
        void guardar()
        {
            string Nombre = TxtNombre.Text;
            string ProductoID = TxtIdProducto.Text;
            string Codigo = TxtCodigo.Text;
            string PrecioCompra = TxtPrecioCompra.Text;
            int UnidadMedida = Convert.ToInt32(CmbUnidadMedida.SelectedValue);
            int Categoria = Convert.ToInt32(CmbCategoria.SelectedValue);
            int impuesto = Convert.ToInt32(CmbImpuesto.SelectedValue);

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
            producto.Nombre = Nombre;
            producto.PrecioCompra = decimal.Parse(PrecioCompra);
            producto.UnidadMedidaId = UnidadMedida;
            producto.CategoriaId = Categoria;
            producto.Codigo = Codigo;
            producto.ImpuestoId = impuesto;
            producto.Estado = ChkActivo.Checked;
            nProductos.GuardarProducto(producto);

            Limpiar();
            this.Close();
        }
        void Combos()
        {
            try
            {
                var UnidadesMedida = nUnidadMedida.ObtenerUnidadesMedida();
                var Categorias = nCategoria.ObtenerCategoria();
                var Impuestos = nImpuestos.ObtenerImpuestoss();

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
                if (Impuestos != null && Impuestos.Any())
                {
                    CmbImpuesto.DataSource = Impuestos;
                    CmbImpuesto.DisplayMember = "Porcentaje";
                    CmbImpuesto.ValueMember = "ImpuestoId";
                }
                else
                {
                    MessageBox.Show("No hay Impuestos disponibles. Debe agregar Impuestos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al cargar los datos: {ex.Message}");
            }
        }

        void CargarPorId()
        {
            var producto = nProductos.ObtenerProductos().FirstOrDefault(g => g.ProductoId == ID);
            if (producto != null)
            {
                TxtNombre.Text = producto.Nombre;
                LblTitulo.Text = "Editar producto";
                TxtIdProducto.Text = producto.ProductoId.ToString();
                TxtPrecioCompra.Text = producto.PrecioCompra.ToString();
                ChkActivo.Checked = producto.Estado;
                CmbCategoria.SelectedValue = producto.CategoriaId;
                CmbUnidadMedida.SelectedValue = producto.UnidadMedidaId;
                TxtCodigo.Text = producto.Codigo;
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

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
