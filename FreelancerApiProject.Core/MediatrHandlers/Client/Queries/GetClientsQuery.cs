using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Queries;

public class GetClientsQuery : IRequest<Response<List<GetClientResponse>>>
{
}