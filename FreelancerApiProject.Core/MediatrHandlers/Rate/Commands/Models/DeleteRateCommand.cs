using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models
{
    public class DeleteRateCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteRateCommand(int id)
        {
            Id = id;
        }
    }
}
