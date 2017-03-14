using FluentNHibernate.Mapping;
using Project.Entities;

namespace Project.Infra.Mapping
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            #region ' Table '

            Table("Role");

            #endregion

            #region ' Columns '

            Id(r => r.Id, "IdRole");

            Map(r => r.RoleType, "RoleType")
                .Length(16)
                .Not.Nullable();

            #endregion
        }
    }
}
