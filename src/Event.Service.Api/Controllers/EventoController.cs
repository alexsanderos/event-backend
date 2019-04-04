using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            _EventoApplicationService.Add(evento);

            return Response(evento);
        }

    }
}
