using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    internal class D_Pedido
    {
        repository<D_Pedido> _repository;

        public object FacturaEnDB { get; private set; }

        public D_Pedido()
        {
            _repository = new Repository<Pedido>();
        }

        public List<Pedido> ObtenerTodalasFacturas()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarCategoria(Pedido pedido)
        {
            pedido.FechaCreacion = DateTime.Now;
            _repository.Agregar(pedido);
            return 1;
        }

        public int EditarFactura(Pedido pedido)
        {
            var PedidoEnDB = _repository.Consulta().FirstOrDefault(r => r.CategoriaId == Pedido.PedidoId);

            if (PedidoEnDB != null)
            {
                PedidoEnDB.ClienteID = Pedido.ClienteiD;
                PedidoEnDB.Estado = Pedido.Estado;
                PedidoEnDB.Total = Pedido.Total;
                PedidoEnDB.SubTotal = Pedido.SubTotal;
                PedidoEnDB.Descuento = Pedido.Descuento;
                _repository.Editar(PedidoEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarPedido(int PedidoId)
        {
            var PedidoEnDB = _repository.Consulta().FirstOrDefault(r => r.FacturaId == PedidoId);
            if (PedidoEnDB != null)
            {
                _repository.Eliminar( PedidoEnDB);
                return 1;
            }
            return 0;
        }

         
    }
}
