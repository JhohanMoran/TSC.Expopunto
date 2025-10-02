using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Queries
{
    public interface IGuiaEntradaQuery
    {
        Task<List<ProveedoreGuiaEntadaDto>> GetProveedoresAsync(int opcion);
    }
}
