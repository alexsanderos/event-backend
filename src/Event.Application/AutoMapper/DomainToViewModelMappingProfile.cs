using AutoMapper;
using Event.Application.ViewModels;
using Event.Domain.Entities;

namespace Event.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
        }
    }
}