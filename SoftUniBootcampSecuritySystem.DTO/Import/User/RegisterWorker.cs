using System.ComponentModel.DataAnnotations;

namespace SoftUniBootcampSecuritySystem.DTO.Import.User
{
    public class RegisterWorker
    {
        [Required]
        public RegisterUser User { get; init; }

        [Required]
        public RegisterRecruiter Recruiter { get; init; }
    }
}
