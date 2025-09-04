using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TSC.Expopunto.Application.Configuration;
using TSC.Expopunto.Application.DataBase.Accesos.Queries;
using TSC.Expopunto.Application.DataBase.FormaPago.Queries;
using TSC.Expopunto.Application.DataBase.Menu.Command;
using TSC.Expopunto.Application.DataBase.Menu.Queries;
using TSC.Expopunto.Application.DataBase.Parametro.Queries;
using TSC.Expopunto.Application.DataBase.Perfil.Commands;
using TSC.Expopunto.Application.DataBase.Perfil.Queries;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Commands;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Queries;
using TSC.Expopunto.Application.DataBase.Sede.Commands;
using TSC.Expopunto.Application.DataBase.Sede.Queries;
using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Commands;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries;
using TSC.Expopunto.Application.DataBase.TiposDocumento.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries;
using TSC.Expopunto.Application.DataBase.MedioPago.Queries;
using TSC.Expopunto.Application.Validators.Perfil;
using TSC.Expopunto.Application.Validators.PerfilMenu;
using TSC.Expopunto.Application.Validators.UsuarioPerfil;

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

            services.AddTransient<ISedeCommand, SedeCommand>();
            services.AddTransient<ISedeQuery, SedeQuery>();

            services.AddTransient<ITipoComprobanteQuery, TipoComprobanteQuery>();
            services.AddTransient<ITipoMonedaQuery, TipoMonedaQuery>();

            services.AddTransient<IMenuCommand, MenuCommand>();
            services.AddTransient<IMenuQuery, MenuQuery>();

            services.AddTransient<IPerfilCommand, PerfilCommand>();
            services.AddTransient<IPerfilQuery, PerfilQuery>();

            services.AddTransient<ITipoDocumentoCommand, TipoDocumentoCommand>();
            services.AddTransient<ITipoDocumentoQuery, TipoDocumentoQuery>();

            services.AddTransient<IAccesosQuery, AccesosQuery>();

            services.AddTransient<IUsuariosPerfilCommand, UsuariosPerfilCommand>();
            services.AddTransient<IUsuariosPerfilQuery, UsuariosPerfilQuery>();

            services.AddTransient<IPerfilMenuCommand, PerfilMenuCommand>();
            services.AddTransient<IPerfilMenuQuery, PerfilMenuQuery>();

            services.AddTransient<IParametroQuery, ParametroQuery>();

            services.AddTransient<IFormaPagoQuery,  FormaPagoQuery>();

            services.AddTransient<IMedioPagoQuery, MedioPagoQuery>();
            #region Validators
            services.AddScoped<IValidator<PerfilModel>, CrearPerfilValidator>();
            services.AddScoped<IValidator<PerfilMenuModel>, PerfilMenuValidator>();
            services.AddScoped<IValidator<UsuariosPerfilModel>, UsuariosPerfilValidator>();

            #endregion

            return services;
        }
    }
}
