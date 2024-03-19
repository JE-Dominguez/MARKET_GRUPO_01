using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Usuarios
    {
        Repository<Usuarios> _repository;

        public D_Usuarios()
        {
            _repository = new Repository<Usuarios>();
        }

        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarUsuario(Usuarios usuario)
        {
            usuario.FechaCreacion = DateTime.Now;
            usuario.FechaModificacion = DateTime.Now;
            usuario.UsuarioCreador = "JDOMINGUEZ";
            usuario.UsuarioModifica = "JDOMINGUEZ";
            _repository.Agregar(usuario);
            return 1;
        }

        public int EditarUsuario(Usuarios usuario)
        {
            var usuarioEnDB = _repository.Consulta().FirstOrDefault(u => u.ID == usuario.ID);

            if (usuarioEnDB != null)
            {
                usuarioEnDB.Nombre = usuario.Nombre;
                usuarioEnDB.Apellido = usuario.Apellido;
                usuarioEnDB.Contraseña = usuario.Contraseña;
                usuarioEnDB.Correo = usuario.Correo;
                usuarioEnDB.RolID = usuario.RolID;
                usuarioEnDB.FechaModificacion = DateTime.Now;
                usuarioEnDB.UsuarioModifica = "JDOMINGUEZ";
                usuarioEnDB.Estado = usuario.Estado;
                _repository.Editar(usuarioEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarUsuario(int usuarioId)
        {
            var usuarioEnDB = _repository.Consulta().FirstOrDefault(u => u.ID == usuarioId);
            if (usuarioEnDB != null)
            {
                _repository.Eliminar(usuarioEnDB);
                return 1;
            }
            return 0;
        }
    }
}

