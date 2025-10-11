using ClosedXML.Excel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TSC.Expopunto.Common.ModelExcel
{
    public class ModelExcelRepository : IModelExcelRepository
    {
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;

            while (dividend > 0)
            {
                int modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }
        public MemoryStream ExportExcelDefault<T>(List<T> data, string title, List<string>? headers, double? maxWidth)
        {
            var stream = new MemoryStream();
            using (var package = new XLWorkbook())
            {
                var ws = package.Worksheets.Add("Hoja1");
                if (data.Count == 0)
                {
                    ws.Range("A1").Style.Font.FontColor = XLColor.White;
                    ws.Range("A1").Style.Fill.BackgroundColor = XLColor.DarkRed;
                    ws.Cell("A1").Value = title;
                    package.SaveAs(stream);
                    stream.Position = 0;
                    return stream;
                }
                int numColumns = data[0].GetType().GetProperties().Length;

                string rangeHeader = $"A1:{GetExcelColumnName(numColumns)}1";
                string rangoStyle = $"A1:{GetExcelColumnName(numColumns)}2";

                // Ajustar estilo de las columnas
                string rangeColumns = $"A:{GetExcelColumnName(numColumns)}";
                ws.Columns(rangeColumns).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                //estilos de la cabecera
                ws.Range(rangeHeader).Merge();
                ws.Range(rangoStyle).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range(rangoStyle).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                ws.Range(rangoStyle).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                ws.Range(rangoStyle).Style.Border.OutsideBorderColor = XLColor.Black;
                ws.Range(rangoStyle).Style.Border.InsideBorderColor = XLColor.Black;
                ws.Range(rangoStyle).Style.Fill.BackgroundColor = XLColor.FromArgb(201, 201, 201);
                ws.Range(rangoStyle).Style.Font.Bold = true;
                ws.Range(rangeHeader).Style.Font.FontColor = XLColor.White;
                ws.Range(rangeHeader).Style.Fill.BackgroundColor = XLColor.DarkRed;

                // Cabecera de tabla
                ws.Cell("A1").Value = title;

                if (headers != null)
                {

                    for (int i = 0; i < headers.Count; i++)
                    {
                        ws.Cell(2, i + 1).Value = headers[i].ToString();
                    }
                }
                else
                {
                    var props = data[0].GetType().GetProperties();
                    for (int i = 0; i < props.Length; i++)
                    {
                        var displayAttr = props[i].GetCustomAttribute<DisplayAttribute>();
                        string headerName = displayAttr?.Name ?? props[i].Name; // usa Display si existe
                        ws.Cell(2, i + 1).Value = headerName;
                    }

                }

                // Detalle de tabla
                int row = 3;
                int batchSize = 10000; // Tamaño del lote
                int totalRecords = data.Count;
                int batches = (int)Math.Ceiling((double)totalRecords / batchSize);
                for (int batch = 0; batch < batches; batch++)
                {
                    int startIndex = batch * batchSize;
                    int endIndex = Math.Min(startIndex + batchSize - 1, totalRecords - 1);

                    var batchItems = data.GetRange(startIndex, endIndex - startIndex + 1);


                    foreach (var item in batchItems)
                    {
                        var valores = item.GetType().GetProperties();
                        for (int i = 0; i < valores.Length; i++)
                        {

                            var type = Nullable.GetUnderlyingType(valores[i].PropertyType) ?? valores[i].PropertyType;

                            if (type == typeof(string))
                            {
                                ws.Cell(row, i + 1).Value = valores[i].GetValue(item)?.ToString();
                            }
                            else if (type == typeof(decimal))
                            {
                                decimal? valor = valores[i].GetValue(item, null) as decimal?;
                                ws.Cell(row, i + 1).Value = valor;
                                ws.Cell(row, i + 1).Style.NumberFormat.NumberFormatId = 2;
                            }
                            else if (type == typeof(int))
                            {
                                int? valor = valores[i].GetValue(item, null) as int?;
                                ws.Cell(row, i + 1).Value = valor;
                                ws.Cell(row, i + 1).Style.NumberFormat.NumberFormatId = 1;
                            }
                            else if (type == typeof(DateTime))
                            {
                                DateTime? valor = valores[i].GetValue(item, null) as DateTime?;
                                ws.Cell(row, i + 1).Value = valor;
                                ws.Cell(row, i + 1).Style.DateFormat.Format = "dd/MM/yyyy";
                            }
                            else
                            {
                                ws.Cell(row, i + 1).Value = valores[i].GetValue(item)?.ToString();
                            }

                        }
                        row++;
                    }
                }

                if (data.Count != 0)
                {
                    string rangeTable = $"A2:{GetExcelColumnName(numColumns)}{row - 1}";
                    ws.Range(rangeTable).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    ws.Range(rangeTable).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                    ws.Range(rangeTable).Style.Border.OutsideBorderColor = XLColor.Black;
                    ws.Range(rangeTable).Style.Border.InsideBorderColor = XLColor.Black;
                    ws.Columns(rangeColumns).AdjustToContents();

                    if (maxWidth != null)
                    {
                        for (int i = 1; i <= numColumns; i++)
                        {
                            var column = ws.Column(i);

                            if (column.Width > maxWidth.Value)
                            {
                                column.Width = maxWidth.Value;
                            }
                        }
                    }

                }


                package.SaveAs(stream);
            }

            stream.Position = 0;
            return stream;
        }

    }
}
