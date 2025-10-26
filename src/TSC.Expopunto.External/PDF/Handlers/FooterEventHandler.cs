using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace TSC.Expopunto.External.PDF.Handlers
{
    public class FooterEventHandler : IEventHandler
    {
        private readonly Document _document;
        private readonly string _footer;
        public FooterEventHandler(Document document, string footer)
        {
            this._document = document;
            this._footer = footer;
        }

        public void HandleEvent(Event currentEvent)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
            PdfPage page = docEvent.GetPage();
            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), docEvent.GetDocument());
            Canvas canvas = new Canvas(pdfCanvas, _document.GetPageEffectiveArea(PageSize.A4));

            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // Crear el texto del pie
            Paragraph footer = new Paragraph($"{this._footer}  | Fecha actual {fechaActual} | Página {docEvent.GetDocument().GetPageNumber(page)}")
                .SetFontSize(9)
                .SetTextAlignment(TextAlignment.CENTER);

            // Dibujar en la parte inferior
            canvas
                .ShowTextAligned(footer,
                    _document.GetPageEffectiveArea(PageSize.A4).GetWidth() / 2,
                    20, // posición Y desde el borde inferior
                    TextAlignment.CENTER);

            canvas.Close();
        }
    }
}
