using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TSC.Expopunto.Application.Configuration;
using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands;
using System.Reflection;
using FluentValidation;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Commands;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Queries;
using TSC.Expopunto.Application.DataBase.TiposDocumento.Commands;
using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries;

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
            services.AddTransient<ITipoDocumentoQuery, TipoDocumentoQuery>();

            services.AddTransient<ITipoComprobanteQuery, TipoComprobanteQuery>();
            services.AddTransient<ITipoMonedaQuery, TipoMonedaQuery>();

            return services;
        }
    }
}
