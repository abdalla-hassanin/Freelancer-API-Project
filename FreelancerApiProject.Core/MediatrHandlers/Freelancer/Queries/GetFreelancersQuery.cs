using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;

public class GetFreelancersQuery : IRequest<Response<List<GetFreelancerResponse>>>
{
}