using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Client.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;

public class GetProposalsQuery : IRequest<Response<List<GetProposalResponse>>>
{
}