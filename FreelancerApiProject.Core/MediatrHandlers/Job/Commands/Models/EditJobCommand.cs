using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Data.Enums;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Models
{
    public class EditJobCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public DateTime PostTime { get; set; } = DateTime.Now;
    
        public string? Description { get; set; }

        public decimal? MinBudget { get; set; }

        public decimal? MaxBudget { get; set; }

        public int? DurationInDays { get; set; }
     
        public ExperienceStatusEnum? ExperienceLevel { get; set; }

        public List<int>? SkillsIds { get; set; } = [];
        
        public JobStatusEnum? Status { get; set; } = JobStatusEnum.Active;

        public int? ClientId { get; set; }
        public int? CategoryId { get; set; }    }
}
