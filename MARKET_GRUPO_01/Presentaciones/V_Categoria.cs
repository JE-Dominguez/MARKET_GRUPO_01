using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Categoria : Form
    {
        int? ID;
        N_Categoria nCategoria;
        public V_Categoria(int? iD=null)
        {
            InitializeComponent();
            nCategoria = new N_Categoria();
            ID = iD;

            if (iD != null )
            {
                CargarPorID();
            }
        }
        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtDescripcion.Text = "";
            TxtIdCategoria.Text = "";
            ChkActivo.Checked = false;
            errorProvider1.Clear();
        }
        void guardar()
        {
            string CategoriaID = TxtIdCategoria.Text;
            string Codigo = TxtCodigo.Text;
            string Descripcion = TxtDescripcion.Text;

            if (string.IsNullOrEmpty(Codigo) || string.IsNullOrWhiteSpace(Codigo))
            {
                errorProvider1.SetError(TxtCodigo, "Debe colocar el codigo de la Categoria");
                return;
            }

            if (string.IsNullOrEmpty(CategoriaID) || string.IsNullOrWhiteSpace(CategoriaID))
            {
                CategoriaID = "0";
            }
            var categoria = new Categoria();
            if (int.Parse(CategoriaID) != 0)
            {
                categoria.CategoriaId = int.Parse(CategoriaID);
            }
            categoria.Codigo = Codigo;
            categoria.Descripcion = Descripcion;
            categoria.Estado = ChkActivo.Checked;
            nCategoria.GuardarCategoria(categoria);

            Limpiar();
        }
        void CargarPorID()
        {
            var categoria = nCategoria.ObtenerCategoria().FirstOrDefault(g => g.CategoriaId == ID);
            if (categoria != null)
            {
                LblTitulo.Text = "Editar Categoria";
                TxtIdCategoria.Text = categoria.CategoriaId.ToString();
                TxtDescripcion.Text = categoria.Descripcion;
                TxtCodigo.Text = categoria.Codigo;
                ChkActivo.Checked = categoria.Estado;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
