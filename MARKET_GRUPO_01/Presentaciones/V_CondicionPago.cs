using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_CondicionPago : Form
    {
        int? ID;
        N_CondicionPago nCondicionPago;
        public V_CondicionPago(int? iD=null)
        {
            InitializeComponent();
            nCondicionPago = new N_CondicionPago();
            ID = iD;

            if(ID != null) { CargarPorID(); }
        }
        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtDescripcion.Text = "";
            TxtDias.Text = "";
            TxtIdCondicionPAGO.Text = "";
            ChkActivo.Checked = false;
            errorProvider1.Clear();
        }

        void CargarPorID()
        {
            var condicionPago = nCondicionPago.ObtenerCondicionesPago().FirstOrDefault(g => g.CondicionPagoId == ID);
            if (condicionPago != null)
            {
                LblTitulo.Text = "Editar condicionPago";
                TxtIdCondicionPAGO.Text = condicionPago.CondicionPagoId.ToString();
                TxtDescripcion.Text = condicionPago.Descripcion;
                TxtDias.Text = condicionPago.Dias.ToString();
                TxtCodigo.Text = condicionPago.Codigo;
                ChkActivo.Checked = condicionPago.Estado;
            }
        }
        void guardar()
        {
            string CondicionPadoID = TxtIdCondicionPAGO.Text;
            string Codigo = TxtCodigo.Text;
            string Descripcion = TxtDescripcion.Text;
            int Dias = int.Parse(TxtDias.Text);

            if (string.IsNullOrEmpty(Codigo) || string.IsNullOrWhiteSpace(Codigo))
            {
                errorProvider1.SetError(TxtCodigo, "Debe colocar el codigo de la Condicion de Pago");
                return;
            }

            if (string.IsNullOrEmpty(CondicionPadoID) || string.IsNullOrWhiteSpace(CondicionPadoID))
            {
                CondicionPadoID = "0";
            }
            var CondicionPagp = new CondicionPago();
            if (int.Parse(CondicionPadoID) != 0)
            {
                CondicionPagp.CondicionPagoId = int.Parse(CondicionPadoID);
            }
            CondicionPagp.Codigo = Codigo;
            CondicionPagp.Dias = Dias;
            CondicionPagp.Descripcion = Descripcion;
            CondicionPagp.Estado = ChkActivo.Checked;
            nCondicionPago.GuardarCondicionPago(CondicionPagp);

            Limpiar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
