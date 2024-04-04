using Capa_Datos;
using Capa_Datos.Modelos;
using System.Collections.Generic;
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
            var productoss = dProducto.ObtenerTodosLosProductos().Select(p => new { ID = p.ProductoId }).ToList<object>();
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
