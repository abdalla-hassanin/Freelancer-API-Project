using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Queries;

public class GetProjectsQuery : IRequest<Response<List<GetProjectResponse>>>
{
}