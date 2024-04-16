using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class D_FacturaDetalle
    {
        private readonly UnitOfWork _unitOfWork;

        public D_FacturaDetalle()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<FacturaDetalle> ObtenerTodosFacturasDetalle()
        {
            return _unitOfWork.Repository<FacturaDetalle>().Consulta().ToList();
        }

        public int AgregarFaturaDetalle(FacturaDetalle facturaDetalle)
        {
            facturaDetalle.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<FacturaDetalle>().Agregar(facturaDetalle);
            return _unitOfWork.Guardar();
        }

        public int EditarFacturaDetalle(FacturaDetalle facturaDetalle)
        {
            var FacturaDetalleEnDB = _unitOfWork.Repository<FacturaDetalle>().Consulta().FirstOrDefault(p => p.FacturaId == facturaDetalle.FacturaDetalleId);

            if (FacturaDetalleEnDB != null)
            {
                FacturaDetalleEnDB.FacturaId = facturaDetalle.FacturaId;
                FacturaDetalleEnDB.ProductoId = facturaDetalle.ProductoId;
                FacturaDetalleEnDB.Precio = facturaDetalle.Precio;
                FacturaDetalleEnDB.Total = facturaDetalle.Total;
                FacturaDetalleEnDB.Subtotal = facturaDetalle.Subtotal;
                FacturaDetalleEnDB.Descuento = facturaDetalle.Descuento;
                _unitOfWork.Repository<FacturaDetalle>().Editar(FacturaDetalleEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

        public int EliminarFacturaDetalle(int FacturaID)
        {
            var FacturaDetalleEnDB = _unitOfWork.Repository<FacturaDetalle>().Consulta().FirstOrDefault(p => p.FacturaDetalleId == FacturaID);
            if (FacturaDetalleEnDB != null)
            {
                _unitOfWork.Repository<FacturaDetalle>().Eliminar(FacturaDetalleEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
