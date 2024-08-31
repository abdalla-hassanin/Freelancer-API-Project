using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Client.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Client")]
    public class ClientController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetClientsQuery());
            return CreateResponse(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetClientByIdQuery(id));
            return CreateResponse(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] AddClientCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRate(EditClientCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteClientCommand(id));
            return CreateResponse(response);
        }
    }
}