using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Queries;

public class GetProjectResponse
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public string? Link { get; set; }

    public string? Poster { get; set; }

    public List<string>? Images { get; set; }

    public List<GetSkillResponse>? Skills { get; set; }

    public DateTime? TimePublished { get; set; }

    public int? FreelancerId { get; set; }


}