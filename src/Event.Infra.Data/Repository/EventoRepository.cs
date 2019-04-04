using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;
using Event.Domain.Interfaces.Repository;
using Event.Infra.Data.Context;

namespace Event.Infra.Data.Repository
{
    public class EventoRepository : RepositoryBase<Evento>, IEventoRepository
    {
    }
}
