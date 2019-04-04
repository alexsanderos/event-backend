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

        public EventoService(IEventoRepository eventoRepository)
            : base(eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

    }
}
