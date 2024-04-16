using Capa_Datos;
using Capa_Datos.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocio
{
    public class N_Categoria
    {
        D_Categoria dCategoria;

        public N_Categoria()
        {
            dCategoria = new D_Categoria();
        }

        public List<Categoria> ObtenerCategoria()
        {
            return dCategoria.ObtenerTodalascategorias();
        }

        public List<object> ObtenerCategoriaGrid()
        {
            var categoria = dCategoria.ObtenerTodalascategorias().ToList()
                                 .Select(cat => new { cat.CategoriaId, cat.Codigo, cat.Descripcion, cat.FechaCreacion, cat.Estado })
                                 .ToList<object>();
            return categoria;
        }

        public int GuardarCategoria(Categoria categoria)
        {
            if (categoria.CategoriaId == 0)
            {
                return dCategoria.AgregarCategoria(categoria);
            }
            else
            {
                return dCategoria.EditarCategoria(categoria);
            }
        }

        public int EliminarCategoria(int CategoriaId)
        {
            return dCategoria.EliminarCategoria(CategoriaId);
        }
    }
}
