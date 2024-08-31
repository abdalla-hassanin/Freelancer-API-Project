using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Models
{
    public class AddFreelancerCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }

        public string PersonalImage { get; set; }
        
        public string Title { get; set; }

        public string? Address { get; set; }

        public string? Overview { get; set; }

        public List<int>? SkillIds { get; set; } = [];
    }
}