using Project.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Role
    {
        #region ' Properties '

        public virtual Guid Id { get; set; }
        public virtual RoleType RoleType { get; set; }

        #endregion

        #region ' Constructor '

        public Role()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
