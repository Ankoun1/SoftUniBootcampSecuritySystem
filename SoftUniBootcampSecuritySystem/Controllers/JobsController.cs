using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniBootcampSecuritySystem.BL.Jobs;
using SoftUniBootcampSecuritySystem.DTO.Import.Job;

namespace SoftUniBootcampSecuritySystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobServices jobServices;
        public JobsController(IJobServices jobServices)
        {
            this.jobServices = jobServices;
        }

        [Route("create")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult Create(CreateInterwiew interwiew)
        {
            int jobId = jobServices.CreateNewJob(interwiew.Job);
            jobServices.CreateRecruiterInterwiew(jobId,interwiew.Job.JobRequirements,interwiew.Recruiter);           

            return StatusCode(201);
        }

        [Route("delete")]
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult DeleteJob(int id)
        {
            if (!jobServices.ExistJob(id))
            {
                return NotFound();
            }
            jobServices.RemoveJob(id);
            return StatusCode(201);
        }
    }
}
