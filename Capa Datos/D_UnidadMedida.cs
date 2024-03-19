using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_UnidadMedida
    {
        Repository<UnidadMedida> _repository;

        public D_UnidadMedida()
        {
            _repository = new Repository<UnidadMedida>();
        }

        public List<UnidadMedida> ObtenerTodasLasUnidadesMedida()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarUnidadMedida(UnidadMedida unidadMedida)
        {
            unidadMedida.FechaCreacion = DateTime.Now;
            _repository.Agregar(unidadMedida);
            return 1;
        }

        public int EditarUnidadMedida(UnidadMedida unidadMedida)
        {
            var unidadMedidaEnDB = _repository.Consulta().FirstOrDefault(u => u.UnidadMedidaId == unidadMedida.UnidadMedidaId);

            if (unidadMedidaEnDB != null)
            {
                unidadMedidaEnDB.Codigo = unidadMedida.Codigo;
                unidadMedidaEnDB.Descripcion = unidadMedida.Descripcion;
                unidadMedidaEnDB.Estado = unidadMedida.Estado;
                _repository.Editar(unidadMedidaEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarUnidadMedida(int unidadMedidaId)
        {
            var unidadMedidaEnDB = _repository.Consulta().FirstOrDefault(u => u.UnidadMedidaId == unidadMedidaId);
            if (unidadMedidaEnDB != null)
            {
                _repository.Eliminar(unidadMedidaEnDB);
                return 1;
            }
            return 0;
        }
    }
}
