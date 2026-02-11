using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using TSC.Expopunto.Application.DataBase.Prendas.Queries.Models;

namespace TSC.Expopunto.Application.DataBase.Prendas.Queries
{
    public class PrendasQuery : IPrendasQuery
    {
        private readonly IDapperQueryService _dapperQuerySevice;
        public PrendasQuery(IDapperQueryService dapperQuerySevice)
        {
            _dapperQuerySevice = dapperQuerySevice;
        }

        public async Task<List<PrendasDatosClientes>> ListarClientesAsync()
        {
            var parametros = new
            {
                pOpcion = 2
            };

            _dapperQuerySevice.UsarConexion("SQLConnectionSigeString");

            var results = await _dapperQuerySevice.QueryAsync<PrendasDatosClientes>("uspGetStockExpoPunto", parametros, 0);
            return results.ToList();
        }

        public async Task<List<PrendasDatosEstiloClientes>> ListarEstilosClientesAsync(string pedido, string codigoCliente)
        {
            var parametros = new
            {
                pOpcion = 4,
                pPedido = pedido,
                pCodigoCliente = codigoCliente
            };

            _dapperQuerySevice.UsarConexion("SQLConnectionSigeString");

            var results = await _dapperQuerySevice.QueryAsync<PrendasDatosEstiloClientes>("uspGetStockExpoPunto", parametros, 0);
            return results.ToList();
        }

        public async Task<List<PrendasTodos>> ListarPaginadoStockAptAsync(PrendasParams param)
        {
            var propiedadesConocidas = typeof(PrendasTodos)
                .GetProperties()
                .Where(prop => prop.Name != "Tallas" && prop.CanWrite)
                .ToList();

            var nombresConocidos = propiedadesConocidas
                .Select(prop => prop.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var parametros = new
            {
                pOpcion = 1,
                pPedido = param.Pedido,
                pCodigoCliente = param.CodigoCliente,
                pEstiloCliente = param.EstiloCliente,
                pCodPresent = param.CodPresent,
                pOrdenColumna = param.OrdenarPor,
                pOrdenDireccion = param.OrdenDireccion,
                pPagina = param.Pagina,
                pFilasPorPagina = param.FilasPorPagina,
            };

            _dapperQuerySevice.UsarConexion("SQLConnectionSigeString");

            var resultQuery = await _dapperQuerySevice.QueryAsync<dynamic>("uspGetStockExpoPunto", parametros, 0);
            var lista = new List<PrendasTodos>();

            foreach(IDictionary<string, object> item in resultQuery)
            {
                var prenda = new PrendasTodos();

                foreach(var prop in propiedadesConocidas)
                {
                    if(item.TryGetValue(prop.Name, out var valor))
                    {
                        if(prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(prenda, valor?.ToString() ?? "");
                        }
                    }
                    else if (IsNumericType(prop.PropertyType))
                    {
                        var valorNumerico = valor == null || string.IsNullOrWhiteSpace(valor.ToString())
                            ? 0
                            : Convert.ToInt32(valor);
                        prop.SetValue(prenda, valorNumerico);
                    }
                    else
                    {
                        prop.SetValue(prenda, valor);
                    }
                }

                prenda.Tallas = new Dictionary<string, int>();

                // Todo lo demás son tallas
                foreach (var kv in item)
                {
                    if (!nombresConocidos.Contains(kv.Key))
                    {
                        prenda.Tallas[kv.Key] = kv.Value == null ? 0 : Convert.ToInt32(kv.Value);
                    }
                }

                lista.Add(prenda);
            }
            //Funciona pero se va a meojrar
            /*
            foreach (IDictionary<string, object> row in rows)
            {
                var prenda = new PrendasTodos
                {
                    NumCaja = row["NumCaja"]?.ToString() ?? "",
                    Cliente = row["Cliente"]?.ToString() ?? "",
                    CodFabrica = row["CodFabrica"]?.ToString() ?? "",
                    Pedido = row["Pedido"]?.ToString() ?? "",
                    CodPresent = row["CodPresent"]?.ToString() ?? "",
                    SubLinea = row["SubLinea"]?.ToString() ?? "",
                    TipoPrenda = row["TipoPrenda"]?.ToString() ?? "",
                    Destino = row["Destino"]?.ToString() ?? "",
                    Tallas = new Dictionary<string, int>()
                };

                // Recorrer todas las columnas y detectar cuáles son tallas
                foreach (var kv in row)
                {
                    if (kv.Key is "NumCaja"
                        or "Cliente" or "CodFabrica"
                        or "Pedido" or "CodPresent"
                        or "SubLinea" or "TipoPrenda"
                        or "Destino")
                        continue;

                    // Aquí entran dinámicamente todas las tallas 
                    prenda.Tallas[kv.Key] = kv.Value == null ? 0 : Convert.ToInt32(kv.Value);
                }

                lista.Add(prenda);
            }*/

            return lista;
        }

        public async Task<List<PrendasDatosPedidos>> ListarPedidosAsync(string codigoCliente)
        {
            var parametros = new
            {
                pOpcion = 3,
                pCodigoCliente = codigoCliente
            };

            _dapperQuerySevice.UsarConexion("SQLConnectionSigeString");

            var results = await _dapperQuerySevice.QueryAsync<PrendasDatosPedidos>("uspGetStockExpoPunto", parametros, 0);
            return results.ToList();
        }

        public async Task<List<PrendasDatosPrensentaciones>> ListarPrensentacionesAsync(string pedido)
        {
            var parametros = new
            {
                pOpcion = 5,
                pPedido = pedido
            };

            _dapperQuerySevice.UsarConexion("SQLConnectionSigeString");

            var results = await _dapperQuerySevice.QueryAsync<PrendasDatosPrensentaciones>("uspGetStockExpoPunto", parametros, 0);
            return results.ToList();
        }

        private bool IsNumericType(Type type)
        {
            return type == typeof(int) ||
                   type == typeof(long) ||
                   type == typeof(short) ||
                   type == typeof(byte) ||
                   type == typeof(decimal) ||
                   type == typeof(double) ||
                   type == typeof(float) ||
                   type == typeof(int?) ||
                   type == typeof(long?) ||
                   type == typeof(short?) ||
                   type == typeof(byte?) ||
                   type == typeof(decimal?) ||
                   type == typeof(double?) ||
                   type == typeof(float?);
        }

    }
}
