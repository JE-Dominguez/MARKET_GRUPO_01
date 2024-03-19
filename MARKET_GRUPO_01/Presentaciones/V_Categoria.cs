using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Categoria : Form
    {
        N_Categoria nCategoria;
        public V_Categoria()
        {
            InitializeComponent();
            nCategoria = new N_Categoria();
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
