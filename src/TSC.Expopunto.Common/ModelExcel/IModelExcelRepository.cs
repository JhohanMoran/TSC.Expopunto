namespace TSC.Expopunto.Common.ModelExcel
{
    /// <summary>
    /// Define las operaciones para la generación de archivos Excel.
    /// </summary>
    public interface IModelExcelRepository
    {
        /// <summary>
        /// Exporta una lista de datos genéricos a un archivo Excel.
        /// </summary>
        /// <typeparam name="T">El tipo de los objetos dentro de la lista.</typeparam>
        /// <param name="data">Lista de datos que se exportarán al Excel.</param>
        /// <param name="title">Título principal de la hoja de Excel.</param>
        /// <param name="headers">Lista opcional de encabezados de columnas. Si es null, se usarán las propiedades de <typeparamref name="T"/>.</param>
        /// <param name="maxWidth">Ancho máximo de las columnas (opcional).</param>
        /// <returns>Un <see cref="MemoryStream"/> que contiene el archivo Excel generado.</returns>
        MemoryStream ExportExcelDefault<T>(List<T> data, string title, List<string>? headers = null, double? maxWidth = null);
    }
}
