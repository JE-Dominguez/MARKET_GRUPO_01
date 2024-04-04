using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_Categoria
    {
        private readonly UnitOfWork _unitOfWork;
        public D_Categoria()
        {
            _unitOfWork = new UnitOfWork();
        }

        public List<Categoria> ObtenerTodalascategorias()
        {
            return _unitOfWork.Repository<Categoria>().Consulta().ToList();
        }

        public int AgregarCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _unitOfWork.Repository<Categoria>().Agregar(categoria);
            return 1;
        }

        public int EditarCategoria(Categoria categoria)
        {
            var categoriaEnDB = _unitOfWork.Repository<Categoria>().Consulta().FirstOrDefault(r => r.CategoriaId == categoria.CategoriaId);

            if (categoriaEnDB != null)
            {
                categoriaEnDB.Codigo = categoria.Codigo;
                categoriaEnDB.Descripcion = categoria.Descripcion;
                categoriaEnDB.Estado = categoria.Estado;
                _unitOfWork.Repository<Categoria>().Editar(categoriaEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarCategoria(int categoriaId)
        {
            var categoriaEnDB = _unitOfWork.Repository<Categoria>().Consulta().FirstOrDefault(r => r.CategoriaId == categoriaId);
            if (categoriaEnDB != null)
            {
                _unitOfWork.Repository<Categoria>().Eliminar(categoriaEnDB);
                return 1;
            }
            return 0;
        }
    }
}
