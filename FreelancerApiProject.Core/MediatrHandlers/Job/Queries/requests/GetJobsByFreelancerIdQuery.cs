using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobsByFreelancerIdQuery : IRequest<Response<List<GetJobResponse>>>
{
    public int FreelancerId { get; set; }

    public GetJobsByFreelancerIdQuery(int freelancerId)
    {
        FreelancerId = freelancerId;
    }
}
