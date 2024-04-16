using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_PEDIDO
    {
        D_Pedido dPedido;

        public N_PEDIDO()
        {
            dPedido = new D_Pedido();
        }

        public List<Pedido> ObtenerPedidos()
        {
            return dPedido.ObtenerTodosLosPedido();
        }
        public List<object> ObtenerPedidosGrid()
        {
            try
            {
                var pedidos = dPedido.ObtenerTodosLosPedido().Select(prd => new { prd.PedidoId, Cliente = prd.Clientes.Nombres + " " + prd.Clientes.Apellidos, prd.Descuento, prd.Impuesto, prd.Subtotal, prd.Total, prd.FechaPedido, prd.Estado }).ToList<object>();

                return pedidos.ToList();
            }
            catch
            {
                return new List<object>();
            }
        }


        public int GuardarPedido(Pedido Pedido)
        {
            if (Pedido.PedidoId == 0)
            {
                return dPedido.AgregarPedido(Pedido);
            }
            else
            {
                return dPedido.EditarPedido(Pedido);
            }
        }

        public int EliminarPedido(int PedidoId)
        {
            return dPedido.EliminarPedido(PedidoId);
        }
        public int CrearPedido(Pedido pedido, List<PedidoDetalle> detalle)
        {
            return dPedido.CrearPedido(pedido, detalle);
        }
    }
}
