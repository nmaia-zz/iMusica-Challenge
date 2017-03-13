using FluentNHibernate.Mapping;
using Project.Entities;

namespace Project.Infra.Mapping
{
    public class DependentMap : ClassMap<Dependent>
    {
        public DependentMap()
        {
            #region ' Table '

            Table("Dependent");

            #endregion

            #region ' Columns '

            Id(e => e.Id, "IdEmployee");

            Map(e => e.Name, "Name")
                .Length(100)
                .Not.Nullable();

            #endregion

            #region ' Relationships '

            //References(d => d.Employee)
            //    .Column("Employee");

            References(d => d.Employee)
                .Column("IdEmployee");

            #endregion
        }
    }
}
