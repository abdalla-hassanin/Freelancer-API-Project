using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobsByClientIdQuery : IRequest<Response<List<GetJobResponse>>>
{
    public int ClientId { get; set; }

    public GetJobsByClientIdQuery(int clientId)
    {
        ClientId = clientId;
    }
}
