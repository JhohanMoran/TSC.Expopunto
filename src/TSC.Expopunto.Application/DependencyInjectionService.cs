using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TSC.Expopunto.Application.Behaviors;
using TSC.Expopunto.Application.Configuration;
using TSC.Expopunto.Application.DataBase.Accesos.Queries;
using TSC.Expopunto.Application.DataBase.Categoria.Command;
using TSC.Expopunto.Application.DataBase.Categoria.Queries;
using TSC.Expopunto.Application.DataBase.Descuento.Commands;
using TSC.Expopunto.Application.DataBase.Descuento.Queries;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Commands;
using TSC.Expopunto.Application.DataBase.DescuentoProductoVariante.Queries;
using TSC.Expopunto.Application.DataBase.FormaPago.Queries;
using TSC.Expopunto.Application.DataBase.Kardex.Queries;
using TSC.Expopunto.Application.DataBase.LineaCredito.Commands;
using TSC.Expopunto.Application.DataBase.LineaCredito.Queries;
using TSC.Expopunto.Application.DataBase.MedioPago.Queries;
using TSC.Expopunto.Application.DataBase.Menu.Command;
using TSC.Expopunto.Application.DataBase.Menu.Queries;
using TSC.Expopunto.Application.DataBase.Parametro.Commands;
using TSC.Expopunto.Application.DataBase.Parametro.Queries;
using TSC.Expopunto.Application.DataBase.Perfil.Commands;
using TSC.Expopunto.Application.DataBase.Perfil.Queries;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Commands;
using TSC.Expopunto.Application.DataBase.PerfilMenu.Queries;
using TSC.Expopunto.Application.DataBase.Persona.Commands;
using TSC.Expopunto.Application.DataBase.Persona.Queries;
using TSC.Expopunto.Application.DataBase.Prendas.Queries;
using TSC.Expopunto.Application.DataBase.Producto.Command;
using TSC.Expopunto.Application.DataBase.Producto.Queries;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Commands;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Queries;
using TSC.Expopunto.Application.DataBase.Reporte.Queries;
using TSC.Expopunto.Application.DataBase.Sede.Commands;
using TSC.Expopunto.Application.DataBase.Sede.Queries;
using TSC.Expopunto.Application.DataBase.SedeSerie.Commands;
using TSC.Expopunto.Application.DataBase.SedeSerie.Queries;
using TSC.Expopunto.Application.DataBase.TipoComprobante.Queries;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Commands;
using TSC.Expopunto.Application.DataBase.TipoDocumento.Queries;
using TSC.Expopunto.Application.DataBase.TipoMoneda.Queries;
using TSC.Expopunto.Application.DataBase.TipoPersona.Queries;
using TSC.Expopunto.Application.DataBase.TiposDocumento.Commands;
using TSC.Expopunto.Application.DataBase.UnidadMedida.Queries;
using TSC.Expopunto.Application.DataBase.Usuario.Commands;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Commands;
using TSC.Expopunto.Application.DataBase.UsuariosPerfil.Queries;
using TSC.Expopunto.Application.DataBase.UsuariosSede.Commands;
using TSC.Expopunto.Application.DataBase.UsuariosSede.Queries;
using TSC.Expopunto.Application.Interfaces.Services;
using TSC.Expopunto.Application.Security;

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

            // Registrar MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Registrar FluentValidation (validators dentro de Application)
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Registrar pipeline para validación
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IPasswordService, PasswordService>();

            // Inyección de dependencias de comandos y queries
            services.AddTransient<IUsuarioCommand, UsuarioCommand>();
            services.AddTransient<IUsuarioQuery, UsuarioQuery>();

            services.AddTransient<ITipoDocumentoQuery, TipoDocumentoQuery>();

            services.AddTransient<ITipoComprobanteQuery, TipoComprobanteQuery>();

            services.AddTransient<ITipoMonedaQuery, TipoMonedaQuery>();

            services.AddTransient<ISedeCommand, SedeCommand>();
            services.AddTransient<ISedeQuery, SedeQuery>();

            services.AddTransient<ISedeSerieCommand, SedeSerieCommand>();
            services.AddTransient<ISedeSerieQuery, SedeSerieQuery>();

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

            services.AddTransient<IParametroCommand, ParametroCommand>();
            services.AddTransient<IParametroQuery, ParametroQuery>();


            services.AddTransient<ICategoriaQuery, CategoriaQuery>();
            services.AddTransient<ICategoriaCommand, CategoriaCommand>();

            services.AddTransient<IProductoQuery, ProductoQuery>();
            services.AddTransient<IProductoCommand, ProductoCommand>();

            services.AddTransient<IUsuariosSedeCommand, UsuariosSedeCommand>();
            services.AddTransient<IUsuariosSedeQuery, UsuariosSedeQuery>();

            services.AddTransient<IFormaPagoQuery, FormaPagoQuery>();

            services.AddTransient<IMedioPagoQuery, MedioPagoQuery>();

            services.AddTransient<IUnidadMedidaQuery, UnidadMedidaQuery>();

            services.AddTransient<IPersonaCommand, PersonaCommand>();
            services.AddTransient<IPersonaQuery, PersonaQuery>();


            services.AddTransient<ITipoPersonaQuery, TipoPersonaQuery>();

            services.AddTransient<IReporteQuery, ReporteQuery>();
            services.AddTransient<IPrendasQuery, PrendasQuery>();


            services.AddTransient<ILineaCreditoCommand, LineaCreditoCommand>();
            services.AddTransient<ILineaCreditoQuery, LineaCreditoQuery>();

            services.AddTransient<IProductoVarianteQuery, ProductoVarianteQuery>();

            services.AddTransient<IDescuentoQuery, DescuentoQuery>();
            services.AddTransient<IDescuentoCommand, DescuentoCommand>();

            services.AddTransient<IDescuentoProductoVarianteCommand, DescuentoProductoVarianteCommand>();
            services.AddTransient<IDescuentoProductoVarianteQuery, DescuentoProductoVarianteQuery>();

            //services.AddTransient<IDapperCommandService, DapperCommandService>();


            services.AddTransient<IKardexQuery, KardexQuery>();
            services.AddTransient<IProductoVarianteCommand, ProductoVarianteCommand>();

            return services;
        }
    }
}
