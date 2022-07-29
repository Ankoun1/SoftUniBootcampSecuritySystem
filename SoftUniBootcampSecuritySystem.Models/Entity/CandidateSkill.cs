using System.ComponentModel.DataAnnotations;

namespace SoftUniBootcampSecuritySystem.Models.Entity
{    
    public class CandidateSkill
    {        
        public int UserId { get; init; }

        public  User Candidate { get; init; }        
       
        public int SkillId { get; init; }

        public  Skill Skill { get; init; }
    }
}
