namespace TSC.Expopunto.Application.DataBase.TipoDocumento.Commands
{
    public interface ITipoDocumentoCommand
    {
        Task<TipoDocumentoModel> ProcesarAsync(TipoDocumentoModel model);
    }
}
