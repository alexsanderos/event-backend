using System;
using System.Collections.Generic;
using System.Text;
using Event.Application.Interfaces;
using Event.Domain.Interfaces.Services;

namespace Event.Application.Services
{
    public class ApplicationServiceBase<TEntity> : IDisposable, IApplicationServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public ApplicationServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }
        
        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public TEntity GetById(Guid id)
        {
            return _serviceBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

    }
}
