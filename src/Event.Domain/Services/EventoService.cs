using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Core;
using Event.Domain.Entities;
using Event.Domain.Interfaces;
using Event.Domain.Interfaces.Repository;
using Event.Domain.Interfaces.Services;

namespace Event.Domain.Services
{
    public class EventoService : ServiceBase<Evento>, IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly INotification _notification;

        public EventoService(IEventoRepository eventoRepository, 
            ICategoriaRepository categoriaRepository,
            INotification notification)
            : base(eventoRepository)
        {
            _eventoRepository = eventoRepository;
            _categoriaRepository = categoriaRepository;
            _notification = notification;
        }


        public Categoria GetCategoriaById(Guid id)
        {
            return _categoriaRepository.GetById(id);
        }

        public IEnumerable<Categoria> GetAllCategoria()
        {
            return _categoriaRepository.GetAll();
        }

        public void AdicionaCategoria(Categoria categoria)
        {
            _categoriaRepository.Add(categoria);
        }

        public void RegistrarInteresse(UsuarioEvento usuarioEvento)
        {
            var entity = _eventoRepository.GetById(usuarioEvento.IdEvento);
            
            if(entity.Vagas <= entity.UsuarioEventos.Count)
                _notification.AddNotification(new DomainNotifications("Erro", "Número de vagas está esgotado!"));
            else
                _eventoRepository.RegistrarInteresse(usuarioEvento);
        }

        public void RemoverInteresse(UsuarioEvento usuarioEvento)
        {
            _eventoRepository.RemoverInteresse(usuarioEvento);
        }
    }
}
