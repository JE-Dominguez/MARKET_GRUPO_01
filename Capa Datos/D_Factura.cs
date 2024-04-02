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
        repository<D_Factura> _repository;

        public object FacturaEnDB { get; private set; }

        public D_Factura()
        {
            _repository = new Repository<Factura>();
        }

        public List<Factura> ObtenerTodalasFacturas()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarCategoria(Factura Factura)
        {
            Factura.FechaCreacion = DateTime.Now;
            _repository.Agregar(Factura);
            return 1;
        }

        public int EditarFactura(Factura Factura)
        {
            var FacturaEnDB = _repository.Consulta().FirstOrDefault(r => r.CategoriaId == Factura.FacturaId);

            if (FacturaEnDB != null)
            {
                FacturaEnDB.ClienteID = Factura.ClienteiD;
                FacturaEnDB. PedidoID = Factura.PedidoID;
                FacturaEnDB.Estado = Factura.Estado;
                FacturaEnDB.Total = Factura.Total;
                _repository.Editar( FacturaEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarFactura(int FacturaId)
        {
            var FacturaEnDB = _repository.Consulta().FirstOrDefault(r => r.FacturaId == FacturaId);
            if (FacturaEnDB != null)
            {
                _repository.Eliminar( FacturaEnDB);
                return 1;
            }
            return 0;
        }

    }
}
