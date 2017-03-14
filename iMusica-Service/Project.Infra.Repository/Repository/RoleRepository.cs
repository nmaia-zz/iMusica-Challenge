using NHibernate;
using NHibernate.Linq;
using Project.Entities;
using Project.Entities.Enum;
using Project.Infra.Util;
using System;
using System.Linq;

namespace Project.Infra.Repository
{
    public class RoleRepository : Repository<Role>
    {
        public Guid GetRoleIdByType(string roleType)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
               var result = s.Query<Role>().SingleOrDefault(r => r.RoleType == roleType);

                return result.Id;
            }
        }
    }
}
