using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;
using Event.Domain.Interfaces.Repository;
using Event.Domain.Interfaces.Services;

namespace Event.Domain.Services
{
    public class EventoService : ServiceBase<Evento>, IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public EventoService(IEventoRepository eventoRepository, ICategoriaRepository categoriaRepository)
            : base(eventoRepository)
        {
            _eventoRepository = eventoRepository;
            _categoriaRepository = categoriaRepository;
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
            _eventoRepository.RegistrarInteresse(usuarioEvento);
        }

        public void RemoverInteresse(UsuarioEvento usuarioEvento)
        {
            _eventoRepository.RemoverInteresse(usuarioEvento);
        }
    }
}
