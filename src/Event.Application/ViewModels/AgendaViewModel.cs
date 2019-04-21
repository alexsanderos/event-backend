using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Application.ViewModels
{
    public class AgendaViewModel
    {
        
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid EventoId { get; set; }

    }
}
