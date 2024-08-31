using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Queries;

public class GetProjectsByFreelancerIdQuery: IRequest<Response<List<GetProjectResponse>>>
{
    public int FreelancerId { get; set; }

    public GetProjectsByFreelancerIdQuery(int freelancerId)
    {
        FreelancerId = freelancerId;
    }
}