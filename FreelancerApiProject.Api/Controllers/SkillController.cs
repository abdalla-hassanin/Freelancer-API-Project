using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Freelancer,Client")] // Both roles can access
    public class SkillController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await Mediator.Send(new GetSkillsQuery());
            return CreateResponse(response);
            
        }


        [HttpGet("{id:int}")] 
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetSkillByIdQuery(id));
            return CreateResponse(response);
        }
    }
}
