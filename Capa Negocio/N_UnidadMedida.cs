using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_UnidadMedida
    {
        D_UnidadMedida dUnidadMedida;

        public N_UnidadMedida()
        {
            dUnidadMedida = new D_UnidadMedida();
        }

        public List<UnidadMedida> ObtenerUnidadesMedida()
        {
            return dUnidadMedida.ObtenerTodasLasUnidadesMedida();
        }
        public List<object> ObtenerUnidadesMedidaGrid()
        {
            var unidadMedida = dUnidadMedida.ObtenerTodasLasUnidadesMedida().ToList()
                                       .Select(um => new { um.UnidadMedidaId, um.Codigo, um.Descripcion, um.FechaCreacion, um.Estado })
                                       .ToList<object>();
            return unidadMedida;
        }

        public int GuardarUnidadMedida(UnidadMedida unidadMedida)
        {
            if (unidadMedida.UnidadMedidaId == 0)
            {
                return dUnidadMedida.AgregarUnidadMedida(unidadMedida);
            }
            else
            {
                return dUnidadMedida.EditarUnidadMedida(unidadMedida);
            }
        }

        public int EliminarUnidadMedida(int unidadMedidaId)
        {
            return dUnidadMedida.EliminarUnidadMedida(unidadMedidaId);
        }
    }
}
