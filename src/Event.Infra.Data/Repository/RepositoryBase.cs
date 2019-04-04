using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Event.Domain.Interfaces.Repository;
using Event.Infra.Data.Context;

namespace Event.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected EventContext _context = new EventContext();

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
