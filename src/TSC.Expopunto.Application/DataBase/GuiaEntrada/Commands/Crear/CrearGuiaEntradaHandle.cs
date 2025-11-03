using MediatR;
using System.Data;
using TSC.Expopunto.Application.DataBase.Categoria.Command;
using TSC.Expopunto.Application.DataBase.Categoria.Queries;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.Producto.Command;
using TSC.Expopunto.Application.DataBase.Producto.Queries;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Commands;
using TSC.Expopunto.Application.DataBase.ProductoVariante.Commands.Models;
using TSC.Expopunto.Application.Interfaces.Repositories.GuiaEntrada;
using TSC.Expopunto.Common;
using TSC.Expopunto.Domain.Entities.GuiaEntrada;



namespace TSC.Expopunto.Application.DataBase.GuiaEntrada.Commands.Crear
{
    public class CrearGuiaEntradaHandle : IRequestHandler<CrearGuiaEntradaCommand, GuiaEntradaDTO>
    {
        private readonly IGuiaEntradaRepository _repository;
        private readonly IProductoCommand _productoCommand;
        private readonly ICategoriaCommand _categoriaCommand;
        private readonly ICategoriaQuery _categoriaQuery;
        private readonly IProductoQuery _productoQuery;
        private readonly IProductoVarianteCommand _productoVarianteCommand;

        public CrearGuiaEntradaHandle(
            IGuiaEntradaRepository repository,
            IProductoCommand productoCommand,
            ICategoriaCommand categoriaCommand,
            ICategoriaQuery categoriaQuery,
            IProductoQuery productoQuery,
            IProductoVarianteCommand productoVarianteCommand
         )
        {
            _repository = repository;
            _productoCommand = productoCommand;
            _categoriaCommand = categoriaCommand;
            _categoriaQuery = categoriaQuery;
            _productoQuery = productoQuery;
            _productoVarianteCommand = productoVarianteCommand;
        }

        public async Task<GuiaEntradaDTO> Handle(CrearGuiaEntradaCommand request, CancellationToken cancellationToken)
        {
            GuiaEntradaEntity guiaEntrada = new GuiaEntradaEntity();

            // 1️. Guardar el producto

            foreach (var item in request.Detalles)
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
                            NumCaja = item.NumCaja.ToString()
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

            guiaEntrada = new GuiaEntradaEntity(
                request.Id,
                request.Serie,
                request.Numero,
                request.Fecha,
                request.Hora,
                request.IdProveedor,
                request.TipoGuia,
                request.Observacion,
                request.TotalCantidad,
                request.IdUsuario
            );

            foreach (var d in request.Detalles)
            {
                guiaEntrada.AgregarDetalle(
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
                );
            }

            // 2. Guardar en BD (Dapper/SP)
            GuiaEntradaEntity guiaEntradaRespuesta = await _repository.CrearGuiaEntradaAsync(guiaEntrada);

            // Retornar un DTO
            return new GuiaEntradaDTO
            {
                Id = guiaEntradaRespuesta.Id, // ahora ya tiene el Id asignado desde la BD
                Serie = guiaEntradaRespuesta.Serie,
                Numero = guiaEntradaRespuesta.Numero,
                Fecha = guiaEntradaRespuesta.Fecha,
                Hora = guiaEntrada.Hora,
                IdProveedor = guiaEntradaRespuesta.IdProveedor,
                TipoGuia = guiaEntradaRespuesta.TipoGuia,
                Observacion = guiaEntradaRespuesta.Observacion,
                TotalCantidad = guiaEntradaRespuesta.TotalCantidad,
                TotalCosto = guiaEntradaRespuesta.TotalCosto,
                Detalles = guiaEntradaRespuesta.Detalles.Select(x => new DetalleGuiaEntradaDTO
                {

                    Id = x.Id, // Id asignado en la BD
                    IdGuiaEntrada = x.IdGuiaEntrada,  // también ya viene actualizado
                    IdProducto = x.IdProducto,
                    IdUnidadMedida = x.IdUnidadMedida,
                    CodUniMed = x.CodUniMed,
                    Cantidad = x.Cantidad,
                    NumCaja = x.NumCaja,
                    CodProducto = x.CodProducto,
                    Nombre = x.Nombre,
                    CodigoEstilo = x.CodigoEstilo,
                    CodigoPedido = x.CodigoPedido,
                    IdCategoria = x.IdCategoria,
                    Categoria = x.Categoria,
                    Genero = x.Genero,
                    Color = x.Color,
                    Talla = x.Talla,
                }).ToList()
            };
        }

    }
}
