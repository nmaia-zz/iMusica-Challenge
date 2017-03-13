using System.ComponentModel.DataAnnotations;

namespace Project.Entities.Enum
{
    public enum RoleType
    { 
        [Display(Name = "Business Analyst")]
        BusinessAnalyst = 1,

        [Display(Name = "System Analyst")]
        SystemAnalyst = 2,

        [Display(Name = "Project Manager")]
        ProjectManager = 3,

        [Display(Name = "IT Director")]
        ITDirector = 4,

        [Display(Name = "Human Resource")]
        HumanResource = 5
    }
}
