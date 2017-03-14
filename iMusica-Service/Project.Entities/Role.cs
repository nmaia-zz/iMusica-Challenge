using System;

namespace Project.Entities
{
    public class Role
    {
        #region ' Properties '

        public virtual Guid Id { get; set; }
        public virtual string RoleType { get; set; }

        #endregion

        #region ' Constructor '

        public Role()
        {

        }

        #endregion
    }
}
