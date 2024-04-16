using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class D_Factura
    {
        private readonly UnitOfWork _unitOfWork;

        public D_Factura()
        {
            _unitOfWork = new UnitOfWork();
        }
        public List<Factura> ObtenerTodalasFacturas()
        {
            return _unitOfWork.Repository<Factura>().Consulta().ToList();
        }
        public int AgregarFactura(Factura Factura)
        {
            Factura.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<Factura>().Agregar(Factura);
            return _unitOfWork.Guardar();
        }
        public int EditarFactura(Factura factura)
        {
            var FacturaEnDB = _unitOfWork.Repository<Factura>().Consulta().FirstOrDefault(r => r.FacturaId == factura.FacturaId);

            if (FacturaEnDB != null)
            {
                FacturaEnDB.ClienteId = factura.ClienteId;
                FacturaEnDB.PedidoId = factura.PedidoId;
                FacturaEnDB.Estado = factura.Estado;
                FacturaEnDB.Total = factura.Total;
                _unitOfWork.Repository<Factura>().Editar(FacturaEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
        public int EliminarFactura(int FacturaId)
        {
            var FacturaEnDB = _unitOfWork.Repository<Factura>().Consulta().FirstOrDefault(r => r.FacturaId == FacturaId);
            if (FacturaEnDB != null)
            {
                _unitOfWork.Repository<Factura>().Eliminar(FacturaEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
        public int CrearPedidoFactura(Factura factura, List<FacturaDetalle> detalle)
        {
            _unitOfWork.Repository<Factura>().Agregar(factura);
            _unitOfWork.Repository<FacturaDetalle>().AgregarRango(detalle);
            return _unitOfWork.Guardar();
        }
    }
}
