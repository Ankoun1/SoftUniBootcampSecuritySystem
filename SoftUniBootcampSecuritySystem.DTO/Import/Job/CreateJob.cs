using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.JobConstants;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;
namespace SoftUniBootcampSecuritySystem.DTO.Import.Job
{
    public class CreateJob
    {
        [Required]
        [StringLength(MaxLengthTitle, MinimumLength = MinLengthTitle)]
        public string Title { get; init; }

        [Required]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription)]
        public string Description { get; init; }

        [Range(MinSalary,MaxSalary)]
        public decimal Salary { get; set; }

        [MinLength(MinCount)]
        public List<string> JobRequirements { get; init; }
    }
}
