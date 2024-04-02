using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    internal class N_PedidoDetalle
    {
        N_PedidoDetalle dPedidoDetalle;

        public N_PedidoDetalle)
        {
            dPedidoDetalle = new PedidoDetalle();
        }

        public List<PedidoDetalle> Obtener PedidoDetalle()
        {
            return dPedidoDetalle.ObtenerTodoslosPedidosDetalles();
        }

        public int GuardarPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            if (PedidoDetalle.PedidoDetalleId == 0)
            {
                return PedidoDetalle.AgregarPedidodetalle(PedidoDetalle);
            }
            else
            {
                return PedidoDetalle.EditarPedidoDetalle(PedidoDetalle);
            }
        }

        public int EliminarPedidoDetalle(int PedidoDetalle)
        {
            return PedidoDetalle.EliminarPedidoDetalle(PedidoDetalle);
        }



    }
}
