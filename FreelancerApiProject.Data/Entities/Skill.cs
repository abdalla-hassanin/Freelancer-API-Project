
namespace FreelancerApiProject.Data.Entities
{
    // Represents a skill that can be associated with freelancers, jobs, and projects.
    public class Skill
    {
        public int Id { get; set; }

        // Title or name of the skill. Required field.
        public string Title { get; set; }

        // Detailed description of the skill. Optional.
        public string? Description { get; set; }

        // List of freelancers who have this skill.
        public List<FreelancerSkills>? Freelancers { get; set; }

        // List of jobs that require this skill.
        public List<JobSkills>? Jobs { get; set; }

        // List of projects that use this skill.
        public List<ProjectSkills>? Projects { get; set; }
    }
}