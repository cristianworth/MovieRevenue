using FluentNHibernate.Mapping;
using MovieRevenue.Factory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRevenue.Factory.Mapping
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Table("Movie");
            Id(x => x.movie_id);
            Map(x => x.title);
            Map(x => x.year_release);
            Map(x => x.revenue);
            References(x => x.Studio).Column("studio_id");
        }
    }
}
