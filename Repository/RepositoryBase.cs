using Factory.MovieRevenue;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRevenue.Repository
{
    public class RepositoryBase<T> where T: class
    {
        public void Create(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Error to Create:" + ex.Message);
                    }
                }
            }
        }

        public void Edit(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Error to Edit: " + ex.Message);
                    }
                }
            }
        }

        public void Delete(T entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Error to Delete: " + ex.Message);
                    }
                }
            }
        }

        public T GetById(int Id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<T>(Id);
            }
        }

        public IList<T> GetAll()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.QueryOver<T>().List();
            }
        }
    }
}
