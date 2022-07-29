using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.RecruiterConstants;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;

namespace SoftUniBootcampSecuritySystem.DTO.Import.User
{
    public class RegisterRecruiter
    {
        [Required]
        [StringLength(MaxLengthFullName, MinimumLength = MinLengthFullName)]
        public string FullName { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        [StringLength(MaxLengthPassword, MinimumLength = MinLengthPassword)]
        public string Password { get; set; }

        [Required]
        [MaxLength(MaxLengthCountryName)]
        [StringLength(MaxLengthCountryName, MinimumLength = MinLengthCountryName)]
        public string Country { get; init; }
    }
}
