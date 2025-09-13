namespace TSC.Expopunto.Application.DataBase.Categoria.Command
{
    public class CategoriaCommand : ICategoriaCommand
    {
        private readonly IDapperCommandService _dapperCommandSevice;

        public CategoriaCommand(IDapperCommandService dapperCommandService)
        {
            _dapperCommandSevice = dapperCommandService;
        }
        public async Task<CategoriaModel> ProcesarAsync(CategoriaModel model)
        {
            var parametros = new
            {
                pOpcion = model.Opcion,
                pId = model.Id,
                pNombre = model.Nombre,
                pDescripcion = model.Descripcion,
                pIdUsuario = model.IdUsuario
            };

            var response = await _dapperCommandSevice.ExecuteScalarAsync("uspSetCategoria", parametros);

            if (response > 0)
            {
                model.Id = response;
            }

            return model;
        }
    }
}
