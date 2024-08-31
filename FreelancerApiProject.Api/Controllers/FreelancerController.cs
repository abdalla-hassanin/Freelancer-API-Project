using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Freelancer")]
    public class FreelancerController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetFreelancersQuery());
            return CreateResponse(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetFreelancerByIdQuery(id));
            return CreateResponse(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateFreelancer([FromBody] AddFreelancerCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFreelancer(EditFreelancerCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteFreelancerCommand(id));
            return CreateResponse(response);
        }
    }
}