using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class D_PedidoDatalle
    {
        private readonly UnitOfWork _unitOfWork;

        public D_PedidoDatalle()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<PedidoDetalle> ObtenerTodalospedidoDetalle()
        {
            return _unitOfWork.Repository<PedidoDetalle>().Consulta().ToList();
        }

        public int AgregarPedidoDetalle(PedidoDetalle PedidoDetalle)
        {
            PedidoDetalle.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<PedidoDetalle>().Agregar(PedidoDetalle);
            return _unitOfWork.Guardar();
        }

        public int EditarPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            var PedidoDetalleEnDB = _unitOfWork.Repository<PedidoDetalle>().Consulta().FirstOrDefault(r => r.PedidoDetalleId == pedidoDetalle.PedidoDetalleId);

            if (PedidoDetalleEnDB != null)
            {
                PedidoDetalleEnDB.PedidoId = pedidoDetalle.PedidoId;
                PedidoDetalleEnDB.ProductoId = pedidoDetalle.ProductoId;
                PedidoDetalleEnDB.CodigoProducto = pedidoDetalle.CodigoProducto;
                PedidoDetalleEnDB.Descripcion = pedidoDetalle.Descripcion;
                PedidoDetalleEnDB.Cantidad = pedidoDetalle.Cantidad;
                PedidoDetalleEnDB.Precio = pedidoDetalle.Precio;
                PedidoDetalleEnDB.Total = pedidoDetalle.Total;
                PedidoDetalleEnDB.Subtotal = pedidoDetalle.Subtotal;
                PedidoDetalleEnDB.Descuento = pedidoDetalle.Descuento;
                PedidoDetalleEnDB.Impuesto = pedidoDetalle.Impuesto;
                PedidoDetalleEnDB.FechaPedido = pedidoDetalle.FechaPedido;
                _unitOfWork.Repository<PedidoDetalle>().Editar(PedidoDetalleEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

        public int EliminarPedidoDetalle(int PedidoDetalleId)
        {
            var PedidoDetalleEnDB = _unitOfWork.Repository<PedidoDetalle>().Consulta().FirstOrDefault(r => r.PedidoDetalleId == PedidoDetalleId);
            if (PedidoDetalleEnDB != null)
            {
                _unitOfWork.Repository<PedidoDetalle>().Eliminar(PedidoDetalleEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
        public int EliminarPedidoConDetalle(int PedidoID)
        {
            var PedidoDetalleEnDB = _unitOfWork.Repository<PedidoDetalle>().Consulta().FirstOrDefault(r => r.PedidoId == PedidoID);
            if (PedidoDetalleEnDB != null)
            {
                _unitOfWork.Repository<PedidoDetalle>().Eliminar(PedidoDetalleEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
