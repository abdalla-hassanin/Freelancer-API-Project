using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;

namespace FreelancerApiProject.Core.MediatrHandlers.Category.Queries;

public class GetCategoryResponse
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Description { get; set; }

    public int JobsUseThisCategory { get; set; }

}