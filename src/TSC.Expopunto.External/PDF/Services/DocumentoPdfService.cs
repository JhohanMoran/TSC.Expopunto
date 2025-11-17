using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Text;
using TSC.Expopunto.Application.DataBase.GuiaEntrada.DTO;
using TSC.Expopunto.Application.DataBase.Parametro.Queries.Models;
using TSC.Expopunto.Application.DataBase.Persona.Queries.Models;
using TSC.Expopunto.Application.DataBase.Usuario.Queries.Models;
using TSC.Expopunto.Application.DataBase.Venta.DTO;
using TSC.Expopunto.Application.Interfaces.Services;
using TSC.Expopunto.Common;
using TSC.Expopunto.External.PDF.Handlers;

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
            var logo = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(path));
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
                    .SetFontSize(6)
                    .SetBold())
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    );
            }

            if (parametro.Detalles.Count() > 0)
            {
                foreach (var item in parametro.Detalles)
                {
                    detalleTable.AddCell(new Paragraph(item.CodProducto).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.Nombre).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.CodUniMed).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.NumCaja).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.Talla).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.CodigoEstilo).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(item.CodigoPedido).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
                    detalleTable.AddCell(new Paragraph(Convert.ToInt32(item.Cantidad).ToString()).SetFontSize(6).SetTextAlignment(TextAlignment.RIGHT));
                }

            }

            //Total
            var totalCantidad = parametro.Detalles.Sum(item => item.Cantidad);

            detalleTable.AddCell(new Paragraph("Total").SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(""));
            detalleTable.AddCell(new Paragraph(Convert.ToInt32(totalCantidad).ToString()).SetFontSize(6).SetTextAlignment(TextAlignment.RIGHT));

            document.Add(detalleTable);

            var pObservaciones = new Paragraph("Observaciones : ")
                .SetBold()
                .SetFontSize(6)
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


        public byte[] GenerarPdf(ImpresionVentaDTO parametro)
        {
            using var ms = new MemoryStream();
            using var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);

            // Ticket de 80mm de ancho (~226 puntos)
            var pageSize = new iText.Kernel.Geom.PageSize(226, 1000);
            var document = new Document(pdf, pageSize);
            document.SetMargins(10, 10, 10, 10);

            // ---- ENCABEZADO EMPRESA ----
            var empresa = new Paragraph(parametro.Empresa.NombreComercial)
                .SetBold().SetFontSize(8)
                .SetMultipliedLeading(1.15f)
                .SetTextAlignment(TextAlignment.CENTER);

            empresa.Add("\n" + parametro.Empresa.RazonSocial);
            empresa.Add("\n" + parametro.Empresa.Ruc);
            empresa.Add("\n" + parametro.Empresa.Direccion);
            
            document.Add(empresa);

            var direccionEmpresa = new Paragraph(parametro.Sede.Direccion)
                .SetFontSize(8)
                .SetMultipliedLeading(1.15f)
                .SetTextAlignment(TextAlignment.CENTER);
            document.Add(direccionEmpresa);

            // Línea superior
            document.Add(new Paragraph("----------------------------------------------------------------------")
                .SetMarginTop(0)
                .SetMarginBottom(0)
                .SetMultipliedLeading(1.5f)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(6));

            // ---- DATOS DEL COMPROBANTE ----
            var comprobante = new Paragraph($"{parametro.Venta.TipoComprobante} ELECTRÓNICA: {parametro.Venta.Serie}-{parametro.Venta.Numero}")
                .SetBold()
                .SetFontSize(8)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginTop(0)
                .SetMarginBottom(0)
                .SetMultipliedLeading(1.5f);

            document.Add(comprobante);

            // Línea inferior
            document.Add(new Paragraph("----------------------------------------------------------------------")
                .SetMarginTop(0)
                .SetMarginBottom(0)
                .SetMultipliedLeading(1.5f)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(6));

            document.Add(new Paragraph("\n").SetMargin(0));

            // ---- DATOS CLIENTE ----
            var cliente = new Paragraph()
            .Add(new Text("FECHA: ").SetBold()).Add(new Text($"{parametro.Venta.FechaDisplay} {parametro.Venta.Hora}\n"))
            .Add(new Text("DNI: ").SetBold()).Add(new Text($"{parametro.Venta.DocumentoPersona}\n"))
            .Add(new Text("NOMBRES: ").SetBold()).Add(new Text($"{parametro.Venta.NombrePersona}\n"))
            .Add(new Text("VENDEDOR: ").SetBold()).Add(new Text($"{parametro.Venta.NombreVendedor}\n"))
            .SetTextAlignment(TextAlignment.LEFT)
            .SetFontSize(7)
            .SetMargin(0)
            .SetMultipliedLeading(1.15f); // opcional, mejora la separación entre líneas

            document.Add(cliente);


            document.Add(new Paragraph("----------------------------------------------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(6));

            // ---- DETALLE DE PRODUCTOS ----
            var detalleTable = new Table(new float[] { 4, 1, 1, 1 }).UseAllAvailableWidth();

            detalleTable.AddHeaderCell(new Paragraph("DESCRIPCIÓN").SetFontSize(6).SetBold());
            detalleTable.AddHeaderCell(new Paragraph("CANT").SetFontSize(6).SetBold());
            detalleTable.AddHeaderCell(new Paragraph("PRECIO").SetFontSize(6).SetBold());
            detalleTable.AddHeaderCell(new Paragraph("TOTAL").SetFontSize(6).SetBold());

            foreach (var item in parametro.Venta.Detalles)
            {
                detalleTable.AddCell(new Paragraph(item.Descripcion).SetFontSize(6));
                detalleTable.AddCell(new Paragraph(item.Cantidad.ToString()).SetFontSize(6));
                detalleTable.AddCell(new Paragraph(item.PrecioUnitario.ToString("0.00")).SetFontSize(6));
                detalleTable.AddCell(new Paragraph(item.SubTotal.ToString("0.00")).SetFontSize(6));
            }

            document.Add(detalleTable);

            document.Add(new Paragraph("----------------------------------------------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(6));

            // ---- TOTALES ----
            var totalesTable = new Table(new float[] { 3, 1 }).UseAllAvailableWidth(); // 3:1 da más espacio al texto

            totalesTable.SetFontSize(7);

            // Agregamos una fila con las unidades totales
            totalesTable.AddCell(new Cell(1, 2)
                .Add(new Paragraph($"{parametro.Venta.Cantidad} Unid(s)").SetBold())
                .SetBorder(Border.NO_BORDER));

            // Agregar las filas de totales con alineación
            void AddTotalRow(string label, decimal monto, bool bold = false)
            {
                var leftParagraph = new Paragraph(label)
                    .SetMargin(0)
                    .SetMultipliedLeading(1.15f); // reduce espacio vertical

                var rightParagraph = new Paragraph($"{parametro.Venta.SimboloMoneda}{monto:0.00}")
                    .SetMargin(0)
                    .SetMultipliedLeading(1.15f)
                    .SetTextAlignment(TextAlignment.RIGHT);

                var leftCell = new Cell().Add(leftParagraph)
                    .SetBorder(Border.NO_BORDER)
                    .SetPadding(0)
                    .SetTextAlignment(TextAlignment.LEFT);

                var rightCell = new Cell().Add(rightParagraph)
                    .SetBorder(Border.NO_BORDER)
                    .SetPadding(0)
                    .SetTextAlignment(TextAlignment.RIGHT);

                if (bold)
                {
                    leftCell.SetBold();
                    rightCell.SetBold();
                }

                totalesTable.AddCell(leftCell);
                totalesTable.AddCell(rightCell);
            }

            // Agregamos cada línea
            AddTotalRow("OP.GRAVADAS", parametro.Venta.OpGravadas ?? 0);
            AddTotalRow("OP.EXONERADAS", parametro.Venta.OpExoneradas ?? 0);
            AddTotalRow("OP.INAFECTAS", parametro.Venta.OpInafectas ?? 0);
            AddTotalRow("TOTAL DESCUENTO", parametro.Venta.TotalDescuento ?? 0);
            AddTotalRow("OP.GRATUITAS", parametro.Venta.OpGratuitas ?? 0);
            AddTotalRow($"I.G.V {parametro.Venta.IGV}",parametro.Venta.TotalIGV ?? 0);
            AddTotalRow("TOTAL ICBPER", parametro.Venta.TotalICBPER ?? 0);
            AddTotalRow("IMPORTE TOTAL", parametro.Venta.ImporteTotal ?? 0, true); // en negrita

            document.Add(totalesTable);

            document.Add(new Paragraph("-----------------------------------------------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(6));

            // ---- MONTO EN LETRAS ----
            document.Add(new Paragraph($"Son: {Util.ConvertirMontoEnLetras(parametro.Venta.ImporteTotal ?? 0)} {parametro.TipoMoneda.NombrePlural}" )
                .SetFontSize(8)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph("-----------------------------------------------------------------------")
                .SetTextAlignment(TextAlignment.CENTER).SetFontSize(6));

            // ---- MÉTODOS DE PAGO ----
            document.Add(new Paragraph("MÉTODOS DE PAGO:")
                .SetBold().SetFontSize(7));

            if (parametro.Venta.FormasPago?.Any() == true)
            {
                var textoPagos = new StringBuilder();

                foreach (var pago in parametro.Venta.FormasPago)
                {
                    if (pago.Monto > 0)
                    {
                        textoPagos.AppendLine($"{pago.FormaPago}: {parametro.Venta.SimboloMoneda}{pago.Monto:0.00}");
                    }
                }

                if (textoPagos.Length > 0)
                {
                    var pagosParagraph = new Paragraph(textoPagos.ToString())
                        .SetFontSize(7)
                        .SetMargin(0)
                        .SetMultipliedLeading(1.15f) // reduce el interlineado
                        .SetTextAlignment(TextAlignment.LEFT);

                    document.Add(pagosParagraph);
                }
            }
            else
            {
                document.Add(new Paragraph($"EFECTIVO: {parametro.Venta.SimboloMoneda}0.00").SetFontSize(8));
            }

            document.Add(new Paragraph("\n").SetMargin(0));

            document.Add(new Paragraph("\nObservaciones o comentarios:")
                .SetBold().SetFontSize(7)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph("****** NO SE ACEPTAN CAMBIOS NI DEVOLUCIONES ******")
                .SetFontSize(7)
                .SetMarginTop(0)
                .SetMarginBottom(0)
                .SetMultipliedLeading(1.5f)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph("\n").SetMargin(0));

            // ---- QR DE SUNAT ----
            byte[] qrBytes = QrHelper.Generar(parametro.qrData);

            var qrImage = new iText.Layout.Element.Image(
                    ImageDataFactory.Create(qrBytes))
                .SetWidth(80)
                .SetHeight(80)
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            document.Add(qrImage);

            document.Add(new Paragraph("\n").SetMargin(0));

            var pieComprobante = new Paragraph()
            .Add(new Text($"Representación Impresa de la {parametro.Venta.TipoComprobante} DE VENTA ELECTRÓNICA\n"))
            .Add(new Text("Podrá ser consultado en: factura.ecomprobante.pe/tsc\n"))
            .Add(new Text("MUCHAS GRACIAS POR SU COMPRA\n"))
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(6)
            .SetMargin(0)
            .SetMultipliedLeading(1.15f); // opcional, mejora la separación entre líneas

            document.Add(pieComprobante);

            document.Close();
            return ms.ToArray();
        }
    }
}
