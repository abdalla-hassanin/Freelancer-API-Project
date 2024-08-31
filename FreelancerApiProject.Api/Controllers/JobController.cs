using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Job.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Freelancer,Client")]
    public class JobController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetJobsQuery());
            return CreateResponse(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetJobByIdQuery(id));
            return CreateResponse(response);
        }
        
        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CreateJob([FromBody] AddJobCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> UpdateJob(EditJobCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteJobCommand(id));
            return CreateResponse(response);
        }
        [HttpGet("by-category/{categoryId:int}")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId)
        {
            var response = await Mediator.Send(new GetJobsByCategoryIdQuery(categoryId));
            return CreateResponse(response);
        }

        [HttpGet("by-freelancer/{freelancerId:int}")]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> GetAllByFreelancerId(int freelancerId)
        {
            var response = await Mediator.Send(new GetJobsByFreelancerIdQuery(freelancerId));
            return CreateResponse(response);
        }

        [HttpGet("by-client/{clientId:int}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> GetAllByClientId(int clientId)
        {
            var response = await Mediator.Send(new GetJobsByClientIdQuery(clientId));
            return CreateResponse(response);
        }

        [HttpGet("by-title")]
        public async Task<IActionResult> GetAllByTitle([FromQuery] string title)
        {
            var response = await Mediator.Send(new GetJobsByTitleQuery(title));
            return CreateResponse(response);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetAllPaginated([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var response = await Mediator.Send(new GetJobsPaginatedQuery(pageNumber, pageSize));
            return CreateResponse(response);
        }
    }

}