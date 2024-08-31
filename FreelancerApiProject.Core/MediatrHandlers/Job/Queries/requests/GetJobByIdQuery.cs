using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobByIdQuery: IRequest<Response<GetJobResponse>>
{
    public int Id { get; set; }

    public GetJobByIdQuery(int id)
    {
        Id = id;
    }
}
