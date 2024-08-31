using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Models
{
    public class DeleteJobCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteJobCommand(int id)
        {
            Id = id;
        }
    }
}
