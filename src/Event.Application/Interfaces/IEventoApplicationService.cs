using System;
using System.Collections.Generic;
using System.Text;
using Event.Application.ViewModels;
using Event.Domain.Entities;

namespace Event.Application.Interfaces
{
    public interface IEventoApplicationService : IApplicationServiceBase<Evento>
    {
        Categoria GetCategoriaById(int id);
        IEnumerable<Categoria> GetAllCategoria();
        void AdicionaCategoria(Categoria categoria);
    }
}
