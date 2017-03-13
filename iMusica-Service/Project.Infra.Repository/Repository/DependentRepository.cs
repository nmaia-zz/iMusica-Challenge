using NHibernate;
using NHibernate.Linq;
using Project.Entities;
using Project.Infra.Util;
using System;
using System.Linq;

namespace Project.Infra.Repository
{
    public class DependentRepository : Repository<Dependent>
    {
        public int QttyOfDependentsForEachEmployee(Guid id)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<Dependent>().Where(d => d.Employee.Id == id).Count();
            }
        }
    }
}
