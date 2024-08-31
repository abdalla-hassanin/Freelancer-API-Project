using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models
{
    public class DeleteProposalCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteProposalCommand(int id)
        {
            Id = id;
        }
    }
}
