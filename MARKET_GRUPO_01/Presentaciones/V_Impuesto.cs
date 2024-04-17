using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Impuesto : Form
    {
        private int? ID;
        private N_Impuestos nImpuestos;
        public V_Impuesto(int? id = null)
        {
            InitializeComponent();
            nImpuestos = new N_Impuestos();
            this.ID = id;

            if (id != null) { ConsultarPorId(); }
        }
        private void Limpiar()
        {
            TxtId.Text = "";
            TxtCodigo.Text = "";
            TxtPorciento.Text = "";
            ChkActivo.Checked = false;
            errorProvider1.Clear();
        }

        void Guardar()
        {
            string id = TxtId.Text;
            string codigo = TxtCodigo.Text;
            string porciento = TxtPorciento.Text;
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrWhiteSpace(codigo))
            {
                errorProvider1.SetError(TxtCodigo, "Debe colocar el codigo");
                return;
            }
            if (string.IsNullOrEmpty(porciento) || string.IsNullOrWhiteSpace(porciento))
            {
                errorProvider1.SetError(TxtPorciento, "Debe colocar la descripcion");
                return;
            }
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                id = "0";
            }
            var impuesto = new Impuestos();

            if (int.Parse(id) != 0)
            {
                impuesto.ImpuestoId = int.Parse(id);
            }
            impuesto.Codigo = codigo;
            impuesto.Porcentaje = decimal.Parse(porciento);
            impuesto.Estado = ChkActivo.Checked;

            nImpuestos.GuardarImpuestos(impuesto);
            Limpiar();
        }
        private void ConsultarPorId()
        {
            var impuesto = nImpuestos.ObtenerImpuestoss().FirstOrDefault(g => g.ImpuestoId == ID);
            if (impuesto != null)
            {
                LblTitulo.Text = "Editar Impuesto";
                TxtId.Text = impuesto.ImpuestoId.ToString();
                TxtCodigo.Text = impuesto.Codigo;
                TxtPorciento.Text = impuesto.Porcentaje.ToString();
                ChkActivo.Checked = impuesto.Estado;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void BtnDescartar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
