using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRevenue.Factory.DTO
{
    public class MovieDTO
    {
        public virtual int movie_id { get; set; }
        public virtual string title { get; set; }
        public virtual int year_release { get; set; }
        public virtual decimal revenue { get; set; }
        public virtual string studio_name { get; set; }
    }
}
