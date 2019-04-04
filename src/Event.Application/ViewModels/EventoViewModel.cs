using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Application.ViewModels
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Descricao { get; set; }
    }
}
