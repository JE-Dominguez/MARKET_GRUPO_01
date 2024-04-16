using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Roles
    {
        private readonly UnitOfWork _unitOfWork;
        public D_Roles()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Roles> ObtenerTodosLosRoles()
        {
            return _unitOfWork.Repository<Roles>().Consulta().ToList();
        }

        public int AgregarRol(Roles rol)
        {
            rol.FechaCreacion = DateTime.Now;
            rol.FechaModificacion = DateTime.Now;
            rol.UsuarioCreador = "JDOMINGUEZ";
            rol.UsuarioModifica = "JDOMINGUEZ";
            _unitOfWork.Repository<Roles>().Agregar(rol);
            return _unitOfWork.Guardar();
        }

        public int EditarRol(Roles rol)
        {
            var rolEnDB = _unitOfWork.Repository<Roles>().Consulta().FirstOrDefault(r => r.RolID == rol.RolID);

            if (rolEnDB != null)
            {
                rolEnDB.NombreRol = rol.NombreRol;
                rolEnDB.Descripcion = rol.Descripcion;
                rolEnDB.FechaModificacion = DateTime.Now;
                rolEnDB.UsuarioModifica = "rol.UsuarioModifica";
                rolEnDB.Estado = rol.Estado;
                _unitOfWork.Repository<Roles>().Editar(rolEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

        public int EliminarRol(int rolId)
        {
            var rolEnDB = _unitOfWork.Repository<Roles>().Consulta().FirstOrDefault(r => r.RolID == rolId);
            if (rolEnDB != null)
            {
                _unitOfWork.Repository<Roles>().Eliminar(rolEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
