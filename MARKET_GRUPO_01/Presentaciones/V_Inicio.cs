using Capa_Negocio;
using System;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Inicio : Form
    {
        private V_Login login = null;
        AbrirForm AF;
        public V_Inicio()
        {
            InitializeComponent();
            AF = new AbrirForm();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            BtnUsuario.Text = D_ParametrosActivos.Usuario;
            AF.Abrir(new V_Principio(), PnlContenedor, true);
            LblPARAMETROS.Text = "Usuario (" + D_ParametrosActivos.Usuario.ToString() + ")  Nombre (" + D_ParametrosActivos.Nombre + " " + D_ParametrosActivos.Apellido + ") Rol (" + D_ParametrosActivos.Rol + ") Inicio (" + D_ParametrosActivos.FechaInicio + ")";
        }

        private void BtnSeguridad_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Seguridad(this), PnlContenedor, D_ParametrosActivos.seg_usuarios);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Clientes(this), PnlContenedor, D_ParametrosActivos.cl_clientes);
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Productos(this), PnlContenedor, D_ParametrosActivos.pr_productos);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Pedidos(this), PnlContenedor, D_ParametrosActivos.seg_usuarios);
        }
        private void btninicio_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Principio(), PnlContenedor, true);
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
                this.Close();
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            AF.VentanaEmergente(new V_Usuario(D_ParametrosActivos.UsuarioID, true), this, true);
        }
    }
}
