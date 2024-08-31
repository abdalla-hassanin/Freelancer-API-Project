using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;

public class GetFreelancerByIdQuery: IRequest<Response<GetFreelancerResponse>>
{
    public int Id { get; set; }

    public GetFreelancerByIdQuery(int id)
    {
        Id = id;
    }
}
