using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Category.Queries;

public class GetCategoriesQuery : IRequest<Response<List<GetCategoryResponse>>>
{
}