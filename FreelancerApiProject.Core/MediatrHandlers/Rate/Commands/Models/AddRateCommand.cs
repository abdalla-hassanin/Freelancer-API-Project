using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models
{
    public class AddRateCommand : IRequest<Response<string>>
    {
        public string? Feedback { get; set; }

        public int? Value { get; set; }

        public int JobId { get; set; }

    }
}
