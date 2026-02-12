using MediatR;
using System.Collections.Generic;
using System;

namespace TSC.Expopunto.Application.DataBase.Venta.Commands.RegistrarDeposito
{
    public record RegistrarDepositoCommand(
        string NroOperacion,
        DateTime Fecha,
        int IdUsuario,
        List<int> IdsVentas
    ) : IRequest<bool>; // Igual que AprobarVentaCommand
}