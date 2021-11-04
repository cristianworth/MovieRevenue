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
            PdfPTable header = new PdfPTable(4);
            header.WidthPercentage = 100;

            string[] columns = { "MOVIE", "STUDIO", "REVENUE", "YEAR" };
            foreach (var c in columns) {
                var column = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.BOX };
                column.AddElement(new Paragraph(c, fontBold));
                header.AddCell(column);
            }

            return header;
        }

        public PdfPTable PdfBody() {
            PdfPTable body = new PdfPTable(4);
            body.WidthPercentage = 100;

            var movies = _movieRepository.GetAllMovies();
            foreach (var m in movies) {
                var titleColumn = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                titleColumn.AddElement(new Paragraph(m.title, font));
                body.AddCell(titleColumn);

                var studioColumn = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                studioColumn.AddElement(new Paragraph(m.Studio.name, font));
                body.AddCell(studioColumn);

                var revenueColumn = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                revenueColumn.AddElement(new Paragraph(m.revenue.ToString("n2"), font));
                body.AddCell(revenueColumn);

                var yearColumn = new PdfPCell() { Colspan = 1, VerticalAlignment = Element.ALIGN_LEFT, Border = Rectangle.NO_BORDER };
                yearColumn.AddElement(new Paragraph(m.year_release.ToString(), font));
                body.AddCell(yearColumn);
            }

            return body;
        }
    }
}
