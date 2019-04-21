using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Application.Interfaces
{
    public interface IApplicationServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Remove(TEntity obj);
        void Update(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Dispose();

    }
}
