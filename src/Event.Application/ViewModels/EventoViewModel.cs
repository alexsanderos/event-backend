using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;

namespace Event.Application.ViewModels
{
    public class EventoViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public int Vagas { get; set; }
        public ICollection<AgendaViewModel> Agendamentos { get; set; }
        public ICollection<UsuarioEventoViewModel> UsuarioEventos { get; set; }
        public Guid IdCategoria { get; set; }
        public CategoriaViewModel Categoria { get; set; }
    }
}
