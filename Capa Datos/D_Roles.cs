using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Roles
    {
        Repository<Roles> _repository;
        public D_Roles()
        {
            _repository = new Repository<Roles>();
        }

        public List<Roles> ObtenerTodosLosRoles()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarRol(Roles rol)
        {
            rol.FechaCreacion = DateTime.Now;
            rol.FechaModificacion = DateTime.Now;
            rol.UsuarioCreador = "JDOMINGUEZ";
            rol.UsuarioModifica = "JDOMINGUEZ";
            _repository.Agregar(rol);
            return 1;
        }

        public int EditarRol(Roles rol)
        {
            var rolEnDB = _repository.Consulta().FirstOrDefault(r => r.RolID == rol.RolID);

            if (rolEnDB != null)
            {
                rolEnDB.NombreRol = rol.NombreRol;
                rolEnDB.Descripcion = rol.Descripcion;
                rolEnDB.FechaModificacion = DateTime.Now;
                rolEnDB.UsuarioModifica = rol.UsuarioModifica;
                rolEnDB.Estado = rol.Estado;
                _repository.Editar(rolEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarRol(int rolId)
        {
            var rolEnDB = _repository.Consulta().FirstOrDefault(r => r.RolID == rolId);
            if (rolEnDB != null)
            {
                _repository.Eliminar(rolEnDB);
                return 1;
            }
            return 0;
        }
    }
}
