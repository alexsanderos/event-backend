using System;
using System.Collections.Generic;
using AutoMapper;
using Event.Application.Interfaces;
using Event.Application.ViewModels;
using Event.Domain.Entities;
using Event.Domain.Interfaces;
using Event.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Event.Service.Api.Controllers
{
    public class EventoController : BaseController
    {
        protected readonly IUser _user;
        protected readonly IEventoApplicationService _EventoApplicationService;
        protected readonly IEventoRepository _eventoRepository;
        protected readonly IMapper _mapper;

        public EventoController( IUser user, 
            IEventoApplicationService service,
            IEventoRepository eventoRepository,
            IMapper mapper)
        :base(user)
        {
            _user = user;
            _EventoApplicationService = service;
            _mapper = mapper;
            _eventoRepository = eventoRepository;

        }

        [HttpGet]
        [Route("eventos")]
        [AllowAnonymous]
        public IEnumerable<EventoViewModel> Get()
        {
            return _mapper.Map<List<EventoViewModel>>(_EventoApplicationService.GetAll());
        }

        [HttpGet]
        [Route("eventos/{id}")]
        [AllowAnonymous]
        public EventoViewModel Get(Guid id)
        {
            return _mapper.Map<EventoViewModel>(_EventoApplicationService.GetById(id));
        }

        [HttpDelete]
        [Route("eventos/{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            var eventoViewModel = new EventoViewModel { Id = id };
            _EventoApplicationService.Remove(_mapper.Map<Evento>(eventoViewModel));

            return Response(eventoViewModel);
        }

        [HttpGet]
        [Route("eventos/{id}/agendamentos")]
        [AllowAnonymous]
        public ICollection<AgendaViewModel> GetAgendamentos(Guid id)
        {
            return _mapper.Map<ICollection<AgendaViewModel>>(_eventoRepository.ObterAgendamentos(id));
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
            
            return Response(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPut]
        [Route("eventos")]
        [AllowAnonymous]
        public IActionResult Put([FromBody]EventoViewModel eventoViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var evento = _mapper.Map<Evento>(eventoViewModel);

            if (evento.EhValido())
            {
                _EventoApplicationService.Update(evento);
            }
            else
            {
                NotificarErrosValidation(evento.ValidationResult);
                return Response();
            }

            return Response(_mapper.Map<EventoViewModel>(evento));
        }

        [HttpPost]
        [Route("eventos/{id}/queroir")]
        [Authorize]
        public IActionResult QueroIr(Guid id)
        {
            var usuarioEventoVm = new UsuarioEventoViewModel() {Ativo = true, IdUsuario = UsuarioId, IdEvento = id};
            _EventoApplicationService.RegistrarInteresse(_mapper.Map<UsuarioEvento>(usuarioEventoVm));

            return Response(usuarioEventoVm);
        }

        [HttpPost]
        [Route("eventos/{id}/desistir")]
        [Authorize]
        public IActionResult Desistir(Guid id)
        {
            var usuarioEventoVm = new UsuarioEventoViewModel() { Ativo = true, IdUsuario = UsuarioId, IdEvento = id };
            _EventoApplicationService.RemoverInteresse(_mapper.Map<UsuarioEvento>(usuarioEventoVm));

            return Response(usuarioEventoVm);
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
