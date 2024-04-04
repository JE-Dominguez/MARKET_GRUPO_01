using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_GrupoDescuento
    {
        private readonly UnitOfWork _unitOfWork;

        public D_GrupoDescuento()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<GrupoDescuento> ObtenerTodosLosGruposDescuento()
        {
            return _unitOfWork.Repository<GrupoDescuento>().Consulta().ToList();
        }

        public int AgregarGrupoDescuento(GrupoDescuento grupoDescuento)
        {
            grupoDescuento.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<GrupoDescuento>().Agregar(grupoDescuento);
            return 1;
        }

        public int EditarGrupoDescuento(GrupoDescuento grupoDescuento)
        {
            var grupoDescuentoEnDB = _unitOfWork.Repository<GrupoDescuento>().Consulta().FirstOrDefault(g => g.GrupoDescuentoId == grupoDescuento.GrupoDescuentoId);

            if (grupoDescuentoEnDB != null)
            {
                grupoDescuentoEnDB.Codigo = grupoDescuento.Codigo;
                grupoDescuentoEnDB.Descripcion = grupoDescuento.Descripcion;
                grupoDescuentoEnDB.Estado = grupoDescuento.Estado;
                grupoDescuentoEnDB.Porcentaje = grupoDescuento.Porcentaje;
                _unitOfWork.Repository<GrupoDescuento>().Editar(grupoDescuentoEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarGrupoDescuento(int grupoDescuentoId)
        {
            var grupoDescuentoEnDB = _unitOfWork.Repository<GrupoDescuento>().Consulta().FirstOrDefault(g => g.GrupoDescuentoId == grupoDescuentoId);
            if (grupoDescuentoEnDB != null)
            {
                _unitOfWork.Repository<GrupoDescuento>().Eliminar(grupoDescuentoEnDB);
                return 1;
            }
            return 0;
        }
    }
}
