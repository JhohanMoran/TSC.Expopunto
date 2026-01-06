using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSC.Expopunto.Application.DataBase;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstado;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoBaja;
using TSC.Expopunto.Application.Interfaces.Repositories.DocumentoEstadoMotivoBaja;
using TSC.Expopunto.Application.Interfaces.Repositories.EmisionComprobanteSunat;
using TSC.Expopunto.Application.Interfaces.Repositories.Estado;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Application.Interfaces.Repositories.MotivoBaja;
using TSC.Expopunto.Application.Interfaces.Repositories.Persona;
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
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IGuiaEntradaRepository, GuiaEntradaRepository>();
            services.AddScoped<IVentaTipoOperacionRepository, VentaTipoOperacionRepository>();
            services.AddScoped<IMotivoBajaRepository, MotivoBajaRepository>();
            services.AddScoped<IDocumentoEstadoRepository, DocumentoEstadoRepository>();
            services.AddScoped<IDocumentoEstadoBajaRepository, DocumentoEstadoBajaRepository>();
            services.AddScoped<IDocumentoEstadoMotivoBajaRepository, DocumentoEstadoMotivoBajaRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEmisionComprobanteSunatRepository, EmisionComprobanteSunatRepository>();

            return services;
        }
    }
}
