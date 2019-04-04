using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Domain.Entities
{
    public class UsuarioEvento
    {
        public Guid IdUsuario { get; set; }
        public Guid IdEvento { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
