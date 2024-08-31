using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Freelancer,Client")]
    public class RateController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetRatesQuery());
            return CreateResponse(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetRateByIdQuery(id));
            return CreateResponse(response);
        }


        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CreateRate([FromBody] AddRateCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }


        [HttpPut]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> UpdateRate(EditRateCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> DeleteRate([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteRateCommand(id));
            return CreateResponse(response);
        }
    }
}