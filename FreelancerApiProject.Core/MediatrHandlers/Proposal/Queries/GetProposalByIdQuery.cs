using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Client.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;

public class GetProposalByIdQuery: IRequest<Response<GetProposalResponse>>
{
    public int Id { get; set; }

    public GetProposalByIdQuery(int id)
    {
        Id = id;
    }
}
