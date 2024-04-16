using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Productos
    {
        private readonly UnitOfWork _unitOfWork;

        public D_Productos()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Productos> ObtenerTodosLosProductos()
        {
            return _unitOfWork.Repository<Productos>().Consulta().ToList();
        }

        public int AgregarProducto(Productos producto)
        {
            producto.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<Productos>().Agregar(producto);
            return _unitOfWork.Guardar();
        }

        public int EditarProducto(Productos producto)
        {
            var productoEnDB = _unitOfWork.Repository<Productos>().Consulta().FirstOrDefault(p => p.ProductoId == producto.ProductoId);

            if (productoEnDB != null)
            {
                productoEnDB.Nombre = producto.Nombre;
                productoEnDB.CategoriaId = producto.CategoriaId;
                productoEnDB.UnidadMedidaId = producto.UnidadMedidaId;
                productoEnDB.Estado = producto.Estado;
                productoEnDB.PrecioCompra = producto.PrecioCompra;
                productoEnDB.ImpuestoId = producto.ImpuestoId;
                productoEnDB.Codigo = producto.Codigo;
                _unitOfWork.Repository<Productos>().Editar(productoEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }

        public int EliminarProducto(int productoId)
        {
            var productoEnDB = _unitOfWork.Repository<Productos>().Consulta().FirstOrDefault(p => p.ProductoId == productoId);
            if (productoEnDB != null)
            {
                _unitOfWork.Repository<Productos>().Eliminar(productoEnDB);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
