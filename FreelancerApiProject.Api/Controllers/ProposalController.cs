using FreelancerApiProject.Api.Base;
using FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerApiProject.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Freelancer,Client")]
    public class ProposalController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetProposalsQuery());
            return CreateResponse(response);
        }

        [HttpGet("job/{jobId:int}")]
        public async Task<IActionResult> GetAllByJobId(int jobId)
        {
            var response = await Mediator.Send(new GetProposalsByJobIdQuery(jobId));
            return CreateResponse(response);
        }

        [HttpGet("freelancer/{freelancerId:int}")]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> GetAllByFreelancerId(int freelancerId)
        {
            var response = await Mediator.Send(new GetProposalsByFreelancerIdQuery(freelancerId));
            return CreateResponse(response);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetProposalByIdQuery(id));
            return CreateResponse(response);
        }

        [HttpPost]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> CreateProposal([FromBody] AddProposalCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> UpdateProposal(EditProposalCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Freelancer")]
        public async Task<IActionResult> DeleteProposal([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteProposalCommand(id));
            return CreateResponse(response);
        }

        [HttpPost("{id:int}/accept")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> AcceptProposal([FromRoute] int id)
        {
            var response = await Mediator.Send(new AcceptProposalCommand(id));
            return CreateResponse(response);
        }

        [HttpPost("{id:int}/reject")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> RejectProposal([FromRoute] int id)
        {
            var response = await Mediator.Send(new RejectProposalCommand(id));
            return CreateResponse(response);
        }
    }
}