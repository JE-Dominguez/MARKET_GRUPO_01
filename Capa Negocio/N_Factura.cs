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
        D_Factura dProducto;

        public N_Factura()
        {
            dProducto = new Fatura();
        }

        public List<Factura> ObtenerFactura()
        {
            return Factura.ObtenerTodosLasFacturas();
        }

        public int GuardarProducto(Factura factura)
        {
            if (Factura.FacturaId == 0)
            {
                return Factura.AgregarFactura(Factura);
            }
            else
            {
                return Factura.EditarFactura(Factura);
            }
        }

        public int EliminarFactura(int FacturaId)
        {
            return  Factura.EliminarFactura(FacturaId);
        }



    }

    internal class Fatura : D_Factura
    {
    }
}
