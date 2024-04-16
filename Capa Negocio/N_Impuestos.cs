using Capa_Datos;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_Impuestos
    {
        D_Impuestos d_Impuestos;
        public N_Impuestos()
        {
            d_Impuestos = new D_Impuestos();
        }
        public List<Impuestos> ObtenerImpuestoss()
        {
            return d_Impuestos.ObtenerTodosLosImpuestos();
        }

        public int GuardarImpuestos(Impuestos impuestos)
        {
            if (impuestos.ImpuestoId == 0)
            {
                return d_Impuestos.AgregarImpuestos(impuestos);
            }
            else
            {
                return d_Impuestos.EditarImpuestos(impuestos);
            }
        }

        public int EliminarImpuestos(int ImpuestosId)
        {
            return d_Impuestos.EliminarImpuestos(ImpuestosId);
        }
    }
}
