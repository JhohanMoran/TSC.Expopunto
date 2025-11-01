using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Services;
using TSC.Expopunto.External.PDF.Handlers;
//using iText.Kernel.Geom;

namespace TSC.Expopunto.External.PDF.Services
{
    public class DocumentoPdfService : IDocumentoPdfService
    {
        public byte[] GenerarGuiaEntradaPdf(GuiaEntradaDTO parametro, List<ParametrosModel> dataEmpresa, PersonaTodosModel? dataProveedor, UsuariosTodosModel dataUsuario)
        {

            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);

            var contenedorEncabezado = new Div()
            .SetTextAlignment(TextAlignment.LEFT)
            .SetMargin(25);

            var contenedorGuia = new Div()
            .SetTextAlignment(TextAlignment.CENTER)
            .SetVerticalAlignment(VerticalAlignment.MIDDLE)
            .SetHorizontalAlignment(HorizontalAlignment.CENTER)
            .SetMargin(25);

            var path = Path.Combine(AppContext.BaseDirectory, "wwwroot", "resources", "logo.png");
            var logo = new Image(iText.IO.Image.ImageDataFactory.Create(path));
            logo.SetWidth(80); // ancho en puntos (1 punto ≈ 0.35 mm)
            logo.SetHeight(80);
            logo.SetHorizontalAlignment(HorizontalAlignment.LEFT);

            string direccion, razonSocial, telefono, ruc;

            //Tablas
            var headerTable = new Table(new float[] { 1, 1 }).UseAllAvailableWidth()
                .SetMargin(25);

            var proveedorTable = new Table(UnitValue.CreatePercentArray(new float[] { 25, 75 }))
                .SetWidth(UnitValue.CreatePercentValue(100))
                .SetBorder(Border.NO_BORDER)
                .SetMarginLeft(25)
                .SetMarginRight(25)
                .SetMarginBottom(25);

            var observacionesTable = new Table(new float[] { 1 }).UseAllAvailableWidth()
               .SetMarginLeft(25)
               .SetMarginRight(25)
               .SetMarginBottom(25);

            razonSocial = dataEmpresa.FirstOrDefault(item => item.Codigo == "P00002")?.Valor ?? "";
            direccion = dataEmpresa.FirstOrDefault(item => item.Codigo == "P00003")?.Valor ?? "";
            telefono = dataEmpresa.FirstOrDefault(item => item.Codigo == "P00004")?.Valor ?? "";
            ruc = dataEmpresa.FirstOrDefault(item => item.Codigo == "P00033")?.Valor ?? "";

            //Datos principales
            //Empresa
            // A4
            var pageSize = new iText.Kernel.Geom.PageSize(595, 842);// 595x842 pt = 210x297 mm
            var document = new Document(pdf, pageSize);
            document.SetMargins(15, 15, 15, 15);

            // ---- ENCABEZADO ----
            var empresa = new Paragraph(razonSocial)
                .SetBold().SetFontSize(12)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(12);

            var pRuc = new Paragraph()
                .Add(new Text("Ruc : ").SetBold())
                .Add(new Text(ruc))
                .SetFontSize(12);

            var pDireccion = new Paragraph()
                    .Add(new Text("Dirección : ").SetBold())
                    .Add(new Text(direccion))
                    .SetFontSize(12);

            var pTelefono = new Paragraph()
                    .Add(new Text("Teléfono : ").SetBold())
                    .Add(new Text(telefono))
                    .SetFontSize(12);

            contenedorEncabezado.Add(logo);
            contenedorEncabezado.Add(empresa);
            contenedorEncabezado.Add(pRuc);
            contenedorEncabezado.Add(pDireccion);
            contenedorEncabezado.Add(pTelefono);

            var cellLeft = new Cell().Add(contenedorEncabezado).SetBorder(Border.NO_BORDER);
            headerTable.AddCell(cellLeft);

            //Datos principales de guía

            var pGuia = new Paragraph()
                .Add($"GUÍA DE REMISION - {parametro.TipoGuia}")
                .SetBold()
                .SetFontSize(12);

            var pNumGuia = new Paragraph()
                .Add($"N° {parametro.Serie}-{parametro.Numero}")
                .SetBold()
                .SetFontSize(12);

            contenedorGuia.Add(pGuia);
            contenedorGuia.Add(pNumGuia);

            var cellRigth = new Cell().Add(contenedorGuia).SetBorder(new SolidBorder(ColorConstants.BLACK, 1))
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER);
            headerTable.AddCell(cellRigth);

            document.Add(headerTable);



            // ---- DATOS PROVEEDOR ----

            int totalFilas = 5;

            // Función local para saber si es la primera o última fila
            bool EsPrimeraFila(int fila) => fila == 1;
            bool EsUltimaFila(int fila) => fila == totalFilas;

            // --- Fila 1 ---
            int fila = 1;
            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph("Proveedor :").SetBold().SetFontSize(9))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(new SolidBorder(1))
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph(parametro.NombreProveedor).SetFontSize(9))
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(1))
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            // --- Fila 2 ---
            fila = 2;
            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph("Ruc :").SetBold().SetFontSize(9))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(new SolidBorder(1))
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph(parametro.DocumentoProveedor).SetFontSize(9))
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(1))
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            // --- Fila 3 ---
            fila = 3;
            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph("Dirección :").SetBold().SetFontSize(9))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(new SolidBorder(1))
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph(dataProveedor?.Direccion ?? "").SetFontSize(9))
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(1))
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            // --- Fila 4 ---
            fila = 4;
            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph("Fecha de emisión :").SetBold().SetFontSize(9))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(new SolidBorder(1))
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph(parametro.Fecha.ToString("dd/MM/yyyy")).SetFontSize(9))
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(1))
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            // --- Fila 5 ---
            fila = 5;
            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph("Hora de emisión :").SetBold().SetFontSize(9))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(new SolidBorder(1))
                .SetBorderRight(Border.NO_BORDER)
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            proveedorTable.AddCell(new Cell()
                .Add(new Paragraph(parametro.Hora.ToString(@"hh\:mm")).SetFontSize(9))
                .SetBorderTop(EsPrimeraFila(fila) ? new SolidBorder(1) : Border.NO_BORDER)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(1))
                .SetBorderBottom(EsUltimaFila(fila) ? new SolidBorder(1) : Border.NO_BORDER));

            document.Add(proveedorTable);

            // ---- DETALLES GUIA ----
            // Columnas más simples para que encajen en el ancho
            var detalleTable = new Table(new float[] { 2, 3, 2, 2, 2, 2, 2, 1 })
                .UseAllAvailableWidth()
                .SetMarginLeft(25)
                .SetMarginRight(25)
                .SetMarginBottom(25);

            var cabeceras = new List<string>{
                "Cod. Prenda",
                "Nombre Prenda",
                "Unid. Medida",
                "Num. Caja",
                "Talla",
                "Cod. Estilo",
                "Cod. Pedido",
                "Cantidad"
            };

            foreach (var cab in cabeceras)
            {
                detalleTable.AddHeaderCell(new Cell().Add(
                    new Paragraph(cab)
                    .SetFontSize(7)
                    .SetBold())
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    );
            }

            if (parametro.Detalles.Count() > 0)
            {
                foreach (var item in parametro.Detalles)
                {
                    detalleTable.AddCell(new Paragraph(item.CodProducto).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.Nombre).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.CodUniMed).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.NumCaja).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.Talla).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.CodigoEstilo).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.CodigoPedido).SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(Convert.ToInt32(item.Cantidad).ToString()).SetFontSize(7).SetTextAlignment(TextAlignment.RIGHT));
                }

            }

            //Total
            var totalCantidad = parametro.Detalles.Sum(item => item.Cantidad);

            detalleTable.AddCell(new Paragraph("Total").SetFontSize(7).SetTextAlignment(TextAlignment.CENTER));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(Convert.ToInt32(totalCantidad).ToString()).SetFontSize(7).SetTextAlignment(TextAlignment.RIGHT));

            document.Add(detalleTable);

            var pObservaciones = new Paragraph("Observaciones : ")
                .SetBold()
                .SetFontSize(7)
                .SetMarginLeft(25)
                .SetMarginBottom(5)
                .SetTextAlignment(TextAlignment.LEFT);


            observacionesTable.AddCell(new Cell()
                    .Add(new Paragraph(parametro.Observacion))
                    .SetFontSize(9)
                    .SetTextAlignment(TextAlignment.LEFT)
                );

            document.Add(pObservaciones);
            document.Add(observacionesTable);


            string footer = $"Usuario : {dataUsuario?.Usuario ?? ""}";

            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler(document, footer));

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
                detalleTable.AddCell(new Paragraph(item.Descripcion).SetFontSize(7));
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
