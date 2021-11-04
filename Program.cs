using Factory.MovieRevenue;
using MovieRevenue.Service;
using NHibernate;
using System;
using System.IO;

namespace MovieRevenue
{
    class Program
    {
        private static MovieService _movieService = new MovieService();
        static void Main(string[] args)
        {


            _movieService.SaveMoviePdf(@"C:\AALLL\MoviesRevenue.pdf");
            _movieService.SaveMovieExcel(@"C:\AALLL\MoviesRevenue.xlsx");


        }
    }
}
