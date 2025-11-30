using MediatR;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries.ObtenerGuiasEntrada.Params;
using TSC.Expopunto.Application.DataBase.Parametro.Queries;
using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;
using TSC.Expopunto.Application.DataBase.Persona.Queries;
using TSC.Expopunto.Application.DataBase.Usuario.Queries;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Application.Interfaces.Services;

namespace TSC.Expopunto.Application.Features.GuiaEntrada.Queries.ObtenerGuiaEntradaPorNumeroSerie
{
    public class ObtenerGuiaEntradaPorNumeroSerieHandlerPdf : IRequestHandler<ObtenerGuiaEntradaPorNumeroSerieQueryPdf, byte[]?>
    {
        private readonly IGuiaEntradaRepository _guiaEntradaRepository;
        private readonly IDocumentoPdfService _documentoService;
        private readonly IParametroQuery _parametroQuery;
        private readonly IPersonaQuery _personaQuery;
        private readonly IUsuarioQuery _usuarioQuery;
        public ObtenerGuiaEntradaPorNumeroSerieHandlerPdf(
            IGuiaEntradaRepository guiaEntradaRepository,
            IDocumentoPdfService documentoPdfService,
            IParametroQuery parametroQuery,
            IPersonaQuery personaQuery,
            IUsuarioQuery usuarioQuery
         )
        {
            this._guiaEntradaRepository = guiaEntradaRepository;
            this._documentoService = documentoPdfService;
            this._parametroQuery = parametroQuery;
            this._personaQuery = personaQuery;
            this._usuarioQuery = usuarioQuery;
        }

        public async Task<byte[]?> Handle(ObtenerGuiaEntradaPorNumeroSerieQueryPdf query, CancellationToken cancellationToken)
        {
            var param = new ObtenerGuiasEntradaParams
            {
                Opcion = query.Opcion,
                Numero = query.Numero,
                Serie = query.Serie
            };

            var response = await this._guiaEntradaRepository.ObtenerGuiaEntradaPorNumeroSerieAsync(param);
            var codigoParametros = new List<string>
            {
                "P00002", //Razón social
                "P00003", //Dirección
                "P00004", //Teléfono
                "P00033" //Ruc
            };

            var parametro = new ParametrosListaParametros
            {
                Codigos = string.Join(",", codigoParametros)
            };

            var dataEmpresa = await _parametroQuery.ListarParametrosPorCodigoAsync(parametro);
            var dataProveedor = await _personaQuery.ListarPersonasPorIdAsync(response.IdProveedor);
            var dataUsuario = await _usuarioQuery.ObtenerUsuarioPorIdAsync(response.IdUsuarioRegistro);

            // Generar PDF
            return _documentoService.GenerarGuiaEntradaPdf(response, dataEmpresa, dataProveedor, dataUsuario);
        }
    }
}
