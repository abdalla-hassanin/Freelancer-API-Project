using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Freelancer")] 
    public class ProjectController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetProjectsQuery());
            return CreateResponse(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetProjectByIdQuery(id));
            return CreateResponse(response);
        }

        [HttpGet("by-freelancer/{freelancerId:int}")]
        public async Task<IActionResult> GetAllByFreelancerId(int freelancerId)
        {
            var response = await Mediator.Send(new GetProjectsByFreelancerIdQuery(freelancerId));
            return CreateResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] AddProjectCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(EditProjectCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteProjectCommand(id));
            return CreateResponse(response);
        }
    }
}