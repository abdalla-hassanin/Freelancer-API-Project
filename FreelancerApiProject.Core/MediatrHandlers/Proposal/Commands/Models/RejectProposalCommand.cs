using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models
{
    public class RejectProposalCommand : IRequest<Response<string>>
    {
        public int ProposalId  { get; set; }
        public RejectProposalCommand(int proposalId)
        {
            ProposalId = proposalId;
        }
    }
}
