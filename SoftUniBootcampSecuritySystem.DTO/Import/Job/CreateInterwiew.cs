using System.ComponentModel.DataAnnotations;
using SoftUniBootcampSecuritySystem.DTO.Import.User;

namespace SoftUniBootcampSecuritySystem.DTO.Import.Job
{
    public class CreateInterwiew
    {
        [Required]
        public CreateJob Job { get; init; }

        [Required]
        public RegisterRecruiter Recruiter { get; init; }
    }
}
