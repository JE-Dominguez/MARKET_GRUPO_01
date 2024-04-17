using Capa_Datos;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class N_Usuarios
    {
        D_Usuarios dUsuario;

        public N_Usuarios()
        {
            dUsuario = new D_Usuarios();
        }

        public List<Usuarios> ObtenerUsuarios()
        {
            return dUsuario.ObtenerTodosLosUsuarios();
        }

        public List<object> ObtenerUsuariosGrid()
        {
            var usuarios = dUsuario.ObtenerTodosLosUsuarios().Select(u => new { UsuarioID = u.ID, Nombre = u.Nombre + " " + u.Apellido, u.Correo, u.Rol.NombreRol, u.UsuarioCreador, u.FechaCreacion, u.Estado }).ToList<object>();
            return usuarios;
        }

        public int GuardarUsuario(Usuarios usuario)
        {
            if (usuario.ID == 0)
            {
                return dUsuario.AgregarUsuario(usuario);
            }
            else
            {
                return dUsuario.EditarUsuario(usuario);
            }
        }

        public int EliminarUsuario(int usuarioId)
        {
            return dUsuario.EliminarUsuario(usuarioId);
        }
    }
}
