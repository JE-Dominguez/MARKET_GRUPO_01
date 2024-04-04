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
        private readonly UnitOfWork _unitOfWork;
        public D_Pedido()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Pedido> ObtenerTodalasFacturas()
        {
            return _unitOfWork.Repository<Pedido>().Consulta().ToList();
        }

        public int AgregarPedido(Pedido pedido)
        {
            pedido.FechaCreacion = DateTime.Now;
            pedido.FechaPedido = DateTime.Now;
            _unitOfWork.Repository<Pedido>().Agregar(pedido);
            return 1;
        }

        public int EditarPedido(Pedido pedido)
        {
            var PedidoEnDB = _unitOfWork.Repository<Pedido>().Consulta().FirstOrDefault(r => r.PedidoId == pedido.PedidoId);

            if (PedidoEnDB != null)
            {
                PedidoEnDB.ClienteId = pedido.ClienteId;
                PedidoEnDB.Estado = pedido.Estado;
                PedidoEnDB.Total = pedido.Total;
                PedidoEnDB.Subtotal = pedido.Subtotal;
                PedidoEnDB.Descuento = pedido.Descuento;
                _unitOfWork.Repository<Pedido>().Editar(PedidoEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarPedido(int PedidoId)
        {
            var PedidoEnDB = _unitOfWork.Repository<Pedido>().Consulta().FirstOrDefault(r => r.PedidoId == PedidoId);
            if (PedidoEnDB != null)
            {
                _unitOfWork.Repository<Pedido>().Eliminar(PedidoEnDB);
                return 1;
            }
            return 0;
        }


    }
}
