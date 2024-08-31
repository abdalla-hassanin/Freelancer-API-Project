using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobsQuery : IRequest<Response<List<GetJobResponse>>>
{
}