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

        private const string SEPARATOR = " - ";

        public ExportHelper(string exportFolder)
        {
            _exportFolder = exportFolder;
        }

        public StatusMessage ExportToPdf(Overview data)
        {
            StatusMessage result;

            if (data == null)
                return new StatusMessage(MSG_TYPE.WARNING, "El parámetro no puede ser nulo (ExportToPdf)");
            else
            {
                try
                {
                    var strTitle = data.Code + SEPARATOR + data.Name;

                    PdfDocument document = new PdfDocument();
                    document.Info.Title = strTitle;

                    // Create an empty page
                    PdfPage page = document.AddPage();

                    // Get an XGraphics object for drawing
                    XGraphics gfx = XGraphics.FromPdfPage(page);

                    // Create a font
                    XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

                    // Draw the text
                    gfx.DrawString(strTitle, font, XBrushes.Blue, new XRect(0, 26, page.Width, 26), XStringFormats.TopCenter);

                    XPen linePen = new XPen(XColors.Black, 2);
                    gfx.DrawLine(linePen, new XPoint(0, 60), new XPoint(page.Width, 60));

                    XFont fontInfo = new XFont("Verdana", 9, XFontStyle.BoldItalic);
                    gfx.DrawString("Asset type:", fontInfo, XBrushes.Black, new XRect(25, 60, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.AssetType, fontInfo, XBrushes.Blue, new XRect(100, 60, 150, 50), XStringFormats.CenterLeft);

                    gfx.DrawString("Exchange:", fontInfo, XBrushes.Black, new XRect(25, 80, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.Exchange, fontInfo, XBrushes.Blue, new XRect(100, 80, 150, 50), XStringFormats.CenterLeft);

                    gfx.DrawString("Currency:", fontInfo, XBrushes.Black, new XRect(25, 100, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.Currency, fontInfo, XBrushes.Blue, new XRect(100, 100, 150, 50), XStringFormats.CenterLeft);

                    gfx.DrawString("Country:", fontInfo, XBrushes.Black, new XRect(25, 120, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.Country, fontInfo, XBrushes.Blue, new XRect(100, 120, 150, 50), XStringFormats.CenterLeft);

                    gfx.DrawString("Sector:", fontInfo, XBrushes.Black, new XRect(25, 140, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.Sector, fontInfo, XBrushes.Blue, new XRect(100, 140, 150, 50), XStringFormats.CenterLeft);

                    gfx.DrawString("Industry:", fontInfo, XBrushes.Black, new XRect(25, 160, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.Industry, fontInfo, XBrushes.Blue, new XRect(100, 160, 150, 50), XStringFormats.CenterLeft);

                    gfx.DrawString("Employees:", fontInfo, XBrushes.Black, new XRect(25, 180, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.FullTimeEmployees, fontInfo, XBrushes.Blue, new XRect(100, 180, 150, 50), XStringFormats.CenterLeft);

                    gfx.DrawString("Description:", fontInfo, XBrushes.Black, new XRect(250, 60, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawLine(linePen, new XPoint(250, 95), new XPoint(590, 95));
                    gfx.DrawString(data.Description, fontInfo, XBrushes.Black, new XRect(250, 60, 350, 100), XStringFormats.CenterLeft);

                    linePen = new XPen(XColors.Black, 1);
                    gfx.DrawLine(linePen, new XPoint(0, page.Height - 35), new XPoint(page.Width, page.Height - 35));

                    gfx.DrawString("Address:", fontInfo, XBrushes.Black, new XRect(25, page.Height - 40, 150, 50), XStringFormats.CenterLeft);
                    gfx.DrawString(data.Address, fontInfo, XBrushes.Blue, new XRect(80, page.Height - 40, 530, 50), XStringFormats.CenterLeft);

                    // Save the document...
                    string fullPath = Path.Combine(_exportFolder, strTitle + ".pdf");

                    document.Save(fullPath);

                    result = new StatusMessage(MSG_TYPE.INFORMATION, "Exportación realizada correctamente");
                }
                catch (Exception error)
                {
                    // TODO Log error
                    result = new StatusMessage(MSG_TYPE.ERROR, error.Message);
                }
            }

            return result;
        }
    }
}
