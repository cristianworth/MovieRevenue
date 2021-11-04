using FluentNHibernate.Mapping;
using MovieRevenue.Factory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRevenue.Factory.Mapping
{
    public class StudioMap : ClassMap<Studio>
    {
        public StudioMap()
        {
            Table("studio");
            Id(x => x.studio_id);
            Map(x => x.name);
        }
    }
}
