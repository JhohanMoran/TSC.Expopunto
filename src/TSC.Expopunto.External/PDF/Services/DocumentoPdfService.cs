using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Services;

namespace TSC.Expopunto.External.PDF.Services
{
    public class DocumentoPdfService : IDocumentoPdfService
    {
        public byte[] GenerarGuiaEntradaPdf(GuiaEntradaDTO parametro)
        {

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);

            var path = Path.Combine(AppContext.BaseDirectory, "resources", "logo.png");
            var logo = new Image(
                    iText.IO.Image.ImageDataFactory.Create(path)
                );

            logo.SetWidth(60); // ancho en puntos (1 punto ≈ 0.35 mm)
            logo.SetHeight(60);
            logo.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            // Ticket de 80mm ancho, altura estimada
            var pageSize = new iText.Kernel.Geom.PageSize(396, 612);
            var document = new Document(pdf, pageSize);
            document.SetMargins(5, 5, 5, 5); // márgenes muy pequeños

            // ---- ENCABEZADO ----
            var empresa = new Paragraph("Expo Punto")
                .SetBold().SetFontSize(9)
                .SetTextAlignment(TextAlignment.CENTER);
            empresa.Add("\nRUC: 20123456789");

            document.Add(logo);
            document.Add(empresa);
            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            var comprobante = new Paragraph($"{parametro.Serie}-{parametro.Numero}")
                .SetBold().SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
            document.Add(comprobante);

            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            // ---- DATOS CLIENTE ----
            document.Add(new Paragraph($"Proveedor: {parametro.NombreProveedor}").SetFontSize(8));
            document.Add(new Paragraph($"Doc: {parametro.DocumentoProveedor}").SetFontSize(8));
            document.Add(new Paragraph($"Fecha: {parametro.Fecha:dd/MM/yyyy} {parametro.Hora:HH:mm}").SetFontSize(8));
            document.Add(new Paragraph($"Observación: {parametro.Observacion}").SetFontSize(8));

            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            // ---- DETALLES PRODUCTOS ----
            // Columnas más simples para que encajen en el ancho
            var detalleTable = new Table(new float[] { 2, 3, 2, 2, 2, 2, 2, 2, 2, 1 }).UseAllAvailableWidth();


            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Cod. Prenda").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Nombre Prenda").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Num. Caja").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Cod. Estilo").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Cod. Pedido").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Categoría").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Género").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Color").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Talla").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Cantidad").SetFontSize(7).SetBold()));

            if (parametro.Detalles.Count() > 0)
            {
                foreach (var item in parametro.Detalles)
                {
                    detalleTable.AddCell(new Paragraph(item.CodProducto).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.Nombre).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.NumCaja).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.CodigoEstilo).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.CodigoPedido).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.Categoria).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.Genero).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.Color).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.Talla).SetFontSize(7));
                    detalleTable.AddCell(new Paragraph(item.Cantidad.ToString()).SetFontSize(7));
                }

            }

            document.Add(detalleTable);

            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));


            document.Close();
            return ms.ToArray();
        }

        public byte[] GenerarPdf(VentaDTO parametro)
        {
            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);

            // Ticket de 80mm ancho, altura estimada
            var pageSize = new iText.Kernel.Geom.PageSize(226, 1000);
            var document = new Document(pdf, pageSize);
            document.SetMargins(5, 5, 5, 5); // márgenes muy pequeños

            // ---- ENCABEZADO ----
            var empresa = new Paragraph("MI EMPRESA S.A.C.")
                .SetBold().SetFontSize(9)
                .SetTextAlignment(TextAlignment.CENTER);
            empresa.Add("\nRUC: 20123456789");
            empresa.Add($"\nSede: {parametro.Sede}");

            document.Add(empresa);
            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            var comprobante = new Paragraph($"{parametro.TipoComprobante}\n{parametro.Serie}-{parametro.Numero}")
                .SetBold().SetFontSize(9).SetTextAlignment(TextAlignment.CENTER);
            document.Add(comprobante);

            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            // ---- DATOS CLIENTE ----
            document.Add(new Paragraph($"Cliente: {parametro.NombrePersona}").SetFontSize(8));
            document.Add(new Paragraph($"Doc: {parametro.DocumentoPersona}").SetFontSize(8));
            document.Add(new Paragraph($"Fecha: {parametro.Fecha:dd/MM/yyyy} {parametro.Hora}").SetFontSize(8));
            document.Add(new Paragraph($"Vendedor: {parametro.NombreVendedor}").SetFontSize(8));

            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            // ---- DETALLES PRODUCTOS ----
            // Columnas más simples para que encajen en el ancho
            var detalleTable = new Table(new float[] { 3, 1, 1 }).UseAllAvailableWidth();

            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Desc").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Cant").SetFontSize(7).SetBold()));
            detalleTable.AddHeaderCell(new Cell().Add(new Paragraph("Imp").SetFontSize(7).SetBold()));

            foreach (var item in parametro.Detalles)
            {
                detalleTable.AddCell(new Paragraph(item.DescripcionProducto).SetFontSize(7));
                detalleTable.AddCell(new Paragraph(item.Cantidad.ToString()).SetFontSize(7));
                detalleTable.AddCell(new Paragraph(item.SubTotal.ToString("C")).SetFontSize(7));
            }

            document.Add(detalleTable);

            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            // ---- TOTALES ----
            var totales = new Paragraph()
                .Add($"Subtotal: {parametro.SubTotal:C}\n")
                .Add(parametro.DescuentoTotal > 0 ? $"Desc: {parametro.DescuentoTotal:C}\n" : "")
                .Add($"IGV: {parametro.Impuesto:C}\n")
                .Add($"TOTAL: {parametro.Total:C}")
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFontSize(8).SetBold();

            document.Add(totales);

            document.Add(new Paragraph("-------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));

            // ---- FORMAS DE PAGO ----
            if (parametro.FormasPago?.Any() == true)
            {
                document.Add(new Paragraph("Formas de Pago")
                    .SetBold().SetFontSize(8).SetTextAlignment(TextAlignment.CENTER));

                var pagoTable = new Table(new float[] { 2, 1 }).UseAllAvailableWidth();
                pagoTable.AddHeaderCell(new Cell().Add(new Paragraph("Forma").SetFontSize(7).SetBold()));
                pagoTable.AddHeaderCell(new Cell().Add(new Paragraph("Monto").SetFontSize(7).SetBold()));

                foreach (var pago in parametro.FormasPago)
                {
                    pagoTable.AddCell(new Paragraph(pago.FormaPago).SetFontSize(7));
                    pagoTable.AddCell(new Paragraph(pago.Monto.ToString("C")).SetFontSize(7));
                }

                document.Add(pagoTable);

                document.Add(new Paragraph("-------------------------------")
                    .SetTextAlignment(TextAlignment.CENTER).SetFontSize(7));
            }

            // ---- PIE DE PÁGINA ----
            document.Add(new Paragraph("¡Gracias por su compra!")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(8));

            document.Close();
            return ms.ToArray();
        }

    }
}
