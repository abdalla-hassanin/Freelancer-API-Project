
namespace FreelancerApiProject.Data.Entities
{
    // Represents the many-to-many relationship between Freelancer and Skill entities.
    public class FreelancerSkills
    {
        // Foreign key to the Freelancer entity.
        public int FreelancerId { get; set; }

        // The freelancer associated with this skill.
        public Freelancer Freelancer { get; set; }

        // Foreign key to the Skill entity.
        public int SkillId { get; set; }

        // The skill associated with this freelancer.
        public Skill Skill { get; set; }
    }
}