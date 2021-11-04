using System;
using ClosedXML.Excel;
using MovieRevenue.Repository;

namespace MovieRevenue.Service
{
    public class ExcelService
    {
        private MovieRepository _movieRepository = new MovieRepository();
        private static XLWorkbook wbook = new XLWorkbook();
        private static IXLWorksheet ws = wbook.Worksheets.Add("Movies");
        public void CreateExcelFile(string filePath)
        {
            try
            {
                BuildSheetHeader();
                BuildSheetBody();
                wbook.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void BuildSheetHeader()
        {
            ws.Cell("A1").Value = "MOVIE";
            ws.Cell("B1").Value = "STUDIO";
            ws.Cell("C1").Value = "REVENUE";
            ws.Column("C").Style.NumberFormat.Format = "$#,##0";
            ws.Cell("D1").Value = "YEAR";

            var header = ws.Range("A1:D1");
            header.Style.Font.Bold = true;
            header.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            header.Style.Fill.SetBackgroundColor(XLColor.LightGray);

            ws.Columns("A,B").Width = 30;
            ws.Column("C").Width = 15;
        }

        public void BuildSheetBody()
        {
            var data = _movieRepository.GetAllMovies();
            int row = ws.LastRowUsed().RowNumber() + 1;
            foreach (var item in data)
            {
                ws.Cell(row, 1).SetValue(item.title);
                ws.Cell(row, 2).SetValue(item.Studio.name);
                ws.Cell(row, 3).SetValue(item.revenue);
                ws.Cell(row, 4).SetValue(item.year_release);
                row++;
            }
        }
    }
}
