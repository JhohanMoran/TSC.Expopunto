using TSC.Expopunto.Application.DataBase.Accesos.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Accesos.Queries
{
    public class AccesosQuery : IAccesosQuery
    {
        private readonly IDapperQueryService _dapperService;

        public AccesosQuery(IDapperQueryService dapperService)
        {
            _dapperService = dapperService;
        }

        public async Task<IEnumerable<AccesosModel>> ObtenerMenuPorPerfilAsync(int idPerfil)
        {
            var parameters = new
            {
                IdPerfil = idPerfil
            };

            var response = await _dapperService.QueryAsync<AccesosModel>("uspGetAccesos", parameters);

            // Agrupar jerárquicamente
            var lookup = response.ToList().ToDictionary(m => m.Id, m => m);

            List<AccesosModel> menuRaiz = new List<AccesosModel>();

            foreach (var item in lookup.Values)
            {
                if (item.IdMenuPadre == 0)
                {
                    menuRaiz.Add(item);
                }
                else if (lookup.ContainsKey(item.IdMenuPadre.Value))
                {
                    // Es hijo → lo agregamos al padre
                    lookup[item.IdMenuPadre.Value].Hijos.Add(item);
                }
            }

            return menuRaiz;
        }
    }
}
