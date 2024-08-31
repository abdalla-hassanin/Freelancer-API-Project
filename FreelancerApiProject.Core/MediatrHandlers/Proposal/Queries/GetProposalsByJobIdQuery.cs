using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;

public class GetProposalsByJobIdQuery : IRequest<Response<List<GetProposalResponse>>>
{
    public int JobId { get; set; }

    public GetProposalsByJobIdQuery(int jobId)
    {
        JobId = jobId;
    }
}