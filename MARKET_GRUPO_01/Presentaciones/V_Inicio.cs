using System;
using System.Windows.Forms;

namespace MARKET_GRUPO_01.Presentaciones
{
    public partial class V_Inicio : Form
    {
        AbrirForm AF;
        public V_Inicio()
        {
            InitializeComponent();
            AF = new AbrirForm();
        }

        private void Inicio_Load(object sender, EventArgs e) { }

        private void BtnSeguridad_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Seguridad(this), PnlContenedor, true);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Clientes(this), PnlContenedor, true);
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Productos(this), PnlContenedor, true);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            AF.Abrir(new V_Pedidos(this), PnlContenedor, true);
        }

        private void V_Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            AF.CerrarFormActual();
            Application.Exit(); 
        }
    }
}
