using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Application.Interfaces
{
    public interface IApplicationServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Dispose();

    }
}
