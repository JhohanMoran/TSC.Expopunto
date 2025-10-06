using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSC.Expopunto.Application.DataBase.Venta.DTO;

namespace TSC.Expopunto.Application.DataBase.Venta.Queries.ObtenerVentasPorIdPersona
{
    public record ObtenerVentasPorIdPersonaQuery(int IdPersona) : IRequest<List<VentaMontoDTO?>>;
}
