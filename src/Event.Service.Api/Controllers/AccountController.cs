using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Event.Application.Interfaces;
using Event.CrossCutting.Identity.Authorization;
using Event.CrossCutting.Identity.Models;
using Event.CrossCutting.Identity.Models.AccountViewModels;
using Event.Domain.Entities;
using Event.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Event.Service.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        private readonly JwtTokenOptions _jwtTokenOptions;

        public AccountController(
                    UserManager<ApplicationUser> userManager,
                    SignInManager<ApplicationUser> signInManager,
                    ILoggerFactory loggerFactory,
                    IOptions<JwtTokenOptions> jwtTokenOptions,
                    IUser user,
                    IUsuarioApplicationService usuarioApplicationService) : base(user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenOptions = jwtTokenOptions.Value;
            _usuarioApplicationService = usuarioApplicationService;

            ThrowIfInvalidOptions(_jwtTokenOptions);
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        private static long ToUnixEpochDate(DateTime date)
      => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        [HttpPost]
        [AllowAnonymous]
        [Route("nova-conta")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model, int version)
        {
            if (version == 2)
            {
                return Response(new { Message = "API V2 n�o dispon�vel" });
            }

            if (!ModelState.IsValid) return Response(model);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //:TODO  --> Registrar um usu�rio

                var usuario = new Usuario();
                usuario.Id = Guid.Parse(user.Id);
                usuario.Nome = user.UserName;
                usuario.CPF = model.CPF;
                usuario.DataNascimento = model.DataNascimento;
                usuario.Email = user.Email;
                usuario.EmpresaInstituicao = model.EmpresaInstituicao;

                _usuarioApplicationService.Add(usuario);


                //_bus.SendCommand(registroCommand);

                //if (!OperacaoValida())
                //{
                //    await _userManager.DeleteAsync(user);
                //    return Response(model);
                //}

                _logger.LogInformation(1, "Usuario criado com sucesso!");
                var response = await GerarTokenUsuario(new LoginViewModel { Email = model.Email, Password = model.Password });
                return Response(response);
            }
            AdicionarErrosIdentity(result);
            return Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("conta")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation(1, "Usuario logado com sucesso");
                var response = await GerarTokenUsuario(model);
                return Response(response);
            }

            NotificarErro(result.ToString(), "Falha ao realizar o login");
            return Response(model);
        }

        private async Task<object> GerarTokenUsuario(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            var userClaims = await _userManager.GetClaimsAsync(user);

            //Carrega configura��es credentials
            //_jwtTokenOptions.SigningConfigurations();

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, await _jwtTokenOptions.JtiGenerator()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtTokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64));
            

            var jwt = new JwtSecurityToken(
                  issuer: _jwtTokenOptions.Issuer,
                  audience: _jwtTokenOptions.Audience,
                  claims: userClaims,
                  notBefore: _jwtTokenOptions.NotBefore,
                  expires: _jwtTokenOptions.Expiration,
                  signingCredentials: _jwtTokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)_jwtTokenOptions.ValidFor.TotalSeconds,
                user = user
            };

            return response;
        }


        private static void ThrowIfInvalidOptions(JwtTokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtTokenOptions.ValidFor));
            }

            //if (options.SigningCredentials == null)
            //{
            //    throw new ArgumentNullException(nameof(JwtTokenOptions.SigningCredentials));
            //}

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtTokenOptions.JtiGenerator));
            }
        }
    }
}