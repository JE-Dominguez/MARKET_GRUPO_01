using Capa_Datos.Modelos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class N_GrupoDescuento
    {
        D_GrupoDescuento dGrupoDescuento;

        public N_GrupoDescuento()
        {
            dGrupoDescuento = new D_GrupoDescuento();
        }

        public List<GrupoDescuento> ObtenerGruposDescuento()
        {
            return dGrupoDescuento.ObtenerTodosLosGruposDescuento();
        }

        public int GuardarGrupoDescuento(GrupoDescuento grupoDescuento)
        {
            if (grupoDescuento.GrupoDescuentoId == 0)
            {
                return dGrupoDescuento.AgregarGrupoDescuento(grupoDescuento);
            }
            else
            {
                return dGrupoDescuento.EditarGrupoDescuento(grupoDescuento);
            }
        }

        public int EliminarGrupoDescuento(int grupoDescuentoId)
        {
            return dGrupoDescuento.EliminarGrupoDescuento(grupoDescuentoId);
        }
    }
}
