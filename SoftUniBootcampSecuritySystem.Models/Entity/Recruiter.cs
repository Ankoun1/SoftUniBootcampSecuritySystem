using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.RecruiterConstants;

namespace SoftUniBootcampSecuritySystem.Models.Entity
{   
    public class Recruiter
    {        
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxLengthFullName)]
        public string FullName { get; init; }

        [Required]        
        public string Email { get; init; }

        [Required]
        [MaxLength(MaxLengthHashedPassword)]
        public string HashedPassword { get; set; }

        [Required]
        [MaxLength(MaxLengthSalt)]
        public string Salt { get; set; }

        [Required]
        [MaxLength(MaxLengthCountryName)]
        public string Country { get; init; }

        [MaxLength(RecruiterFreeSeats)]
        public byte FreeSeats { get; set; }

        public short Level { get; set; }        
        
        public int? UserId { get; set; }

        public User Candidate { get; set; }

        public virtual IEnumerable<CandidateJobInterview> CandidateJobs { get; init; } = new List<CandidateJobInterview>(RecruiterFreeSeats);
    }
}
