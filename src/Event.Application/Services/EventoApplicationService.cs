using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Event.Application.Interfaces;
using Event.Application.ViewModels;
using Event.Domain.Entities;
using Event.Domain.Interfaces.Services;

namespace Event.Application.Services
{
    public class EventoApplicationService : ApplicationServiceBase<Evento>, IEventoApplicationService
    {

        private readonly IEventoService _eventoService;
        
        public EventoApplicationService(IEventoService eventoService)
            : base(eventoService)
        {
            _eventoService = eventoService;
        }

        public Categoria GetCategoriaById(int id)
        {
            return _eventoService.GetCategoriaById(id);
        }

        public IEnumerable<Categoria> GetAllCategoria()
        {
            return _eventoService.GetAllCategoria();
        }

        public void AdicionaCategoria(Categoria categoria)
        {
            _eventoService.AdicionaCategoria(categoria);
        }
    }
}
