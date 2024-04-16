using Capa_Datos;
using Capa_Datos.Modelos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Capa_Negocio
{
    public class N_Productos
    {
        D_Productos dProducto;

        public N_Productos()
        {
            dProducto = new D_Productos();
        }

        public List<Productos> ObtenerProductos()
        {
            return dProducto.ObtenerTodosLosProductos();
        }

        public List<object> ObtenerProductosGrid()
        {
            var productoss = dProducto.ObtenerTodosLosProductos()
                                     .ToList()
                                     .Select(prd => new { prd.ProductoId, prd.Codigo, prd.Nombre, Categoria = prd.Categoria.Descripcion, UnidadMedida = prd.UnidadMedida.Descripcion, prd.FechaCreacion, prd.PrecioCompra, prd.Estado })
                                     .ToList<object>();
            return productoss;
        }

        public int GuardarProducto(Productos producto)
        {
            if (producto.ProductoId == 0)
            {
                return dProducto.AgregarProducto(producto);
            }
            else
            {
                return dProducto.EditarProducto(producto);
            }
        }

        public int EliminarProducto(int productoId)
        {
            return dProducto.EliminarProducto(productoId);
        }
    }
}
