using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MARKET_GRUPO_01.Presentaciones;

namespace MARKET_GRUPO_01
{
    public class AbrirForm
    {
        private Form formActual;
        public AbrirForm()
        {
        }

        public void Abrir(Form formHijo, Panel panelContenedor, bool permiso)
        {
            if (permiso == true)
            {
                CerrarFormActual();
                formActual = formHijo;

                formHijo.TopLevel = false;
                formHijo.FormBorderStyle = FormBorderStyle.None;
                formHijo.Dock = DockStyle.Fill;

                panelContenedor.Controls.Add(formHijo);
                panelContenedor.Tag = formHijo;

                formHijo.Show();
            }
            else
            {
                MessageBox.Show("ROL No cuenta con los permisos suficientes para ingresar a esta opcion", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void CerrarFormActual()
        {
            if (formActual != null)
            {
                formActual.Close();
            }
        }

        public void Inicio()
        {
            CerrarFormActual();
        }
        public void VentanaEmergente(Form form, V_Inicio Ini, bool permiso)
        {
            if (permiso == true)
            {
                Form formBG = new Form();

                // Configurar el formulario de fondo
                formBG.TopLevel = false;
                formBG.FormBorderStyle = FormBorderStyle.None;
                formBG.Dock = DockStyle.Fill;
                formBG.StartPosition = FormStartPosition.Manual;
                formBG.BackColor = Color.FromArgb(220, 222, 228);
                formBG.WindowState = FormWindowState.Maximized;
                formBG.ShowInTaskbar = false;
                formBG.TopMost = true;

                // Agregar el formulario de fondo al panel contenedor
                Ini.pnlPrincipal.Controls.Add(formBG);
                Ini.pnlPrincipal.Tag = formBG;

                // Establecer opacidad después de que el formulario esté completamente configurado
                formBG.Opacity = 0.70d;

                // Mostrar el formulario de fondo y vincularlo con el formulario principal
                formBG.Show();
                form.Owner = formBG;
                form.StartPosition = FormStartPosition.CenterScreen;

                // Mostrar el formulario principal como un diálogo modal
                form.ShowDialog();

                // Limpiar recursos
                formBG.Dispose();
            }
            else
            {
                MessageBox.Show("ROL No cuenta con los permisos suficientes para ingresar a esta opcion", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
}
