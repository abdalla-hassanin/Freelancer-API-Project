using FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;
using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobResponse
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime PostTime { get; set; } = DateTime.Now;
    
    public string Description { get; set; }

    public decimal MinBudget { get; set; }

    public decimal MaxBudget { get; set; }

    public int DurationInDays { get; set; }
     
    public ExperienceStatusEnum ExperienceLevel { get; set; }

    public List<GetSkillResponse>? Skills { get; set; } =[];

    public List<GetProposalResponse>? Proposals { get; set; } = [];

    public GetRateResponse? Rate { get; set; } 
    
    public JobStatusEnum Status { get; set; } = JobStatusEnum.Active;


    public int ClientId { get; set; }

    public string? ClientName { get; set; }

    public int? AcceptedFreelancerId { get; set; }

    public string? AcceptedFreelancerName { get; set; }

    
    public int CategoryId { get; set; }

    public string? CategoryTitle { get; set; }


}
