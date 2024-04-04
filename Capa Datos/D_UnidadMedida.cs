using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_UnidadMedida
    {
        private readonly UnitOfWork _unitOfWork;

        public D_UnidadMedida()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<UnidadMedida> ObtenerTodasLasUnidadesMedida()
        {
            return _unitOfWork.Repository<UnidadMedida>().Consulta().ToList();
        }

        public int AgregarUnidadMedida(UnidadMedida unidadMedida)
        {
            unidadMedida.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<UnidadMedida>().Agregar(unidadMedida);
            return 1;
        }

        public int EditarUnidadMedida(UnidadMedida unidadMedida)
        {
            var unidadMedidaEnDB = _unitOfWork.Repository<UnidadMedida>().Consulta().FirstOrDefault(u => u.UnidadMedidaId == unidadMedida.UnidadMedidaId);

            if (unidadMedidaEnDB != null)
            {
                unidadMedidaEnDB.Codigo = unidadMedida.Codigo;
                unidadMedidaEnDB.Descripcion = unidadMedida.Descripcion;
                unidadMedidaEnDB.Estado = unidadMedida.Estado;
                _unitOfWork.Repository<UnidadMedida>().Editar(unidadMedidaEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarUnidadMedida(int unidadMedidaId)
        {
            var unidadMedidaEnDB = _unitOfWork.Repository<UnidadMedida>().Consulta().FirstOrDefault(u => u.UnidadMedidaId == unidadMedidaId);
            if (unidadMedidaEnDB != null)
            {
                _unitOfWork.Repository<UnidadMedida>().Eliminar(unidadMedidaEnDB);
                return 1;
            }
            return 0;
        }
    }
}
