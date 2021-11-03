using NHibernate;
using System;

namespace MovieRevenue
{
    class Program
    {
        static void Main(string[] args)
        {


            using (ISession session = SessionFactory.OpenSession()) {
                var data = session.QueryOver<Factory.Entity.Movie>().List();
                foreach (var item in data) {
                    /*Show All movie titles in database*/
                    Console.WriteLine(item.title);
                }
            }


        }
    }
}
