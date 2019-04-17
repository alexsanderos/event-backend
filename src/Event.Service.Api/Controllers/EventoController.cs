using System;
using System.Collections.Generic;
using AutoMapper;
using Event.Application.Interfaces;
using Event.Application.ViewModels;
using Event.Domain.Entities;
using Event.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event.Service.Api.Controllers
{
    public class EventoController : BaseController
    {
        protected readonly IUser _user;
        protected readonly IEventoApplicationService _EventoApplicationService;
        protected readonly IMapper _mapper;

        public EventoController( IUser user, IEventoApplicationService service, IMapper mapper)
        :base(user)
        {
            _user = user;
            _EventoApplicationService = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("eventos")]
        [AllowAnonymous]
        public IEnumerable<EventoViewModel> Get()
        {
            return _mapper.Map<List<EventoViewModel>>(_EventoApplicationService.GetAll());
        }

        [HttpGet]
        [Route("meus-eventos")]
        [Authorize]
        public IEnumerable<EventoViewModel> MeusEventos()
        {
            return _mapper.Map<List<EventoViewModel>>(_EventoApplicationService.GetAll());
        }

        [HttpPost]
        [Route("eventos")]
        [AllowAnonymous]
        public IActionResult Post([FromBody]EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var evento = _mapper.Map<Evento>(eventoViewModel);

            if (evento.EhValido())
            {
                _EventoApplicationService.Add(evento);
            }
            else
            {
                NotificarErrosValidation(evento.ValidationResult);
                return Response();
            }
            
            return Response(evento);
        }

        [HttpPost]
        [Route("categorias")]
        [AllowAnonymous]
        public IActionResult AdicionarCategoria([FromBody]CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var categoria = _mapper.Map<Categoria>(categoriaViewModel);

            if (categoria.EhValido())
            {
                _EventoApplicationService.AdicionaCategoria(categoria);
            }
            else
            {
                NotificarErrosValidation(categoria.ValidationResult);
                return Response();
            }

            return Response(categoria);
        }

        [HttpGet]
        [Route("categorias")]
        [AllowAnonymous]
        public IEnumerable<CategoriaViewModel> BuscarCategorias()
        {
            return _mapper.Map<List<CategoriaViewModel>>(_EventoApplicationService.GetAllCategoria());
        }
    }
}
