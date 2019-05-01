using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Entities;

namespace Event.Domain.Interfaces.Repository
{
    public interface IEventoRepository : IRepositoryBase<Evento>
    {
        ICollection<Agenda> ObterAgendamentos(Guid idEvento);
        void RegistrarInteresse(UsuarioEvento usuarioEvento);
        void RemoverInteresse(UsuarioEvento usuarioEvento);
        IEnumerable<Evento> ObterEventoDoUsuario(Guid idUsuario);
        IEnumerable<Usuario> ObterInscritos(Guid idEvento);
    }
}
