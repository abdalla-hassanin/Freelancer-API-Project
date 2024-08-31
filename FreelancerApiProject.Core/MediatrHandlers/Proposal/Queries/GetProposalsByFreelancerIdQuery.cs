using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Client.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;

public class GetProposalsByFreelancerIdQuery: IRequest<Response<List<GetProposalResponse>>>
{
    public int FreelancerId { get; set; }

    public GetProposalsByFreelancerIdQuery(int freelancerId)
    {
        FreelancerId = freelancerId;
    }
}
