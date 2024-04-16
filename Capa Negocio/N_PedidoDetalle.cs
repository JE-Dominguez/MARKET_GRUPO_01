using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_PedidoDetalle
    {
        D_PedidoDatalle dPedidoDetalle;

        public N_PedidoDetalle()
        {
            dPedidoDetalle = new D_PedidoDatalle();
        }

        public List<PedidoDetalle> ObtenerPedidoDetalle()
        {
            return dPedidoDetalle.ObtenerTodalospedidoDetalle();
        }
        public List<object> ObtenerPedidoDetalleGrid(int id)
        {
            var DetallesPedido = dPedidoDetalle.ObtenerTodalospedidoDetalle();
            var DetallesPedidoFil = DetallesPedido.Where(u => u.PedidoId == id);
            return DetallesPedidoFil.Select(prd => new { prd.PedidoDetalleId, prd.PedidoId, prd.ProductoId, Codigo = prd.CodigoProducto, prd.Descripcion, prd.Precio, prd.Impuesto, prd.Subtotal, prd.Total, prd.FechaPedido }).ToList<object>();
        }

        public int GuardarPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            if (pedidoDetalle.PedidoDetalleId == 0)
            {
                return dPedidoDetalle.AgregarPedidoDetalle(pedidoDetalle);
            }
            else
            {
                return dPedidoDetalle.EditarPedidoDetalle(pedidoDetalle);
            }
        }

        public int EliminarPedidoDetalle(int PedidoDetalleID)
        {
            return dPedidoDetalle.EliminarPedidoDetalle(PedidoDetalleID);
        }
        public int EliminarPedidoConDetalle(int ID)
        {
            return dPedidoDetalle.EliminarPedidoConDetalle(ID);
        }



    }
}
