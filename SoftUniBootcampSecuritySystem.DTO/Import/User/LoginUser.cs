using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.UserConst;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;

namespace SoftUniBootcampSecuritySystem.DTO.Import.User
{
    public class LoginUser
    {
        [Required]
        [StringLength(MaxLengthFullName, MinimumLength = MinLengthFullName)]
        public string FullName { get; set; }

        [Required]
        [StringLength(MaxLengthPassword, MinimumLength = MinLengthPassword)]
        public string Password { get; set; }
    }
}
