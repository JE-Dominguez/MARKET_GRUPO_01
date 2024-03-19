using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_GrupoDescuento : Form
    {
        N_GrupoDescuento ngrupoDescuento;
        public V_GrupoDescuento()
        {
            InitializeComponent();
            ngrupoDescuento = new N_GrupoDescuento();
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
            ngrupoDescuento.GuardarGrupoDescuento(grupoDescuento);

            Limpiar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
