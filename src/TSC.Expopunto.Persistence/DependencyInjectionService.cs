using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Application.Interfaces.Repositories.Venta;
using TSC.Expopunto.Application.Interfaces.Repositories.VentaTipoOperacion;
using TSC.Expopunto.Persistence.DataBase;
using TSC.Expopunto.Persistence.Repositories;

namespace TSC.Expopunto.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddScoped<IDapperQueryService, DapperService>();
            services.AddScoped<IDapperCommandService, DapperService>();

            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IGuiaEntradaRepository, GuiaEntradaRepository>();
            services.AddScoped<IVentaTipoOperacionRepository, VentaTipoOperacionRepository>();

            return services;
        }
    }
}
