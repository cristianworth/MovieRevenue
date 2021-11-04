using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Factory.MovieRevenue;
using MovieRevenue.Factory.Entity;
using MovieRevenue.Factory.DTO;
using NHibernate.Transform;

namespace MovieRevenue.Repository
{
    public class MovieRepository
    {


        public IList<Movie> GetAllMovies()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var query = session.QueryOver<Movie>();
                query.Left.JoinQueryOver(x => x.Studio);
                return query.List();
            }
        }

        public IList<MovieDTO> GetAllMoviesByYear(int year)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                string sql = @"
                    SELECT m.movie_id, m.title, m.year_release, m.revenue, s.name as studio_name
                    FROM Movie as m
                    LEFT JOIN Studio as s on (m.studio_id = s.studio_id)
                    WHERE year_release = :year";

                var query = session.CreateSQLQuery(sql);
                query.SetParameter("year", year);
                return query.SetResultTransformer(Transformers.AliasToBean<MovieDTO>()).List<MovieDTO>();
            }
        }
    }
}
