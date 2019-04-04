using System;
using System.Collections.Generic;
using System.Text;
using Event.Domain.Core.Models;
using FluentValidation;

namespace Event.Domain.Entities
{
    public class Usuario : Entity<Usuario>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EmpresaInstituicao { get; set; }
        public virtual ICollection<UsuarioEvento> UsuarioEventos { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        public void Validar()
        {
            ValidarNome();
            ValidationResult = Validate(this);
        }

        public void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .Length(3, 255)
                .WithMessage("O nome deve ser maior que 3 e menor que 255 caracteres.");
        }
        
    }
}
