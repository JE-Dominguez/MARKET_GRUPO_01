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
