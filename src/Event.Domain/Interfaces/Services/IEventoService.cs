using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;

namespace Event.Domain.Interfaces.Services
{
    public interface IEventoService : IServiceBase<Evento>
    {
        Categoria GetCategoriaById(int id);
        IEnumerable<Categoria> GetAllCategoria();
        void AdicionaCategoria(Categoria categoria);
    }
}
