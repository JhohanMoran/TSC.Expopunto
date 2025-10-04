using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.Expopunto.Application.DataBase.DetalleGuiaEntrada.Commands
{
    public record DetalleGuiaEntradaCommand
    (
        int Id,
        int IdGuiaEntrada,
        int IdProducto,
        int IdUnidadMedida,
        int IdTalla,
        int Cantidad,
        decimal CostoUnitario,
        int idUsuario
    );
}
