using Capa_Negocio;
using Capa_Negocios;
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
    public partial class V_Login : Form
    {
        private readonly N_Usuarios _usarios;
        public V_Login()
        {
            InitializeComponent();
            _usarios = new N_Usuarios();
        }
        public bool VerificarCredenciales(string Usuario, string contraseña)
        {
            var usuario = _usarios.ObtenerUsuarios().FirstOrDefault(u => u.Usuario == Usuario && u.Contraseña == contraseña);
            if (usuario != null)
            {
                // Llenar los parámetros activos con los datos del usuario
                D_ParametrosActivos.UsuarioID = usuario.ID;
                D_ParametrosActivos.Usuario = usuario.Usuario;
                D_ParametrosActivos.Nombre = usuario.Nombre;
                D_ParametrosActivos.Apellido = usuario.Apellido;
                D_ParametrosActivos.Correo = usuario.Correo;
                D_ParametrosActivos.UsuarioInicio = usuario.FechaCreacion.ToString("dd MMMM, yyyy");
                D_ParametrosActivos.Rol = usuario.Rol.NombreRol;
                D_ParametrosActivos.fechamodifica = usuario.FechaModificacion.ToString("dd MMMM, yyyy");
                D_ParametrosActivos.FechaInicio = DateTime.Now.ToString("dd MMMM, yyyy");

                // Asignar valores de los permisos de roles del usuario
                D_ParametrosActivos.p_pedidos = usuario.Rol.p_pedidos;
                D_ParametrosActivos.p_detalles = usuario.Rol.p_detalles;
                D_ParametrosActivos.p_facturas = usuario.Rol.p_facturas;
                D_ParametrosActivos.p_detallesFac = usuario.Rol.p_detallesFac;
                D_ParametrosActivos.pr_productos = usuario.Rol.pr_productos;
                D_ParametrosActivos.pr_categorias = usuario.Rol.pr_categorias;
                D_ParametrosActivos.pr_unidadMedida = usuario.Rol.pr_unidadMedida;
                D_ParametrosActivos.pr_impuesto = usuario.Rol.pr_impuesto;
                D_ParametrosActivos.cl_clientes = usuario.Rol.cl_clientes;
                D_ParametrosActivos.cl_grupodescuentos = usuario.Rol.cl_grupodescuentos;
                D_ParametrosActivos.cl_condicionpago = usuario.Rol.cl_condicionpago;
                D_ParametrosActivos.seg_usuarios = usuario.Rol.seg_usuarios;
                D_ParametrosActivos.seg_roles = usuario.Rol.seg_roles;

                this.Hide();
                var inicioForm = new V_Inicio();
                inicioForm.Show(); 
                return true;
            }
            else
            {
                MessageBox.Show("No se encontró coincidencia con ninguna credencial.");
                return false;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            VerificarCredenciales(TxtUsuario.Text, TxtContraseña.Text);
        }

        private void V_Login_FormClosed(object sender, FormClosedEventArgs e) { }

        private void V_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
