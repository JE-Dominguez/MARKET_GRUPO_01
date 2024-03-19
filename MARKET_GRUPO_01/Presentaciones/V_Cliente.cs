using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Cliente : Form
    {
        N_Clientes ncliente;
        N_CondicionPago nCondicionPago;
        N_GrupoDescuento nGrupoDescuento;
        public V_Cliente()
        {
            InitializeComponent();
            ncliente = new N_Clientes();
            nCondicionPago = new N_CondicionPago();
            nGrupoDescuento = new N_GrupoDescuento();
        }

        private void Limpiar()
        {
            TxtCodigo.Text = "";
            TxtApellido.Text = "";
            TxtNombre.Text = "";
            TxtIdCliente.Text = "";
            CmbCondicoonPAGO.SelectedValue = -1;
            CmbGrupoDescuento.SelectedValue = -1;
            ChkActivo.Checked = false;
            errorProvider1.Clear();
        }

        void Combos()
        {
            try
            {
                var condiconesPago = nCondicionPago.ObtenerCondicionesPago();
                var grupoDescuento = nGrupoDescuento.ObtenerGruposDescuento();

                if (condiconesPago != null && condiconesPago.Any())
                {
                    CmbCondicoonPAGO.DataSource = condiconesPago;
                    CmbCondicoonPAGO.DisplayMember = "Descripcion";
                    CmbCondicoonPAGO.ValueMember = "CondicionPagoId";
                }
                else
                {
                    MessageBox.Show("No hay Condiciones de PAGO disponibles. Debe agregar Condiciones de PAGO.");
                }
                if (grupoDescuento != null && grupoDescuento.Any())
                {
                    CmbGrupoDescuento.DataSource = grupoDescuento;
                    CmbGrupoDescuento.DisplayMember = "Descripcion";
                    CmbGrupoDescuento.ValueMember = "GrupoDescuentoId";
                }
                else
                {
                    MessageBox.Show("No hay Grupos de Descuento disponibles. Debe agregar GrupoS Descuento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error al cargar los roles: {ex.Message}");
            }
        }

        private void V_Cliente_Load(object sender, EventArgs e)
        {
            Combos();
        }
        void guardar()
        {
            string ClienteId = TxtIdCliente.Text;
            string Codigo = TxtCodigo.Text;
            string Nombre = TxtNombre.Text;
            string Apellido = TxtApellido.Text;
            int CondicionPago = Convert.ToInt32(CmbCondicoonPAGO.SelectedValue);
            int GrupoDescuento = Convert.ToInt32(CmbGrupoDescuento.SelectedValue);
            if (string.IsNullOrEmpty(Codigo) || string.IsNullOrWhiteSpace(Codigo))
            {
                errorProvider1.SetError(TxtCodigo, "Debe colocar el codigo del Cliente");
                return;
            }

            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrWhiteSpace(Nombre))
            {
                errorProvider1.SetError(TxtNombre, "Debe colocar la Nombre");
                return;
            }
            if (string.IsNullOrEmpty(ClienteId) || string.IsNullOrWhiteSpace(ClienteId))
            {
                ClienteId = "0";
            }
            var cliente = new Clientes();
            if (int.Parse(ClienteId) != 0)
            {
                cliente.ClienteId = int.Parse(ClienteId);
            }
            cliente.Codigo = Codigo;
            cliente.Nombres = Nombre;
            cliente.Apellidos = Apellido;
            cliente.CondicionPagoId = CondicionPago;
            cliente.GrupoDescuentoId = GrupoDescuento;
            cliente.Estado = ChkActivo.Checked;
            ncliente.GuardarCliente(cliente);

            Limpiar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
    }
}
