using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Domain.Core;
using Event.Domain.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Event.Service.Api.Controllers
{
    [Produces("application/json")]
    public abstract class BaseController : Controller
    {
        protected Guid UsuarioId { get; set; }
        protected List<DomainNotifications> notifications { get; set; }

        protected BaseController(IUser user)
        {
            if (user.IsAuthenticated())
            {
                UsuarioId = user.GetUserId();
            }
            notifications = new List<DomainNotifications>();
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = notifications.Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return notifications.Count == 0;
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErrosValidation(ValidationResult result)
        {
            foreach (var erro in result.Errors)
            {
                this.NotificarErro(erro.ErrorCode, erro.ErrorMessage);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            this.notifications.Add(new DomainNotifications(codigo, mensagem));
        }

        protected void AdicionarErrosIdentity(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.notifications.Add(new DomainNotifications(result.ToString(), error.Description));
            }
        }

    }
}
