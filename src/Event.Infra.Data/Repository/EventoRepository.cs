using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Event.Domain.Entities;
using Event.Domain.Interfaces.Repository;
using Event.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Event.Infra.Data.Repository
{
    public class EventoRepository : RepositoryBase<Evento>, IEventoRepository
    {
        public ICollection<Agenda> ObterAgendamentos(Guid idEvento)
        {
            return this._context.Set<Agenda>().Select(x => x).Where(x => x.EventoId == idEvento).ToList();
        }

        public override void Remove(Evento obj)
        {
            var entity = this._context.Set<Evento>()
                .Include(x => x.Agendamentos).FirstOrDefault();
            
            this._context.Set<Agenda>().RemoveRange(entity.Agendamentos);

            this._context.Set<Evento>().Remove(entity);
            this._context.SaveChanges();
        }

        public override void Update(Evento evento)
        {
            
            var entity = this._context.Set<Evento>()
                .Include(x => x.Agendamentos).FirstOrDefault();

            this._context.Entry(entity).CurrentValues.SetValues(evento);

            foreach (var agenda in entity.Agendamentos)
            {
                if (!(evento.Agendamentos.Any(x => x.Id == agenda.Id)))
                {
                    this._context.Set<Agenda>().Remove(agenda);
                }
            }

            foreach (var agendamento in evento.Agendamentos)
            {
                if (!(entity.Agendamentos.Any(x => x.Id == agendamento.Id)))
                {
                    this._context.Set<Agenda>().Add(agendamento);
                }
            }

            this._context.SaveChanges();
        }

        public override IEnumerable<Evento> GetAll()
        {
            return this._context.Set<Evento>().Select(x => x)
                .Include(y => y.Agendamentos)
                .Include(x => x.Categoria)
                .Include(x => x.UsuarioEventos)
                .ToList();
        }

        public void RegistrarInteresse(UsuarioEvento usuarioEvento)
        {
            var entity = _context.Set<UsuarioEvento>()
                            .FirstOrDefault(x => x.IdUsuario == usuarioEvento.IdUsuario
                                                 && x.IdEvento == usuarioEvento.IdEvento);
            if (entity == null)
            {
                _context.Set<UsuarioEvento>().Add(usuarioEvento);
            }
            else
            {
                entity.Ativo = true;
            }

            this._context.SaveChanges();
        }

        public void RemoverInteresse(UsuarioEvento usuarioEvento)
        {
            _context.Set<UsuarioEvento>().Remove(usuarioEvento);
            this._context.SaveChanges();
        }
    }
}
