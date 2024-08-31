using System.ComponentModel.DataAnnotations;

namespace FreelancerApiProject.Data.Entities
{
    // Represents a freelancer who works on jobs posted by clients.
    public class Freelancer
    {
        [Key]
        public int Id { get; set; }

        // Profile image of the freelancer. Optional.
        public string? PersonalImage { get; set; } 

        // Name of the freelancer. Required field.
        public string Name { get; set; }

        // Title or job title of the freelancer. Optional.
        public string? Title { get; set; }

        // Address of the freelancer. Optional.
        public string? Address { get; set; }

        // Overview or biography of the freelancer. Optional.
        public string? Overview { get; set; }

        // Portfolio projects of the freelancer.
        public List<Project>? Portfolio { get; set; }

        // List of jobs the freelancer has worked on.
        public List<Job>? WorkingHistory { get; set; }

        // List of proposals the freelancer has submitted.
        public List<Proposal>? Proposals { get; set; }

        // List of skills the freelancer possesses.
        public List<FreelancerSkills>? Skills { get; set; } = [];

        // List of notifications received by the freelancer.
        public List<Notification>? Notifications { get; set; } = [];

        // Associated user account for the freelancer.
        public ApplicationUser? User { get; set; }
    }
}