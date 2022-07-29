using System;
using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.UserConst;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;
using System.Collections.Generic;

namespace SoftUniBootcampSecuritySystem.DTO.Import.User
{
    public class RegisterUser
    {
        [Required]
        [StringLength(MaxLengthFullName, MinimumLength = MinLengthFullName)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(MaxLengthPassword, MinimumLength = MinLengthPassword)]
        public string Password { get; set; }

        [Required]
        [MaxLength(BirthDateMaxLength)]
        public string BirthDate { get; init; }

        [Required]
        public string Biography { get; set; }

        [MinLength(MinCount)]
        public List<string> Skills { get; set; }       
        
    }
}
