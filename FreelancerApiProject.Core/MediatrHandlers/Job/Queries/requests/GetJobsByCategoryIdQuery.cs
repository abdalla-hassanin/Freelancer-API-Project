using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobsByCategoryIdQuery : IRequest<Response<List<GetJobResponse>>>
{
    public int CategoryId { get; set; }

    public GetJobsByCategoryIdQuery(int categoryId)
    {
        CategoryId = categoryId;
    }
}