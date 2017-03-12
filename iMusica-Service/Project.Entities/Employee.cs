using Project.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Employee
    {
        #region ' Properties '

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual Genre Genre { get; set; }

        #endregion

        #region ' Relationships '

        public virtual Role Role { get; set; }
        public virtual IEnumerable<Dependent> Dependents  { get; set; }

        #endregion

        #region ' Constructor '

        public Employee()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}
