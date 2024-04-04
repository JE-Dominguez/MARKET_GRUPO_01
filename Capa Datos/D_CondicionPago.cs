using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_CondicionPago
    {
        private readonly UnitOfWork _unitOfWork;

        public D_CondicionPago()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<CondicionPago> ObtenerTodasLasCondicionesPago()
        {
            return _unitOfWork.Repository<CondicionPago>().Consulta().ToList();
        }

        public int AgregarCondicionPago(CondicionPago condicionPago)
        {
            condicionPago.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<CondicionPago>().Agregar(condicionPago);
            return 1;
        }

        public int EditarCondicionPago(CondicionPago condicionPago)
        {
            var condicionPagoEnDB = _unitOfWork.Repository<CondicionPago>().Consulta().FirstOrDefault(c => c.CondicionPagoId == condicionPago.CondicionPagoId);

            if (condicionPagoEnDB != null)
            {
                condicionPagoEnDB.Codigo = condicionPago.Codigo;
                condicionPagoEnDB.Descripcion = condicionPago.Descripcion;
                condicionPagoEnDB.Estado = condicionPago.Estado;
                condicionPagoEnDB.Dias = condicionPago.Dias;
                _unitOfWork.Repository<CondicionPago>().Editar(condicionPagoEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarCondicionPago(int condicionPagoId)
        {
            var condicionPagoEnDB = _unitOfWork.Repository<CondicionPago>().Consulta().FirstOrDefault(c => c.CondicionPagoId == condicionPagoId);
            if (condicionPagoEnDB != null)
            {
                _unitOfWork.Repository<CondicionPago>().Eliminar(condicionPagoEnDB);
                return 1;
            }
            return 0;
        }
    }
}
