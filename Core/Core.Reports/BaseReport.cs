using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using SAM.Core.Business;
using SAM.Core.DataDb;
using SAM.Databases.DbSam.Core.Data.Context;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Principal;

namespace SAM.Core.Reports
{
    public class BaseReport : IBaseReport
    {
        public byte[] CreateReport()
        {
            try
            {
                var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
                string path = $"D:\\ReportsTest\\prueba{DateTime.Now.ToString("yyyyMMddmmss")}.pdf";
                PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
                pdfDoc.Open();

                var imagePath = $"D:\\ReportsTest\\logo mum.gif";
                using (FileStream fs = new FileStream(imagePath, FileMode.Open))
                {
                    var png = Image.GetInstance(System.Drawing.Image.FromStream(fs), ImageFormat.Jpeg);
                    png.SetAbsolutePosition(pdfDoc.PageSize.Width - 36f - 90f, pdfDoc.PageSize.Height + 100f - 216.6f);
                    png.ScaleAbsolute(100f, 100f);
                    pdfDoc.Add(png);
                }

                Paragraph title = new Paragraph();
                title.Alignment = Element.ALIGN_CENTER;
                title.Font = FontFactory.GetFont("Arial", 17);
                title.Add("\n Reporte de Mochilas y Agendas entregadas\n");
                pdfDoc.Add(title);

                var spacer = new Paragraph(string.Empty)
                {
                    SpacingBefore = 10f,
                    SpacingAfter = 10f
                };
                pdfDoc.Add(spacer);



                var headerTable = new PdfPTable(new[] { .75f, 2f })
                {
                    HorizontalAlignment = 0,
                    WidthPercentage = 75,
                    DefaultCell = { MinimumHeight = 22f }
                };

                headerTable.AddCell("Date");
                headerTable.AddCell(DateTime.Now.ToString());
                headerTable.AddCell("Nombre");
                headerTable.AddCell("Prueba de nombre");

                pdfDoc.Add(headerTable);
                pdfDoc.Add(spacer);

                var columnCount = 10;
                var columnWidths = new[] { 0.75f, 1f, 1.5f, 1f, 1f, 1f, 1f, 1f };
                var table = new PdfPTable(columnWidths)
                {
                    HorizontalAlignment = 0,
                    WidthPercentage = 100,
                    DefaultCell = { MinimumHeight = 22f }
                };

                var cell = new PdfPCell(new Phrase("Part Summary"))
                {
                    Colspan = columnCount,
                    HorizontalAlignment = 0,
                    MinimumHeight = 30f
                };
                table.AddCell(cell);

                pdfDoc.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
