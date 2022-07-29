using System.Collections.Generic;
using SoftUniBootcampSecuritySystem.DTO.Import.Job;
using SoftUniBootcampSecuritySystem.DTO.Import.User;
using SoftUniBootcampSecuritySystem.Models.Entity;

namespace SoftUniBootcampSecuritySystem.BL.Jobs
{
    public interface IJobServices
    {
        int CreateNewJob(CreateJob job);

        void CreateJobRequirements(int jobId,List<string> requirements);

        void CreateRecruiterInterwiew(int jobId,List<string> jobRequirements, RegisterRecruiter recruiter);

        void CreateSlotInterwiew(int recruiterId,int jobId);

        bool ExistJob(int id);

        void RemoveJob(int id);
    }
}
