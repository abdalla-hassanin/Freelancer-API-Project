using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancerApiProject.Data.Entities
{
    // Represents the many-to-many relationship between Job and Skill entities.
    public class JobSkills
    {
        // Foreign key to the Job entity.
        public int JobId { get; set; }

        // The job associated with this skill.
        public Job Job { get; set; }

        // Foreign key to the Skill entity.
        public int SkillId { get; set; }

        // The skill associated with this job.
        public Skill Skill { get; set; }
    }
}