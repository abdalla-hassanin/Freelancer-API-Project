using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Models
{
    public class AddProjectCommand : IRequest<Response<string>>
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Link { get; set; }

        public string? Poster { get; set; }

        public List<string>? Images { get; set; } = [];
        
        public List<int>? SkillIds { get; set; } = [];

        public DateTime? TimePublished { get; set; } = DateTime.Now;

        public int FreelancerId { get; set; }

    }
}
