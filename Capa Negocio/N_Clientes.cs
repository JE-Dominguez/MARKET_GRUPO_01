using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_Clientes
    {
        D_Clientes dCliente;

        public N_Clientes()
        {
            dCliente = new D_Clientes();
        }

        public List<Clientes> ObtenerClientes()
        {
            return dCliente.ObtenerTodosLosClientes();
        }

        public int GuardarCliente(Clientes cliente)
        {
            if (cliente.ClienteId == 0)
            {
                return dCliente.AgregarCliente(cliente);
            }
            else
            {
                return dCliente.EditarCliente(cliente);
            }
        }

        public int EliminarCliente(int clienteId)
        {
            return dCliente.EliminarCliente(clienteId);
        }
    }
}
