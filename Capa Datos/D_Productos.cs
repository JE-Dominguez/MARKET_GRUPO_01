using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Productos
    {
        Repository<Productos> _repository;

        public D_Productos()
        {
            _repository = new Repository<Productos>();
        }

        public List<Productos> ObtenerTodosLosProductos()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarProducto(Productos producto)
        {
            producto.FechaCreacion = DateTime.Now;
            _repository.Agregar(producto);
            return 1;
        }

        public int EditarProducto(Productos producto)
        {
            var productoEnDB = _repository.Consulta().FirstOrDefault(p => p.ProductoId == producto.ProductoId);

            if (productoEnDB != null)
            {
                productoEnDB.CategoriaId = producto.CategoriaId;
                productoEnDB.UnidadMedidaId = producto.UnidadMedidaId;
                productoEnDB.Estado = producto.Estado;
                productoEnDB.PrecioCompra = producto.PrecioCompra;
                _repository.Editar(productoEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarProducto(int productoId)
        {
            var productoEnDB = _repository.Consulta().FirstOrDefault(p => p.ProductoId == productoId);
            if (productoEnDB != null)
            {
                _repository.Eliminar(productoEnDB);
                return 1;
            }
            return 0;
        }
    }
}
