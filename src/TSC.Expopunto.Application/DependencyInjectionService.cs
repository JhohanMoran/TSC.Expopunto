using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TSC.Expopunto.Application.Configuration;

using TSC.Expopunto.Application.DataBase.Menu.Command;
using TSC.Expopunto.Application.DataBase.Menu.Queries;
using TSC.Expopunto.Application.DataBase.Perfil.Commands;
using TSC.Expopunto.Application.DataBase.Perfil.Queries;
using TSC.Expopunto.Application.DataBase.Accesos.Queries;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Commands;
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

            services.AddTransient<IMenuCommand, MenuCommand>();
            services.AddTransient<IMenuQuery, MenuQuery>();

            services.AddTransient<IPerfilCommand, PerfilCommand>();
            services.AddTransient<IPerfilQuery, PerfilQuery>();

            services.AddTransient<ITipoDocumentoCommand, TipoDocumentoCommand>();

            services.AddTransient<IAccesosQuery, AccesosQuery>();

            return services;
        }
    }
}
