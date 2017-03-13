using System;

namespace Project.Entities
{
    public class Dependent
    {
        #region ' Properties '

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Guid IdEmployee { get; set; }

        #endregion

        #region ' Relationships '

        public virtual Employee Employee { get; set; }

        #endregion

        #region ' Constructor '

        public Dependent()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
