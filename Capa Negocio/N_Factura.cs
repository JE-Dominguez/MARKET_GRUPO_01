using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_Factura
    {
        D_Factura dFactura;

        public N_Factura()
        {
            dFactura = new D_Factura();
        }

        public List<Factura> ObtenerFactura()
        {
            return dFactura.ObtenerTodalasFacturas();
        }

        public List<object> ObtenerFacturaGrid()
        {
            return dFactura.ObtenerTodalasFacturas().Select(u => new { u.FacturaId, Cliente = u.Clientes.Nombres + " " + u.Clientes.Apellidos, u.PedidoId, u.Descuento, u.Subtotal, u.Total, u.FechaFactura, u.Estado }).ToList<object>();
        }

        public int GuardarProducto(Factura factura)
        {
            if (factura.FacturaId == 0)
            {
                return dFactura.AgregarFactura(factura);
            }
            else
            {
                return dFactura.EditarFactura(factura);
            }
        }

        public int EliminarFactura(int FacturaId)
        {
            return dFactura.EliminarFactura(FacturaId);
        }
        public int CrearFactura(Factura factura, List<FacturaDetalle> detalle)
        {
            return dFactura.CrearPedidoFactura(factura, detalle);
        }
    }
}
