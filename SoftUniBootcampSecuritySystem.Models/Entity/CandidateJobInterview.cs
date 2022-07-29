using System.ComponentModel.DataAnnotations;

namespace SoftUniBootcampSecuritySystem.Models.Entity
{   
    public class CandidateJobInterview
    {       
        public int JobId { get; init; }

        public Job Job { get; init; }
        
        public int RecruiterId { get; init; }

        public Recruiter Recruiter { get; init; }
    }
}
