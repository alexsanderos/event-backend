using AutoMapper;
using Event.Application.ViewModels;
using Event.Domain.Entities;

namespace Event.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EventoViewModel, Evento>();
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<AgendaViewModel, Agenda>();
            CreateMap<UsuarioEventoViewModel, UsuarioEvento>();
        }
    }
}