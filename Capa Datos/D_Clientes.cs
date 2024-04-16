using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Clientes
    {
        private readonly UnitOfWork _unitOfWork;
        public D_Clientes()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Clientes> ObtenerTodosLosClientes()
        {
            return _unitOfWork.Repository<Clientes>().Consulta().ToList();
        }

        public int AgregarCliente(Clientes cliente)
        {
            cliente.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<Clientes>().Agregar(cliente);
            return _unitOfWork.Guardar();
        }

        public int EditarCliente(Clientes cliente)
        {
            var clienteEnDB = _unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.ClienteId == cliente.ClienteId);

            if (clienteEnDB != null)
            {
                clienteEnDB.Codigo = cliente.Codigo;
                clienteEnDB.Nombres = cliente.Nombres;
                clienteEnDB.Apellidos = cliente.Apellidos;
                clienteEnDB.GrupoDescuentoId = cliente.GrupoDescuentoId;
                clienteEnDB.CondicionPagoId = cliente.CondicionPagoId;
                clienteEnDB.Estado = cliente.Estado;
                _unitOfWork.Repository<Clientes>().Editar(clienteEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

        public int EliminarCliente(int clienteId)
        {
            var clienteEnDB = _unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.ClienteId == clienteId);
            if (clienteEnDB != null)
            {
                _unitOfWork.Repository<Clientes>().Eliminar(clienteEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
