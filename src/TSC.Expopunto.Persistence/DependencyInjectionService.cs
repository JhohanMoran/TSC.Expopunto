using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.Interfaces.Venta;
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

            return services;
        }
    }
}
