using Capa_Datos.BaseDatos;
using Capa_Datos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Capa_Datos.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public MarketContext dbcontext;

        public Repository()
        {
            this.dbcontext = new MarketContext();
        }
        public void Agregar(T entidad)
        {
            dbcontext.Set<T>().Add(entidad);
            //dbcontext.SaveChanges();
        }

        public void AgregarRango(IEnumerable<T> entidades)
        {
            dbcontext.Set<T>().AddRange(entidades);
            //dbcontext.SaveChanges();
        }

        public IQueryable<T> Consulta()
        {
            return dbcontext.Set<T>().AsQueryable();
        }

        public void Editar(T entidad)
        {
            dbcontext.Set<T>();
        }

        public void Eliminar(T entidad)
        {
            dbcontext.Set<T>().Remove(entidad);
        }
    }
}
