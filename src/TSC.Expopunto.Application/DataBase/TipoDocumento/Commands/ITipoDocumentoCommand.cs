using TSC.Expopunto.Application.DataBase.TipoDocumento.Commands;

namespace TSC.Expopunto.Application.DataBase.TiposDocumento.Commands
{
    internal interface ITipoDocumentoCommand
    {
        Task<TipoDocumentoModel> ProcesarAsync(TipoDocumentoModel model);
    }
}
