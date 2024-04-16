using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_FacturaDetalle
    {
        D_FacturaDetalle dFacturaDetalle;

        public N_FacturaDetalle()
        {
            dFacturaDetalle = new D_FacturaDetalle();
        }

        public List<FacturaDetalle> ObtenerFacturaDetalle()
        {
            return dFacturaDetalle.ObtenerTodosFacturasDetalle();
        }
        public List<object> ObtenerFacturaDetalleGrid(int id)
        {
            var detallesFactura = dFacturaDetalle.ObtenerTodosFacturasDetalle();

            var detallesFiltrados = detallesFactura.Where(u => u.FacturaId == id);
            return detallesFiltrados.Select(u => new { u.FacturaDetalleId, u.FacturaId, u.Productos.Nombre, u.Precio, u.Descuento, u.Subtotal, u.Total, u.FechaFactura }).ToList<object>();
        }

        public int GuardarFacturaDetalle(FacturaDetalle facturaDetalle)
        {
            if (facturaDetalle.FacturaDetalleId == 0)
            {
                return dFacturaDetalle.AgregarFaturaDetalle(facturaDetalle);
            }
            else
            {
                return dFacturaDetalle.EditarFacturaDetalle(facturaDetalle);
            }
        }

        public int EliminarFacturaDetalle(int FacturaDetalleId)
        {
            return dFacturaDetalle.EliminarFacturaDetalle(FacturaDetalleId);
        }
    }
}
