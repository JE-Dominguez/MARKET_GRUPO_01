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
        Repository<FacturaDetalle> _repository;

        public D_FacturaDetalle()
        {
            _repository = new Repository<Factura>();
        }

        public List< FacturaDetalle> ObtenerTodosLasFacturaDetalle()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarProducto(FacturaDetalle facturaDetalle)
        {
             Factura.FechaCreacion = DateTime.Now;
            _repository.Agregar(Factura);
            return 1;
        }

        public int EditarFacturaDetalle(FacturaDetalle facturaDetalle)
        {
            var FacturaDetalleEnDB = _repository.Consulta().FirstOrDefault(p => p. FacturaId == FacturaDetalle.FacturaDetalleId);

            if (FacturaDetalleEnDB != null)
            {
                FacturaDetalleEnDB.FacturaId = FacturaDetalle.FacturaId;
                FacturaDetalleEnDB.ProductoId = FacturaDetalle.UnidadMedidaId;
                FacturaDetalleEnDB.precio = FacturaDetalle.precio;
                FacturaDetalleEnDB.Total = FacturaDetalle.Total;
                FacturaDetalleEnDB.Subtotal = FacturaDetalle.Subtotal;
                FacturaDetalleEnDB.Descuento = FacturaDetalle.Descuento;
                _repository.Editar(FacturaDetalleEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarProducto(int productoId)
        {
            var FacturaDetalleEnDB = _repository.Consulta().FirstOrDefault(p => p.FacturaDetalleId == FacturaId);
            if (FacturaDetalleEnDB != null)
            {
                _repository.Eliminar(FacturaDetalleEnDB);
                return 1;
            }
            return 0;
        }

    }
}
