using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Application.ViewModels
{
    public class UsuarioEventoViewModel
    {
        public Guid IdUsuario { get; set; }
        public Guid IdEvento { get; set; }
        public bool Ativo { get; set; }
    }
}
