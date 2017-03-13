using FluentNHibernate.Mapping;
using Project.Entities;

namespace Project.Infra.Mapping
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            #region ' Table Name '

            Table("Employee");

            #endregion

            #region ' Columns '

            Id(e => e.Id, "IdEmployee");

            Map(e => e.Name, "Name")
                .Length(100)
                .Not.Nullable();

            Map(e => e.Email, "Email")
                .Length(100)
                .Nullable();

            Map(e => e.BirthDate, "BirthDate")
                .Nullable();

            Map(e => e.Genre, "Genre")
                .Length(6)
                .Not.Nullable();

            #endregion

            #region ' Relationships '

            //HasMany(e => e.Dependents)
            //    .Inverse()
            //    .Cascade.All()
            //    .KeyColumn("Employee");

            //References(e => e.Role)
            //    .Column("Role");

            HasMany(e => e.Dependents)
                .KeyColumn("IdEmployee")
                .Inverse();

            References(e => e.Role)
                .Column("IdRole");

            #endregion
        }
    }
}
