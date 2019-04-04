using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Interfaces.Repository;
using Event.Domain.Interfaces.Services;

namespace Event.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

    }
}
