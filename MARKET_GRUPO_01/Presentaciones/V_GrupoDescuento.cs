using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_GrupoDescuento : Form
    {
        int? ID;
        N_GrupoDescuento nGrupoDescuento;
        public V_GrupoDescuento(int? iD=null)
        {
            InitializeComponent();
            nGrupoDescuento = new N_GrupoDescuento();
            ID = iD;

            if(ID != null) { CargarPorID(); }
        }
        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtDescipcion.Text = "";
            TxtPorcentaje.Text = "";
            TxtIdGrupoDescuento.Text = "";
            ChkACTIVO.Checked = false;
            errorProvider1.Clear();
        }
        void CargarPorID()
        {
            var grupoDescuento = nGrupoDescuento.ObtenerGruposDescuento().FirstOrDefault(g => g.GrupoDescuentoId == ID);
            if (grupoDescuento != null)
            {
                LblTitulo.Text = "Editar Grupo Descuento";
                TxtIdGrupoDescuento.Text = grupoDescuento.GrupoDescuentoId.ToString();
                TxtDescipcion.Text = grupoDescuento.Descripcion;
                TxtCodigo.Text = grupoDescuento.Codigo;
                TxtPorcentaje.Text = grupoDescuento.Porcentaje.ToString();
                ChkACTIVO.Checked = grupoDescuento.Estado;
            }
        }
        void guardar()
        {
            string GrupoDescuentoID = TxtIdGrupoDescuento.Text;
            string Codigo = TxtCodigo.Text;
            string Descripcion = TxtDescipcion.Text;
            int Dias = int.Parse(TxtPorcentaje.Text);

            if (string.IsNullOrEmpty(Codigo) || string.IsNullOrWhiteSpace(Codigo))
            {
                errorProvider1.SetError(TxtCodigo, "Debe colocar el codigo del Grupo Descuento");
                return;
            }

            if (string.IsNullOrEmpty(GrupoDescuentoID) || string.IsNullOrWhiteSpace(GrupoDescuentoID))
            {
                GrupoDescuentoID = "0";
            }
            var grupoDescuento = new GrupoDescuento();
            if (int.Parse(GrupoDescuentoID) != 0)
            {
                grupoDescuento.GrupoDescuentoId = int.Parse(GrupoDescuentoID);
            }
            grupoDescuento.Codigo = Codigo;
            grupoDescuento.Porcentaje = Dias;
            grupoDescuento.Descripcion = Descripcion;
            grupoDescuento.Estado = ChkACTIVO.Checked;
            nGrupoDescuento.GuardarGrupoDescuento(grupoDescuento);

            Limpiar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
