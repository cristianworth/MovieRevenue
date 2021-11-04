﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Factory.MovieRevenue;
using MovieRevenue.Factory.Entity;

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


    }
}
