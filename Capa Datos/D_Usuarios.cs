﻿using Capa_Datos.Core;
using Capa_Datos.Modelos;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Usuarios
    {
        private readonly UnitOfWork _unitOfWork;

        public D_Usuarios()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            return _unitOfWork.Repository<Usuarios>().Consulta().ToList();
        }

        public int AgregarUsuario(Usuarios usuario)
        {
            usuario.FechaCreacion = DateTime.Now;
            usuario.FechaModificacion = DateTime.Now;
            usuario.UsuarioCreador = D_ParametrosActivos.Usuario;
            usuario.UsuarioModifica = D_ParametrosActivos.Usuario;
            _unitOfWork.Repository<Usuarios>().Agregar(usuario);
            return _unitOfWork.Guardar();
        }

        public int EditarUsuario(Usuarios usuario)
        {
            var usuarioEnDB = _unitOfWork.Repository<Usuarios>().Consulta().FirstOrDefault(u => u.ID == usuario.ID);

            if (usuarioEnDB != null)
            {
                usuarioEnDB.Nombre = usuario.Nombre;
                usuarioEnDB.Apellido = usuario.Apellido;
                usuarioEnDB.Contraseña = usuario.Contraseña;
                usuarioEnDB.Correo = usuario.Correo;
                usuarioEnDB.RolID = usuario.RolID;
                usuarioEnDB.FechaModificacion = DateTime.Now;
                usuarioEnDB.UsuarioModifica = D_ParametrosActivos.Usuario;
                usuarioEnDB.Estado = usuario.Estado;
                _unitOfWork.Repository<Usuarios>().Editar(usuarioEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

        public int EliminarUsuario(int usuarioId)
        {
            var usuarioEnDB = _unitOfWork.Repository<Usuarios>().Consulta().FirstOrDefault(u => u.ID == usuarioId);
            if (usuarioEnDB != null)
            {
                _unitOfWork.Repository<Usuarios>().Eliminar(usuarioEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}

