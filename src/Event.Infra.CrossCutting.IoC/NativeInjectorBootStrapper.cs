using AutoMapper;
using Event.Application.AutoMapper;
using Event.Application.Interfaces;
using Event.Application.Services;
using Event.CrossCutting.Identity.Models;
using Event.CrossCutting.Identity.Services;
using Event.Domain.Interfaces;
using Event.Domain.Interfaces.Repository;
using Event.Domain.Interfaces.Services;
using Event.Domain.Services;
using Event.Infra.Data.Context;
using Event.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());

            services.AddScoped<IMapper>(
                sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IEventoApplicationService, EventoApplicationService>();

            services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();

            // Domain - Commands
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();


            // Infra - Data
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<EventContext>();

            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();

        }
    }
}
