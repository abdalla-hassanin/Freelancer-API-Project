using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;

public class GetFreelancerResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string PersonalImage { get; set; }
        
    public string Title { get; set; }

    public string? Address { get; set; }

    public string? Overview { get; set; }

    public List<GetProjectResponse>? Portfolio { get; set; }
    public List<GetSkillResponse>? Skills { get; set; }

    //TODO: After adding working history and proposals to the response we need to add them here
    // public List<GetJobResponse>? WorkingHistory { get; set; }
    //
    // public List<GetProposalResponse>? Proposals { get; set; }



}