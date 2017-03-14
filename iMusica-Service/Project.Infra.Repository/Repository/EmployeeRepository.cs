using NHibernate;
using NHibernate.Linq;
using Project.Entities;
using Project.Infra.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Infra.Repository
{
    public class EmployeeRepository : Repository<Employee>
    {
        public IList<Employee> GetEmployeesByName(string name)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<Employee>().Where(e => e.Name.Contains(name)).ToList();
            }
        }
    }
}
