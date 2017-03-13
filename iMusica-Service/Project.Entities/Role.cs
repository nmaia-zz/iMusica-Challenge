using Project.Entities.Enum;
using System;
using System.Collections.Generic;

namespace Project.Entities
{
    public class Role
    {
        #region ' Properties '

        public virtual Guid Id { get; set; }
        public virtual RoleType RoleType { get; set; }
        public virtual Guid IdEmployee { get; set; }

        #endregion

        #region ' Relationships '

        public virtual IList<Employee> Employees { get; set; }

        #endregion

        #region ' Constructor '

        public Role()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
