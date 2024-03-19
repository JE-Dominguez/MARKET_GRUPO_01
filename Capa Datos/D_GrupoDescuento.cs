using Capa_Datos.Core;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Datos
{
    public class D_GrupoDescuento
    {
        Repository<GrupoDescuento> _repository;

        public D_GrupoDescuento()
        {
            _repository = new Repository<GrupoDescuento>();
        }

        public List<GrupoDescuento> ObtenerTodosLosGruposDescuento()
        {
            return _repository.Consulta().ToList();
        }

        public int AgregarGrupoDescuento(GrupoDescuento grupoDescuento)
        {
            grupoDescuento.FechaCreacion = DateTime.Now;
            _repository.Agregar(grupoDescuento);
            return 1;
        }

        public int EditarGrupoDescuento(GrupoDescuento grupoDescuento)
        {
            var grupoDescuentoEnDB = _repository.Consulta().FirstOrDefault(g => g.GrupoDescuentoId == grupoDescuento.GrupoDescuentoId);

            if (grupoDescuentoEnDB != null)
            {
                grupoDescuentoEnDB.Codigo = grupoDescuento.Codigo;
                grupoDescuentoEnDB.Descripcion = grupoDescuento.Descripcion;
                grupoDescuentoEnDB.Estado = grupoDescuento.Estado;
                grupoDescuentoEnDB.Porcentaje = grupoDescuento.Porcentaje;
                _repository.Editar(grupoDescuentoEnDB);
                return 1;
            }
            return 0;
        }

        public int EliminarGrupoDescuento(int grupoDescuentoId)
        {
            var grupoDescuentoEnDB = _repository.Consulta().FirstOrDefault(g => g.GrupoDescuentoId == grupoDescuentoId);
            if (grupoDescuentoEnDB != null)
            {
                _repository.Eliminar(grupoDescuentoEnDB);
                return 1;
            }
            return 0;
        }
    }
}
