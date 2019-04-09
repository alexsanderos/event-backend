using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Core.Models;
using FluentValidation;

namespace Event.Domain.Entities
{
    public class Evento : Entity<Evento>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoLonga { get; set; }
        public virtual ICollection<CategoriaEvento> CategoriaEventos { get; set; }
        public virtual ICollection<UsuarioEvento> UsuarioEventos { get; set; }
        public virtual ICollection<Agenda> Agendamentos { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public void Validar()
        {
            ValidarTitulo();
            ValidationResult = Validate(this);
        }

        public void ValidarTitulo()
        {
            RuleFor(c => c.Titulo)
                .NotEmpty()
                .WithMessage("O título é obrigatório.")
                .Length(3, 255)
                .WithMessage("O título deve ser maior que 3 e menor que 255 caracteres.");
        }
    }
}
