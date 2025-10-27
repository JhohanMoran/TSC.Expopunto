using MediatR;
using TSC.Expopunto.Application.DataBase.Categoria.Command;
using TSC.Expopunto.Application.DataBase.Categoria.Queries;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Actualizar;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.Producto.Command;
using TSC.Expopunto.Application.DataBase.Producto.Queries;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Commands;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Commands.Models;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;

namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands
{
    public class ActualizarGuiaEntradaHandler : IRequestHandler<ActualizarGuiaEntradaCommand, GuiaEntradaDTO>
    {
        private readonly IGuiaEntradaRepository _repository;
        private readonly IProductoCommand _productoCommand;
        private readonly IProductoQuery _productoQuery;
        private readonly ICategoriaQuery _categoriaQuery;
        private readonly ICategoriaCommand _categoriaCommand;
        private readonly IProductoVarianteCommand _productoVarianteCommand;

        public ActualizarGuiaEntradaHandler(
            IGuiaEntradaRepository repository,
            IProductoCommand productoCommand,
            IProductoQuery productoQuery,
            ICategoriaQuery categoriaQuery,
            ICategoriaCommand categoriaCommand,
            IProductoVarianteCommand productoVarianteCommand
        )
        {
            _repository = repository;
            _productoCommand = productoCommand;
            _productoQuery = productoQuery;
            _categoriaQuery = categoriaQuery;
            _categoriaCommand = categoriaCommand;
            _productoVarianteCommand = productoVarianteCommand;

        }

        public async Task<GuiaEntradaDTO> Handle(ActualizarGuiaEntradaCommand request, CancellationToken cancellationToken)
        {
            GuiaEntradaEntity venta = new GuiaEntradaEntity();

            // 1️. Recuperar GuiaEntrada existente
            var guiaEntradaExistente = await _repository.ObtenerGuiaEntradaPorIdAsync(request.Id);

            if (guiaEntradaExistente is null)
                throw new KeyNotFoundException($"No se encontró la guiaEntrada con ID {request.Id}");

            // 2️. Actualizar
            var nuevosDetalles = request.Detalles
                .Select(d => new DetalleGuiaEntradaEntity(
                    d.Id,
                    d.IdGuiaEntrada,
                    d.IdProducto,
                    d.IdUnidadMedida,
                    "",
                    d.Cantidad,
                    d.NumCaja.ToString(),
                    "",
                    d.Nombre,
                    d.CodigoEstilo,
                    d.CodigoPedido,
                    0,
                    d.Categoria,
                    d.Genero,
                    d.Color,
                    d.CodigoSku,
                    d.Talla,
                    d.IdUsuario


                ))
                .ToList();

            guiaEntradaExistente.Actualizar(
                request.Id,
                request.Serie,
                request.Numero,
                request.Fecha,
                request.Hora,
                request.IdProveedor,
                request.TipoGuia,
                request.Observacion,
                request.TotalCantidad,
                request.IdUsuario,
                nuevosDetalles
            );


            // 2.1 Se revisa cuales son los nuevos detalles por registrar en base al idDetalle (0 es nuevo)
            foreach (var item in guiaEntradaExistente.Detalles.Where(item => item.Id == 0).ToList())
            {
                int idCategoria = 0;
                int idProducto = 0;

                #region Registro de categorias

                var categoriaExistente = await this._categoriaQuery.ListarPorNombreAsync(item.Categoria, 4);

                if (categoriaExistente == null)
                {
                    var nuevaCategoria = new CategoriaModel
                    {
                        Opcion = (int)OperationType.Create,
                        Id = 0,
                        Nombre = item.Categoria,
                        Descripcion = item.Categoria,
                        IdUsuario = item.IdUsuario,
                    };
                    var responseCategoria = await this._categoriaCommand.ProcesarAsync(nuevaCategoria);
                    idCategoria = responseCategoria.Id;
                }
                else
                {
                    idCategoria = categoriaExistente.IdCategoria;
                }

                #endregion

                #region Registro de productos

                if (idCategoria > 0)
                {
                    var productoExistente = await this._productoQuery.ListarPorNombre(4, idCategoria, item.Nombre, item.Genero);

                    if (productoExistente == null)
                    {
                        var nuevoProducto = new ProductoModel
                        {
                            Opcion = (int)OperationType.Create,
                            Id = 0,
                            IdCategoria = idCategoria,
                            CodProducto = "",
                            Nombre = item.Nombre,
                            Genero = item.Genero,
                            IdUsuario = item.IdUsuario,
                            Activo = 1,
                            NumCaja = item.NumCaja
                        };

                        var responseProducto = await this._productoCommand.ProcesarAsync(nuevoProducto);
                        idProducto = responseProducto.Id;
                    }
                    else
                    {
                        idProducto = productoExistente.Id;
                    }

                }
                #endregion

                #region Registro de la variante producto

                var parametrosVarianteProducto = new ProductoVarianteModel
                {
                    Opcion = (int)OperationType.Create,
                    Id = 0,
                    IdProducto = idProducto,
                    Talla = item.Talla,
                    Color = item.Color,
                    CodigoSKU = item.CodigoSku
                };

                var productoVarianteRegistrado = await this._productoVarianteCommand.ProcesarAsync(parametrosVarianteProducto);
                item.IdProducto = productoVarianteRegistrado.Id;
                #endregion
            }
            // 3️. Guardar en BD
            GuiaEntradaEntity guiaEntradaRespuesta = await _repository.ActualizarGuiaEntradaAsync(guiaEntradaExistente);

            // 4. Retornar el detalle completo de la GuiaEntrada actualizada
            var guiaEntradaDetalleRespuesta = await _repository.ObtenerDetalleGuiaEntradaPorIdGuiaAsync(guiaEntradaRespuesta.Id);


            return new GuiaEntradaDTO
            {
                Id = guiaEntradaRespuesta.Id, // ahora ya tiene el Id asignado desde la BD
                Serie = guiaEntradaRespuesta.Serie,
                Numero = guiaEntradaRespuesta.Numero,
                Fecha = guiaEntradaRespuesta.Fecha,
                IdProveedor = guiaEntradaRespuesta.IdProveedor,
                TipoGuia = guiaEntradaRespuesta.TipoGuia,
                Observacion = guiaEntradaRespuesta.Observacion,


                Detalles = guiaEntradaDetalleRespuesta.Select(x => new DetalleGuiaEntradaDTO
                {
                    Id = x.Id, // Id asignado en la BD
                    IdGuiaEntrada = x.IdGuiaEntrada,
                    IdProducto = x.IdProducto,
                    IdUnidadMedida = x.IdUnidadMedida,
                    CodUniMed = x.CodUniMed,
                    Cantidad = x.Cantidad,
                    NumCaja = x.NumCaja,
                    CodigoEstilo = x.CodigoEstilo,
                    CodigoPedido = x.CodigoPedido


                }).ToList()
            };
        }

    }
}
