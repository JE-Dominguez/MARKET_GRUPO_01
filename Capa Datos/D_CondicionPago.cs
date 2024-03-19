using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_CondicionPago
    {
        Repository<CondicionPago> _repository;

        public D_CondicionPago()
        {
            _repository = new Repository<CondicionPago>();
        }

        public List<CondicionPago> ObtenerTodasLasCondicionesPago()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarCondicionPago(CondicionPago condicionPago)
        {
            condicionPago.FechaCreacion = DateTime.Now;
            _repository.Agregar(condicionPago);
            return 1;
        }

        public int EditarCondicionPago(CondicionPago condicionPago)
        {
            var condicionPagoEnDB = _repository.Consulta().FirstOrDefault(c => c.CondicionPagoId == condicionPago.CondicionPagoId);

            if (condicionPagoEnDB != null)
            {
                condicionPagoEnDB.Codigo = condicionPago.Codigo;
                condicionPagoEnDB.Descripcion = condicionPago.Descripcion;
                condicionPagoEnDB.Estado = condicionPago.Estado;
                condicionPagoEnDB.Dias = condicionPago.Dias;
                _repository.Editar(condicionPagoEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarCondicionPago(int condicionPagoId)
        {
            var condicionPagoEnDB = _repository.Consulta().FirstOrDefault(c => c.CondicionPagoId == condicionPagoId);
            if (condicionPagoEnDB != null)
            {
                _repository.Eliminar(condicionPagoEnDB);
                return 1;
            }
            return 0;
        }
    }
}
