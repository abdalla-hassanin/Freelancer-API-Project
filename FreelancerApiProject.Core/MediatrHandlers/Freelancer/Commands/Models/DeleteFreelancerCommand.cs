using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Models
{
    public class DeleteFreelancerCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteFreelancerCommand(int id)
        {
            Id = id;
        }
    }
}
