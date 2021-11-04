using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRevenue.Repository;
using MovieRevenue.Service;

namespace MovieRevenue.Service
{
    public class MovieService
    {
        private PdfService _pdfService = new PdfService();
        private ExcelService _excelService = new ExcelService();

        public void SaveMoviePdf(string filePath) {
            _pdfService.CreatePdfFile(filePath);
        }


        public void SaveMovieExcel(string filePath) {
            _excelService.CreateExcelFile(filePath);
        }

    }
}
