using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Category.Queries;

public class GetCategoryByIdQuery : IRequest<Response<GetCategoryResponse>>
{
    public int Id { get; set; }

    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}