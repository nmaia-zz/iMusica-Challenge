using System;
using System.Collections.Generic;
using Project.Infra.Repository.Contracts;
using NHibernate;
using Project.Infra.Util;
using NHibernate.Linq;
using System.Linq;

namespace Project.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public void Insert(TEntity obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Save(obj);
                t.Commit();
            }
        }

        public void Update(TEntity obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Update(obj);
                t.Commit();
            }
        }

        public void Delete(TEntity obj)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Delete(obj);
                t.Commit();
            }
        }

        public IList<TEntity> GetAll()
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<TEntity>().ToList();
            }
        }

        public TEntity GetById(Guid id)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Get<TEntity>(id);
            }
        }
    }
}
