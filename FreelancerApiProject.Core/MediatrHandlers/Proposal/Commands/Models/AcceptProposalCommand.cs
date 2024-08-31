using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models
{
    public class AcceptProposalCommand : IRequest<Response<string>>
    {
        public int ProposalId  { get; set; }
        public AcceptProposalCommand(int proposalId)
        {
            ProposalId = proposalId;
        }
    }
}
