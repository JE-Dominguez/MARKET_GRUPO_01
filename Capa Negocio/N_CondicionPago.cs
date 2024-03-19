using Capa_Datos;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_CondicionPago
    {
        D_CondicionPago dCondicionPago;

        public N_CondicionPago()
        {
            dCondicionPago = new D_CondicionPago();
        }

        public List<CondicionPago> ObtenerCondicionesPago()
        {
            return dCondicionPago.ObtenerTodasLasCondicionesPago();
        }

        public int GuardarCondicionPago(CondicionPago condicionPago)
        {
            if (condicionPago.CondicionPagoId == 0)
            {
                return dCondicionPago.AgregarCondicionPago(condicionPago);
            }
            else
            {
                return dCondicionPago.EditarCondicionPago(condicionPago);
            }
        }

        public int EliminarCondicionPago(int condicionPagoId)
        {
            return dCondicionPago.EliminarCondicionPago(condicionPagoId);
        }
    }
}
