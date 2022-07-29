using Microsoft.EntityFrameworkCore;
using SoftUniBootcampSecuritySystem.Models.Entity;

namespace SoftUniBootcampSecuritySystem.Data
{
    public class SecuritySystemDbContext : DbContext
    {
        public SecuritySystemDbContext(DbContextOptions<SecuritySystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; init; }

        public DbSet<Recruiter> Recruiters { get; init; }

        public DbSet<Job> Jobs { get; init; }        

        public DbSet<CandidateJobInterview> CandidateJobs { get; init; }

        public DbSet<CandidateSkill> CandidatesSkills { get; init; }

        public DbSet<Skill> Skills { get; init; }

        public DbSet<Requirement> Requirements { get; init; }

        public DbSet<JobRequirement> JobsRequirements { get; init; }     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CandidateJobInterview>().HasKey(up => new { up.RecruiterId, up.JobId });
            builder.Entity<CandidateSkill>().HasKey(up => new { up.UserId, up.SkillId });
            builder.Entity<JobRequirement>().HasKey(up => new { up.JobId, up.RequirementId });

            base.OnModelCreating(builder);
        }
    }
}
