using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models
{
    public class EditRateCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? Feedback { get; set; }

        public int? Value { get; set; }

        public int? JobId { get; set; }
    }
}
