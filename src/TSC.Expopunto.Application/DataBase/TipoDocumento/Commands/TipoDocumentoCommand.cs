namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Commands
{
    public class TipoDocumentoCommand : ITipoDocumentoCommand
    {
        private readonly IDapperCommandService _dapperService;

        public TipoDocumentoCommand(IDapperCommandService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<TipoDocumentoModel> ProcesarAsync(TipoDocumentoModel model)
        {
            var response = await _dapperService.ExecuteScalarAsync("uspSetTipoDocumento",
                new
                {
                    p_opcion = model.opcion,

                    p_id = model.id,
                    p_codigo = model.codigo,
                    p_descripcion = model.descripcion,

                    p_idUsuario = model.idUsuario,
                    p_activo = model.activo
                });

            if (response > 1)
            {
                model.id = response;
            }

            return model;

        }
    }
}
