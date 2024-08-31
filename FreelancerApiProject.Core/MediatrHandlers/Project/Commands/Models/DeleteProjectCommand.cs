using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Models
{
    public class DeleteProjectCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
