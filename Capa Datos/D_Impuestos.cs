using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class D_Impuestos
    {
        private readonly UnitOfWork _unitOfWork;
        public D_Impuestos()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<Impuestos> ObtenerTodosLosImpuestos()
        {
            return _unitOfWork.Repository<Impuestos>().Consulta().ToList();
        }

        public int AgregarImpuestos(Impuestos impuestos)
        {
            _unitOfWork.Repository<Impuestos>().Agregar(impuestos);
            return _unitOfWork.Guardar();
        }

        public int EditarImpuestos(Impuestos impuestos)
        {
            var ImpuestosEnDB = _unitOfWork.Repository<Impuestos>().Consulta().FirstOrDefault(r => r.ImpuestoId == impuestos.ImpuestoId);

            if (ImpuestosEnDB != null)
            {
                ImpuestosEnDB.ImpuestoId = impuestos.ImpuestoId;
                ImpuestosEnDB.Estado = impuestos.Estado;
                ImpuestosEnDB.Porcentaje = impuestos.Porcentaje;
                ImpuestosEnDB.Codigo = impuestos.Codigo;
                _unitOfWork.Repository<Impuestos>().Editar(ImpuestosEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

        public int EliminarImpuestos(int impuestosId)
        {
            var ImpuestosEnDB = _unitOfWork.Repository<Impuestos>().Consulta().FirstOrDefault(r => r.ImpuestoId == impuestosId);
            if (ImpuestosEnDB != null)
            {
                _unitOfWork.Repository<Impuestos>().Eliminar(ImpuestosEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
