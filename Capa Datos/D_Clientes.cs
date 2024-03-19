using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Clientes
    {
        Repository<Clientes> _repository;

        public D_Clientes()
        {
            _repository = new Repository<Clientes>();
        }

        public List<Clientes> ObtenerTodosLosClientes()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarCliente(Clientes cliente)
        {
            cliente.FechaCreacion = DateTime.Now;
            _repository.Agregar(cliente);
            return 1;
        }

        public int EditarCliente(Clientes cliente)
        {
            var clienteEnDB = _repository.Consulta().FirstOrDefault(c => c.ClienteId == cliente.ClienteId);

            if (clienteEnDB != null)
            {
                clienteEnDB.Codigo = cliente.Codigo;
                clienteEnDB.Nombres = cliente.Nombres;
                clienteEnDB.Apellidos = cliente.Apellidos;
                clienteEnDB.GrupoDescuentoId = cliente.GrupoDescuentoId;
                clienteEnDB.CondicionPagoId = cliente.CondicionPagoId;
                clienteEnDB.Estado = cliente.Estado;
                _repository.Editar(clienteEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarCliente(int clienteId)
        {
            var clienteEnDB = _repository.Consulta().FirstOrDefault(c => c.ClienteId == clienteId);
            if (clienteEnDB != null)
            {
                _repository.Eliminar(clienteEnDB);
                return 1;
            }
            return 0;
        }
    }
}
