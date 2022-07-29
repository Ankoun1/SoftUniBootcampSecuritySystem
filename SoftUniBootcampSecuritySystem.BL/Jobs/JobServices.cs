using System.Collections.Generic;
using System.Linq;
using SoftUniBootcampSecuritySystem.BL.Users;
using SoftUniBootcampSecuritySystem.Data;
using SoftUniBootcampSecuritySystem.DTO.Import.Job;
using SoftUniBootcampSecuritySystem.DTO.Import.User;
using SoftUniBootcampSecuritySystem.Models.Entity;

namespace SoftUniBootcampSecuritySystem.BL.Jobs
{
    public class JobServices : IJobServices
    {
        private readonly SecuritySystemDbContext data;
        private readonly IUserServices userServices;

        public JobServices(SecuritySystemDbContext data, IUserServices userServices)
        {
            this.data = data;            
            this.userServices = userServices;            
        }

        public void CreateJobRequirements(int jobId, List<string> requirements)
        {
            foreach(var requirement in requirements)
            {
                if(!data.Requirements.Any(x => x.Name == requirement))
                {
                    data.Requirements.Add(new Requirement { Name = requirement });
                    data.SaveChanges();
                }
                data.JobsRequirements.Add(new JobRequirement { JobId = jobId, RequirementId = data.Requirements.Where(x => x.Name == requirement).Select(x => x.Id).FirstOrDefault() });
                data.SaveChanges();
            }
        }

        public int CreateNewJob(CreateJob jobDto)
        {
            var job = new Job { Title = jobDto.Title, Description = jobDto.Description, Salary = jobDto.Salary };
            data.Jobs.Add(job);
            data.SaveChanges();
            CreateJobRequirements(job.Id, jobDto.JobRequirements);
            return job.Id;
        }

        public void CreateRecruiterInterwiew(int jobId,List<string> jobRequirements, RegisterRecruiter recruiterDto)
        {
            bool existRecruiter = false;
            foreach(var requirement in jobRequirements)
            {
                var recruiter = data.Recruiters.Where(x => x.Candidate.CandidateSkills.Any(y => y.Skill.Name == requirement) && x.FreeSeats < 5).FirstOrDefault();
                if (recruiter != null)
                {
                    recruiter.FreeSeats += 1;
                    recruiter.Level += 1;
                    CreateSlotInterwiew(recruiter.Id, jobId);
                    data.SaveChanges();
                    existRecruiter = true;
                }
            }

            if (!existRecruiter)
            {
                int recruiterId = userServices.NewRegistrationRecruiter(recruiterDto, null);
                CreateSlotInterwiew(recruiterId, jobId);
            }
        }

        public void CreateSlotInterwiew(int recruiterId, int jobId)
        {
            data.CandidateJobs.Add(new CandidateJobInterview { RecruiterId = recruiterId, JobId = jobId });
            data.SaveChanges();
        }

        public bool ExistJob(int id)
        {
            return data.Jobs.Any(x => x.Id == id);
        }

        public void RemoveJob(int id)
        {
            UpdateRecruiterData(id);
            var job = data.Jobs.Find(id);
            data.Jobs.Remove(job);
            data.SaveChanges();
        }

        private void UpdateRecruiterData(int id)
        {
            foreach (var recruiterId in data.CandidateJobs.Where(x => x.JobId == id).Select(x => x.RecruiterId).ToArray())
            {
                var recruiter = data.Recruiters.Where(x => x.Id == recruiterId).FirstOrDefault();
                recruiter.FreeSeats -= 1;
                data.SaveChanges();
            }
        }
    }
}
