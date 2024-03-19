using Capa_Datos;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class N_Roles
    {
        D_Roles dRol;

        public N_Roles()
        {
            dRol = new D_Roles();
        }

        public List<Roles> ObtenerRoles()
        {
            return dRol.ObtenerTodosLosRoles();
        }

        public List<object> ObtenerRolesGrid()
        {
            var roles = dRol.ObtenerTodosLosRoles().Select(r => new { r.RolID, r.NombreRol, r.Descripcion, r.FechaCreacion, r.UsuarioCreador }).ToList<object>();
            return roles;
        }

        public int GuardarRol(Roles rol)
        {
            if (rol.RolID == 0)
            {
                return dRol.AgregarRol(rol);
            }
            else
            {
                return dRol.EditarRol(rol);
            }
        }

        public int EliminarRol(int rolId)
        {
            return dRol.EliminarRol(rolId);
        }
    }
}
