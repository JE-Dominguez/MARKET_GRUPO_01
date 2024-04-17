using Capa_Datos.Core;
using Capa_Datos.Modelos;
using Capa_Negocio;
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
            rol.UsuarioCreador = D_ParametrosActivos.Usuario;
            rol.UsuarioModifica = D_ParametrosActivos.Usuario;
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
                rolEnDB.UsuarioModifica = D_ParametrosActivos.Usuario;
                rolEnDB.Estado = rol.Estado;

                // Incorporando las propiedades booleanas
                rolEnDB.p_pedidos = rol.p_pedidos;
                rolEnDB.p_detalles = rol.p_detalles;
                rolEnDB.p_facturas = rol.p_facturas;
                rolEnDB.p_detallesFac = rol.p_detallesFac;

                rolEnDB.pr_productos = rol.pr_productos;
                rolEnDB.pr_categorias = rol.pr_categorias;
                rolEnDB.pr_unidadMedida = rol.pr_unidadMedida;
                rolEnDB.pr_impuesto = rol.pr_impuesto;

                rolEnDB.cl_clientes = rol.cl_clientes;
                rolEnDB.cl_grupodescuentos = rol.cl_grupodescuentos;
                rolEnDB.cl_condicionpago = rol.cl_condicionpago;

                rolEnDB.seg_usuarios = rol.seg_usuarios;
                rolEnDB.seg_roles = rol.seg_roles;

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
