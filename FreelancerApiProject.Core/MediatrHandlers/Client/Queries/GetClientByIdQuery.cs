using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Queries;

public class GetClientByIdQuery: IRequest<Response<GetClientResponse>>
{
    public int Id { get; set; }

    public GetClientByIdQuery(int id)
    {
        Id = id;
    }
}
