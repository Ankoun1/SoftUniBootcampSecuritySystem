using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.DefaultConstants;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.SkillConstants;

namespace SoftUniBootcampSecuritySystem.Models.Entity
{   
    public class Skill
    {       
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxLengthName)]
        public string Name { get; init; }

        public virtual IEnumerable<CandidateSkill> CandidateSkills { get; init; } = new List<CandidateSkill>();            
    }
}
