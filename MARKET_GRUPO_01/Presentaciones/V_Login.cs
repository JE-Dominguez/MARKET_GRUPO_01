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
                this.Hide(); // Oculta el formulario actual (formulario de inicio de sesión)
                var inicioForm = new V_Inicio();
                inicioForm.Show(); // Muestra el formulario de inicio
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
    }
}
