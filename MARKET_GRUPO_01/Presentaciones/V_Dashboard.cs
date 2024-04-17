using Capa_Datos;
using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Dashboard : Form
    {
        private V_Login login = null;
        N_PEDIDO _PEDIDO;
        N_Clientes _Clientes;
        private readonly V_Inicio inicio;
        private readonly AbrirForm AF;
        public V_Dashboard(V_Inicio ini)
        {
            InitializeComponent();
            inicio = ini;
            AF = new AbrirForm();
            _PEDIDO = new N_PEDIDO();
            _Clientes = new N_Clientes();
        }
        void cargar()
        {
            lblusuario.Text = D_ParametrosActivos.Usuario;
            LblTRol.Text = D_ParametrosActivos.Rol;
            LblNombre.Text = D_ParametrosActivos.Nombre+" "+ D_ParametrosActivos.Apellido;
            LblCorreo.Text = D_ParametrosActivos.Correo;
            LblFechaInicio.Text = D_ParametrosActivos.UsuarioInicio;
            LblActivo.Text = D_ParametrosActivos.fechamodifica;

            List<Pedido> pedidos = _PEDIDO.ObtenerPedidos();
            lblpedidos.Text = pedidos.Count.ToString();

            List<Clientes> clientes = _Clientes.ObtenerClientes();
            LblClientes.Text = clientes.Count.ToString();

            var tpedidos = _PEDIDO.ObtenerPedidosGrid();
            DgvDatos.DataSource = tpedidos;

            PnlSubMenu.Visible = false;
        }

        private void V_Dashboard_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void BtnNuevoUsuario_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Usuario(), inicio, D_ParametrosActivos.seg_usuarios);
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Cliente(), inicio, D_ParametrosActivos.cl_clientes);
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Producto(), inicio, D_ParametrosActivos.pr_productos);
        }

        private void BtnNuevoPedido_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Pedido(), inicio, D_ParametrosActivos.p_pedidos);
        }

        private void BtnNuevoImpuesto_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Impuesto(), inicio, D_ParametrosActivos.pr_impuesto);
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (BtnMenu.Checked == false)
            {
                PnlSubMenu.Visible = false;
            }
            else
            {
                PnlSubMenu.Visible = true;
            }
        }

        private void BtnMyUsuario_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Usuario(D_ParametrosActivos.UsuarioID, true), inicio, true);
            BtnMenu.Checked = false;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }
        private void CerrarSesion()
        {
            // Pregunta al usuario si está seguro de cerrar sesión
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (login == null || login.IsDisposed)
                {
                    login = new V_Login();
                }

                login.Show();
                inicio.Close();
            }
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void BtnManual_Click(object sender, EventArgs e)
        {
            string Ruta = "Manual de uso Grupo 1.pdf";
            Process.Start(Ruta);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Usuario(D_ParametrosActivos.UsuarioID, true), inicio, true);
            BtnMenu.Checked = false;
        }
    }
}
