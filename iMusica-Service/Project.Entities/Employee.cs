using Project.Entities.Enum;
using System;
using System.Collections.Generic;

namespace Project.Entities
{
    public class Employee
    {
        #region ' Properties '

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Guid IdRole { get; set; }
        #endregion

        #region ' Relationships '

        public virtual Role Role { get; set; }
        public virtual IList<Dependent> Dependents  { get; set; }

        #endregion

        #region ' Constructor '

        public Employee()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
