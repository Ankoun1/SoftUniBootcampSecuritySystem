using System;
using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.JobConstants;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;
using System.Collections.Generic;

namespace SoftUniBootcampSecuritySystem.Models.Entity
{   
    public class Job
    {        
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxLengthTitle)]
        public string Title { get; init; } 

        [Required]
        [MaxLength(MaxLengthDescription)]
        public string Description { get; init; }

        public decimal Salary { get; set; }

        public virtual IEnumerable<JobRequirement> JobSkills { get; init; } = new List<JobRequirement>();

        public virtual IEnumerable<CandidateJobInterview> CandidateJobs { get; init; } = new List<CandidateJobInterview>();
    }
}
