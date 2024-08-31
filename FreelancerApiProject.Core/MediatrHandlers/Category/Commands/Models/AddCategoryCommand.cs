using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Category.Commands.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
