using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TSC.Expopunto.Application.Configuration;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Commands;
using TSC.Expopunto.Application.DataBase.EntidadFinanciera.Queries;
using TSC.Expopunto.Application.DataBase.Persona.Commands;
using TSC.Expopunto.Application.DataBase.Persona.Queries;
using TSC.Expopunto.Application.DataBase.TipoPersona.Queries;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;

namespace TSC.Expopunto.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            services.AddTransient<IUsuarioCommand, UsuarioCommand>();
            services.AddTransient<IUsuarioQuery, UsuarioQuery>();


            services.AddTransient<IEntidadFinancieraCommand, EntidadFinancieraCommand>();
            services.AddTransient<IEntidadFinancieraQuery, EntidadFinancieraQuery>();

            services.AddTransient<IPersonaCommand, PersonaCommand>();
            services.AddTransient<IPersonaQuery, PersonaQuery>();

            services.AddTransient<ITipoPersonaQuery, TipoPersonaQuery>();



            return services;
        }
    }
}
