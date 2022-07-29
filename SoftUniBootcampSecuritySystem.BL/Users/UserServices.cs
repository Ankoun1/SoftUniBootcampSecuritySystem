using System;
using System.Collections.Generic;
using System.Linq;
using SoftUniBootcampSecuritySystem.Data;
using SoftUniBootcampSecuritySystem.DTO.Export;
using SoftUniBootcampSecuritySystem.DTO.Import.User;
using SoftUniBootcampSecuritySystem.Models.Entity;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.AdminRepository;
using static SoftUniBootcampSecuritySystem.Models.DataConstants.UserConst;

namespace SoftUniBootcampSecuritySystem.BL.Users
{
    public class UserServices : IUserServices
    {
        private readonly SecuritySystemDbContext data;       
        private readonly IPasswordHandler passwordHandler;                   

        public UserServices(SecuritySystemDbContext data,IPasswordHandler passwordHandler)
        {
            this.data = data;
            this.passwordHandler = passwordHandler;            
        }

        public void CreateSkillsUser(List<string> skills,int userId)
        {
            foreach (var skill in skills)
            {
                if (!data.Skills.Any(x => x.Name == skill))
                {
                    data.Skills.Add(new Skill { Name = skill });
                    data.SaveChanges();
                }
                var skillId = data.Skills.Where(x => x.Name == skill).Select(x => x.Id).FirstOrDefault();
                data.CandidatesSkills.Add(new CandidateSkill { UserId = userId, SkillId = skillId });
                data.SaveChanges();
            }
        }

        public bool ExistingUser(string fullname, string password)
        {
            /*
            if (data.Users.Any())
            {
               return data.Users.Any(x => x.FullName == fullname && x.HashedPassword != null && passwordHandler.PasswordChecker(x.HashedPassword, x.Salt) == password);
            }
            return false;
            */

            foreach (var user in data.Users.Select(x => new { FullName = x.FullName, HashedPassword = x.HashedPassword, Salt = x.Salt }).ToList())
            {
                var userPassword = passwordHandler.PasswordChecker(user.HashedPassword, user.Salt);
                if (user.FullName == fullname && userPassword == password)
                {
                    return true;
                }
            }
            return false;
        }
       

        public (string Name,string Role) Get(LoginUser userDto)
        {
            string name = AdminName;
            string identificator = AdminIdentificator;
            if (userDto.FullName != name || userDto.Password != passwordHandler.PasswordChecker(AdminPassword,AdminSalt))
            {
                name = null;
                foreach(var user in data.Users)
                {
                    var password = passwordHandler.PasswordChecker(user.HashedPassword, user.Salt);
                        
                    if (user.FullName == userDto.FullName && password == userDto.Password)
                    {
                        name = user.FullName;
                    }
                }                                                           
                
                identificator = UserIdentificator;
            }
            return (name,identificator);
        }

        public int NewRegistrationRecruiter(RegisterRecruiter recruiterDto, int? userId)
        {
            var salt = Guid.NewGuid().ToString();
            var hashedParams = passwordHandler.GeneratorPassword(salt, recruiterDto.Password);
            var recruiter = new Recruiter
            {
                FullName = recruiterDto.FullName,
                Email = recruiterDto.FullName,
                HashedPassword = hashedParams.password,
                Salt = hashedParams.salt,
                Country = recruiterDto.Country,
                Level = 1,
                UserId = userId
            };
            data.Recruiters.Add(recruiter);
            data.SaveChanges();
            return recruiter.Id;
           
        }

        public bool CheckRecruiterInterwiewExsist(int userId, List<string> skillsUser)
        {
            bool recruiterExist = false;
            foreach (var skill in skillsUser)
            {
               var  recruiter = data.Recruiters.Where(x => x.UserId == null && x.CandidateJobs.Any(y => y.RecruiterId == x.Id && y.Job.JobSkills.Any(z => z.Requirement.Name == skill))).FirstOrDefault();
                if (recruiter != null)
                {
                    recruiter.UserId = userId;
                    data.SaveChanges();
                    recruiterExist = true;
                    break;
                }
            }
            return recruiterExist;
        }

        public int NewRegistrationUser(RegisterUser userDto)
        {
            var salt = Guid.NewGuid().ToString();
            var hashedParams = passwordHandler.GeneratorPassword(salt, userDto.Password);
            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                HashedPassword = hashedParams.password,
                Salt = hashedParams.salt,
                BirthDate = userDto.BirthDate,
                Biography = userDto.Biography               
            };
            data.Users.Add(user);
            data.SaveChanges();

            CreateSkillsUser(userDto.Skills,user.Id);         
            
            return user.Id;
        }

        public User RemoveUser(string fullname, string password)
        {
            User userExit = null;
            foreach(var user in data.Users.ToArray())
            {
                var passwordUser = passwordHandler.PasswordChecker(user.HashedPassword, user.Salt);
                if(user.FullName == fullname && password == passwordUser)
                {                    
                    var recruiter = data.Recruiters.Where(x => x.UserId == user.Id).FirstOrDefault();
                    recruiter.UserId = null;
                    data.Users.Remove(user);
                    data.SaveChanges();
                    userExit = user;
                    break;
                }
            }
            return userExit;
        }

        public CandidateShow[] GetExistingCandidates()
        {
            
            var candidates = data.Users.Select(x => new CandidateShow { Id = x.Id, Name = x.FullName }).ToArray();
            return candidates;
        }

        public bool ExistsCandidates()
        {
            return data.Users.Any();
        }
    }
}
