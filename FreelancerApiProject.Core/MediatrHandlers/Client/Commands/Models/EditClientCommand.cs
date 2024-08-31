using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Models
{
    public class EditClientCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        
        public string? Description { get; set; }

        public string? Image { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }
    }
}
