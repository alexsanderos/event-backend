using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;
using Event.Domain.Interfaces.Repository;
using Event.Domain.Interfaces.Services;

namespace Event.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            :base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}
