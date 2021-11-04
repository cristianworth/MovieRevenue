using iTextSharp.text;
using iTextSharp.text.pdf;
using MovieRevenue.Repository;
using System.IO;

namespace MovieRevenue.Service
{
    public class PdfService
    {
        private MovieRepository _movieRepository = new MovieRepository();
        private Font font = new Font(Font.NORMAL, 8, (int)System.Drawing.FontStyle.Regular);
        private Font fontBold = new Font(Font.NORMAL, 8, (int)System.Drawing.FontStyle.Bold);

        public void CreatePdfFile(string filePath)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

            doc.Open();
            doc.Add(PdfHeader());
            doc.Add(PdfBody());
            doc.Close();
        }

        public PdfPTable PdfHeader()
        {
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;

            string[] columns = { "MOVIE", "STUDIO", "REVENUE", "YEAR" };
            foreach (var c in columns) {
                var column = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.BOX };
                column.AddElement(new Paragraph(c, fontBold));
                table.AddCell(column);
            }

            return table;
        }

        public PdfPTable PdfBody() {
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;

            var data = _movieRepository.GetAllMovies();
            foreach (var d in data) {
                var column1 = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                column1.AddElement(new Paragraph(d.title, font));
                table.AddCell(column1);

                var column2 = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                column2.AddElement(new Paragraph(d.Studio.name, font));
                table.AddCell(column2);

                var column3 = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                column3.AddElement(new Paragraph(d.revenue.ToString("n2"), font));
                table.AddCell(column3);

                var column4 = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                column4.AddElement(new Paragraph(d.year_release.ToString(), font));
                table.AddCell(column4);
            }

            return table;
        }
    }
}
