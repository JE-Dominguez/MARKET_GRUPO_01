using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    internal class N_FacturaDetalle
    {
        D_FacturaDetalle dFacturaDetalle 

        public N_FacturaDetalle()
        {
            dFacturaDetalle = new N_FacturaDetalle();
        }

        public List<D_FacturaDetalle> ObtenerFacturaDetalle()
        {
            return dFacturaDetalle.ObtenerTodosLasFacturaDetalle();
        }

        public int GuardarFacturaDetalle(D_FacturaDetalle facturaDetalle)
        {
            if (dFacturaDetalle.FacturaDetalleId == 0)
            {
                return dFacturaDetalle.AgregarFacturaDetalle(D_FacturaDetalle);
            }
            else
            {
                return dFacturaDetalle.EditarFacturaDetalle(cliente);
            }
        }

        public int EliminarFacturaDetalle(int FacturaDetalleId)
        {
            return dFacturaDetalle.EliminarFacturaDetalle(clienteId);
        }


    }
}
