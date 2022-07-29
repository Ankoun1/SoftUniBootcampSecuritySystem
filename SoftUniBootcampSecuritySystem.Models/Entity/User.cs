using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.UserConst;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;
using System;

namespace SoftUniBootcampSecuritySystem.Models.Entity
{ 
    public class User
    {        
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxLengthFullName)]
        public string FullName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }       

        [Required]
        [MaxLength(MaxLengthHashedPassword)]
        public string HashedPassword { get; set; }

        [Required]
        [MaxLength(MaxLengthSalt)]
        public string Salt { get; set; }       

        [Required]
        [MaxLength(BirthDateMaxLength)]
        public string BirthDate { get; init; }

        [Required]
        public string Biography { get; set; }      

        public Recruiter Recruiter { get; init; }

        public  virtual IEnumerable<CandidateSkill> CandidateSkills { get; init; } = new List<CandidateSkill>();        
    }
}
