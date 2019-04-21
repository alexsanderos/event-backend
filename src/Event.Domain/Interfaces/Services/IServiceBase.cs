using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity>  where TEntity : class
    {
        void Add(TEntity obj);
        void Remove(TEntity obj);
        void Update(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Dispose();

    }
}
