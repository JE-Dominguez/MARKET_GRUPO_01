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
        repository< PedidoDetalle> _repository;

        public object FacturaEnDB { get; private set; }

        public PedidoDetalle()
        {
            _repository = new Repository<PedidoDetalle>();
        }

        public List<PedidoDetalle> ObtenerTodalospedidoDetalle()
        {
            return _repository.Consulta().ToList();
         

        public int AgregarCategoria(PedidoDetalle PedidoDetalle)
        {
            PedidoDetalle.FechaCreacion = DateTime.Now;
            _repository.Agregar(PedidoDetalle);
            return 1;
        }

        public int EditarPedidoDetalle(PedidoDetalle PedidoDetalle)
        {
            var PedidoDetalleEnDB = _repository.Consulta().FirstOrDefault(r => r. PedidoDetalleId == PedidoDetalle .PedidoDetalleId);

            if (PedidoDetalleEnDB != null)
            {
                PedidoDetalleEnDB.PedidoID = PedidoDetalle.PedidoID;
                PedidoDetalleEnDB.ProductoID = PedidoDetalle.ProductoID;
                PedidoDetalleEnDB.precio = PedidoDetalle.precio;
                    PedidoDetalleEnDB.Total = PedidoDetalle.Total;
                    PedidoDetalleEnDB.SubTotal = PedidoDetalle.SubTotal;
                PedidoDetalleEnDB.Descuento = PedidoDetalle.Descuento;
         _repository.Editar(PedidoDetalleEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarPedidoDetalle(int PedidoDetalleId)
        {
            var PedidoDetalleEnDB = _repository.Consulta().FirstOrDefault(r => r.FacturaId == PedidoDetalleId);
            if (PedidoDetalleEnDB != null)
            {
                _repository.Eliminar(PedidoDetalleEnDB);
                return 1;
            }
            return 0;
        }

    }
}
