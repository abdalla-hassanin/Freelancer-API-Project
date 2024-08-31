using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Queries;

public class GetProjectByIdQuery: IRequest<Response<GetProjectResponse>>
{
    public int Id { get; set; }

    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }
}
