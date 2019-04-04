using System;
using System.Collections.Generic;
using System.Text;
using Event.Application.Interfaces;
using Event.Domain.Entities;
using Event.Domain.Interfaces.Services;

namespace Event.Application.Services
{
    public class UsuarioApplicationService : ApplicationServiceBase<Usuario>, IUsuarioApplicationService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioApplicationService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }
    }
}
