using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_UnidadMedida : Form
    {
        int? ID;
        N_UnidadMedida nUnidadMedida;
        public V_UnidadMedida(int? iD = null)
        {
            InitializeComponent();
            nUnidadMedida = new N_UnidadMedida();
            ID = iD;

            if(ID != null ) { CargarPorID(); }
        }
        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtDescripcion.Text = "";
            TxtIdUnidadMedida.Text = "";
            ChkActivo.Checked = false;
            errorProvider1.Clear();
        }
        void guardar()
        {
            string UnidadMedidadID = TxtIdUnidadMedida.Text;
            string Codigo = TxtCodigo.Text;
            string Descripcion = TxtDescripcion.Text;

            if (string.IsNullOrEmpty(Codigo) || string.IsNullOrWhiteSpace(Codigo))
            {
                errorProvider1.SetError(TxtCodigo, "Debe colocar el codigo de la Unidad Medida");
                return;
            }

            if (string.IsNullOrEmpty(UnidadMedidadID) || string.IsNullOrWhiteSpace(UnidadMedidadID))
            {
                UnidadMedidadID = "0";
            }
            var unidadMedida = new UnidadMedida();
            if (int.Parse(UnidadMedidadID) != 0)
            {
                unidadMedida.UnidadMedidaId = int.Parse(UnidadMedidadID);
            }
            unidadMedida.Codigo = Codigo;
            unidadMedida.Descripcion = Descripcion;
            unidadMedida.Estado = ChkActivo.Checked;
            nUnidadMedida.GuardarUnidadMedida(unidadMedida);

            Limpiar();
        }
           
        void CargarPorID()
        {
            var unidadMedida = nUnidadMedida.ObtenerUnidadesMedida().FirstOrDefault(g => g.UnidadMedidaId == ID);
            if (unidadMedida != null)
            {
                LblTitulo.Text = "Editar Unidad Medida";
                TxtIdUnidadMedida.Text = unidadMedida.UnidadMedidaId.ToString();
                TxtDescripcion.Text = unidadMedida.Descripcion;
                TxtCodigo.Text = unidadMedida.Codigo;
                ChkActivo.Checked = unidadMedida.Estado;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
