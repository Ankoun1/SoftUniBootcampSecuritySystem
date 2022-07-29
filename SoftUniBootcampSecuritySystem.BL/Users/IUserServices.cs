using System.Collections.Generic;
using SoftUniBootcampSecuritySystem.DTO;
using SoftUniBootcampSecuritySystem.DTO.Export;
using SoftUniBootcampSecuritySystem.DTO.Import.User;
using SoftUniBootcampSecuritySystem.Models.Entity;

namespace SoftUniBootcampSecuritySystem.BL.Users
{
    public interface IUserServices
    {
        int NewRegistrationUser(RegisterUser user);

        void CreateSkillsUser(List<string> skills,int userId);
        
        int NewRegistrationRecruiter(RegisterRecruiter recruiter,int? userId);

        public bool CheckRecruiterInterwiewExsist(int userId, List<string> skillsUser);

        (string Name, string Role) Get(LoginUser user);

        bool ExistingUser(string fullname,string password);

        User RemoveUser(string fullname,string password);

        CandidateShow[] GetExistingCandidates();

        bool ExistsCandidates();
    }
}
