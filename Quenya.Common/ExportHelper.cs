using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Quenya.Common.interfaces;
using Quenya.Domain;
using System;
using System.IO;

namespace Quenya.Common
{
    public class ExportHelper : IExportHelper
    {
        private string _exportFolder = string.Empty;

        public ExportHelper(string exportFolder)
        {
            _exportFolder = exportFolder;
        }

        public StatusMessage ExportToPdf(Overview data)
        {
            var result = new StatusMessage();

            if (data == null)
                return new StatusMessage(MSG_TYPE.WARNING, "El parámetro no puede ser nulo (ExportToPdf)");
            else
            {
                try
                {
                    PdfDocument document = new PdfDocument();
                    document.Info.Title = "Created with PDFsharp";

                    // Create an empty page
                    PdfPage page = document.AddPage();
                    // Get an XGraphics object for drawing
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Create a font
                    XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

                    // Draw the text
                    gfx.DrawString("Hello, World!", font, XBrushes.Black,
                    new XRect(0, 0, page.Width, page.Height),
                    XStringFormats.Center);

                    // Save the document...
                    const string filename = "Export example.pdf";
                    string fullPath = Path.Combine(_exportFolder, filename);

                    document.Save(fullPath);

                    result = new StatusMessage(MSG_TYPE.INFORMATION, "Exportación realizada correctamente");
                }
                catch (Exception error)
                {
                    // TOTO Log error
                    result = new StatusMessage(MSG_TYPE.ERROR, error.Message);
                }
            }

            return result;
        }
    }
}
