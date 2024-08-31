using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Models
{
    public class DeleteClientCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteClientCommand(int id)
        {
            Id = id;
        }
    }
}
