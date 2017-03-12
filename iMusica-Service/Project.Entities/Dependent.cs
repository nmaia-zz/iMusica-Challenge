using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Dependent
    {
        #region ' Properties '

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }

        #endregion

        #region ' Constructor '

        public Dependent()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
