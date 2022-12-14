// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftUniBootcampSecuritySystem.Data;

namespace SoftUniBootcampSecuritySystem.Data.Migrations
{
    [DbContext(typeof(SecuritySystemDbContext))]
    partial class SecuritySystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.CandidateJobInterview", b =>
                {
                    b.Property<int>("RecruiterId")
                        .HasColumnType("int");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.HasKey("RecruiterId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("CandidateJobs");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.CandidateSkill", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("CandidatesSkills");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.JobRequirement", b =>
                {
                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.HasKey("JobId", "RequirementId");

                    b.HasIndex("RequirementId");

                    b.ToTable("JobsRequirements");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Recruiter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("FreeSeats")
                        .HasMaxLength(5)
                        .HasColumnType("tinyint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<short>("Level")
                        .HasColumnType("smallint");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.CandidateJobInterview", b =>
                {
                    b.HasOne("SoftUniBootcampSecuritySystem.Models.Entity.Job", "Job")
                        .WithMany("CandidateJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftUniBootcampSecuritySystem.Models.Entity.Recruiter", "Recruiter")
                        .WithMany("CandidateJobs")
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Recruiter");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.CandidateSkill", b =>
                {
                    b.HasOne("SoftUniBootcampSecuritySystem.Models.Entity.Skill", "Skill")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftUniBootcampSecuritySystem.Models.Entity.User", "Candidate")
                        .WithMany("CandidateSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.JobRequirement", b =>
                {
                    b.HasOne("SoftUniBootcampSecuritySystem.Models.Entity.Job", "Job")
                        .WithMany("JobSkills")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftUniBootcampSecuritySystem.Models.Entity.Requirement", "Requirement")
                        .WithMany("JobSkills")
                        .HasForeignKey("RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("Requirement");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Recruiter", b =>
                {
                    b.HasOne("SoftUniBootcampSecuritySystem.Models.Entity.User", "Candidate")
                        .WithOne("Recruiter")
                        .HasForeignKey("SoftUniBootcampSecuritySystem.Models.Entity.Recruiter", "UserId");

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Job", b =>
                {
                    b.Navigation("CandidateJobs");

                    b.Navigation("JobSkills");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Recruiter", b =>
                {
                    b.Navigation("CandidateJobs");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Requirement", b =>
                {
                    b.Navigation("JobSkills");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.Skill", b =>
                {
                    b.Navigation("CandidateSkills");
                });

            modelBuilder.Entity("SoftUniBootcampSecuritySystem.Models.Entity.User", b =>
                {
                    b.Navigation("CandidateSkills");

                    b.Navigation("Recruiter");
                });
#pragma warning restore 612, 618
        }
    }
}
