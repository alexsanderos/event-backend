using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EmpresaInstituicao { get; set; }
    }
}
