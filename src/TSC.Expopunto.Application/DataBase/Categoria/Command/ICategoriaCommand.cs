namespace TSC.Expopunto.Application.DataBase.Categoria.Command
{
    public interface ICategoriaCommand
    {
        Task<CategoriaModel> ProcesarAsync(CategoriaModel model);
    }
}
