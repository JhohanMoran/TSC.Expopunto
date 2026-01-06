using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Parametro.Queries;
using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;
using TSC.Expopunto.Application.Interfaces.Repositories.EmisionComprobanteSunat;
using TSC.Expopunto.Domain.Entities.EmisionComprobanteSunat;

namespace TSC.Expopunto.Application.DataBase.EmisionComprobanteSunat.Queries.ObtenerComprobanteSunat
{
    public class ObtenerComprobanteSunatHandler : IRequestHandler<ObtenerComprobanteSunatQuery, Unit>
    {
        private readonly IEmisionComprobanteSunatRepository _repository;
        private readonly IParametroQuery _parametroQuery;
        public ObtenerComprobanteSunatHandler(IEmisionComprobanteSunatRepository repository, IParametroQuery parametroQuery)
        {
            _repository = repository;
            _parametroQuery = parametroQuery;
        }
        public async Task<Unit> Handle(ObtenerComprobanteSunatQuery request, CancellationToken cancellationToken)
        {
            // 1. Obtener la lista del comprobante
            var comprobante = await _repository.ObtenerComprobanteSunatAsync(request.Parametros);
            if (comprobante == null || !comprobante.Any())
                throw new Exception("No existen registros para generar el TXT.");

            // 2. Obtener la ruta desde parámetros
            var codigos = new ParametrosListaParametros
            {
                Codigos = "P00035"
            };

            var parametro = await _parametroQuery.ListarParametrosPorCodigoAsync(codigos);
            var ruta = parametro.FirstOrDefault()?.Valor ?? string.Empty;

            // 3. Crear la carpeta si no existe
            Directory.CreateDirectory(ruta);

            // 4. Generar contenido: una línea por cada CodFacturacion
            var contenido = string.Join(Environment.NewLine,
                comprobante.Select(x => x.CodFacturacion)
            );

            // 5. Construir la ruta del archivo
            var path = Path.Combine(ruta, $"{request.Parametros.NombreTxt}.txt");

            // 6. Guardar TXT
            await File.WriteAllTextAsync(path, contenido);

            return Unit.Value;
        }
    }
}
