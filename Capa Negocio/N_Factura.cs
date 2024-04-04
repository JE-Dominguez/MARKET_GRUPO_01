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
    }
}
