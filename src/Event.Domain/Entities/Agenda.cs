using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Core.Models;

namespace Event.Domain.Entities
{
    public class Agenda : Entity<Agenda>
    {

        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Guid EventoId { get; set; }
        public virtual Evento Evento { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public void Validar()
        {
            ValidationResult = Validate(this);
        }
    }
}
