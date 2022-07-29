using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniBootcampSecuritySystem.DTO.Import.User;
using SoftUniBootcampSecuritySystem.BL.Users;
using SoftUniBootcampSecuritySystem.Api.Infrastructure;
using SoftUniBootcampSecuritySystem.DTO.Export;

namespace SoftUniBootcampSecuritySystem.Api.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices userServices;
        private readonly ClaimsPrincipalExtensions claimsPrincipalExtensions;
        
        public UsersController(IUserServices userServices, ClaimsPrincipalExtensions claimsPrincipalExtensions)
        {
            this.userServices = userServices;
            this.claimsPrincipalExtensions = claimsPrincipalExtensions;          
        }

        [Route("create")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult Register(RegisterWorker worker)
        {
            if (userServices.ExistingUser(worker.User.FullName, worker.User.Password))
            {
                return BadRequest();
            }
            
            int userId = userServices.NewRegistrationUser(worker.User);
            if(!userServices.CheckRecruiterInterwiewExsist(userId, worker.User.Skills))
            {
                userServices.NewRegistrationRecruiter(worker.Recruiter, userId);
            }           
            
            return StatusCode(201);
        }

        [Route("login")]
        [HttpPost]        
        public IActionResult Login(LoginUser user)
        {
            if (!string.IsNullOrEmpty(user.FullName) &&
                !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser = userServices.Get(user);
                if (loggedInUser.Name is null)
                {
                    return NotFound("User not found");
                }
                var tokenString = claimsPrincipalExtensions.SecurityCommunication(loggedInUser);
          
                return Ok(tokenString);
            }
            return BadRequest("Invalid user credentials");
        }

        [Route("delete")]
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User,Administrator")]
        public IActionResult ExitSuccess(LoginUser user)
        {
            if (!userServices.ExistingUser(user.FullName, user.Password))
            {
                return BadRequest();
            }

            var userExit = userServices.RemoveUser(user.FullName, user.Password);
            return Ok(userExit);
        }

        [Route("candidates")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public  ActionResult<CandidateShow[]> GetCandidates()
        {
            if (!userServices.ExistsCandidates())
            {
                return NotFound();
            }

            var candidates = userServices.GetExistingCandidates();
            return candidates;
        }
    }
}