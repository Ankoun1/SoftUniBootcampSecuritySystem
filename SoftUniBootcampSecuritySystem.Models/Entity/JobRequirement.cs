using System.ComponentModel.DataAnnotations;

namespace SoftUniBootcampSecuritySystem.Models.Entity
{   
    public class JobRequirement
    {       
        public int JobId { get; init; }

        public Job Job{ get; init; }
       
        public int RequirementId { get; init; }

        public Requirement Requirement { get; init; }
    }
}
