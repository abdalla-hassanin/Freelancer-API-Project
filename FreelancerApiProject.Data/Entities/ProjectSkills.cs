
namespace FreelancerApiProject.Data.Entities
{
    // Represents the many-to-many relationship between Project and Skill entities.
    public class ProjectSkills
    {
        // Foreign key to the Project entity.
        public int ProjectId { get; set; }

        // The project associated with this skill.
        public Project Project { get; set; }

        // Foreign key to the Skill entity.
        public int SkillId { get; set; }

        // The skill associated with this project.
        public Skill Skill { get; set; }
    }
}