using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Data.Entities
{
    // Represents a client who posts jobs on the platform.
    public class Client 
    {
        public int Id { get; set; }

        // Name of the client. Required field.
        public string Name { get; set; }

        // Date and time when the client registered on the platform.
        public DateTime RegistrationTime { get; set; }= DateTime.Now;

        // Description of the client. Optional.
        public string? Description { get; set; }

        // Profile image of the client. Optional.
        public string? Image { get; set; }

        // Country of the client. Optional.
        public string? Country { get; set; }

        // Contact phone number of the client. Optional.
        [Phone]
        public string? Phone { get; set; }

        // List of jobs posted by the client.
        public List<Job>? Jobs { get; set; } = new List<Job>();

        // Number of jobs posted by the client. Not mapped to the database.
        [NotMapped]
        public int JobsCount => Jobs.Count;

        // Number of jobs completed by the client. Not mapped to the database.
        [NotMapped]
        public int CompletedJobsCount => Jobs.Count(j => j.Status == JobStatusEnum.Closed);

        // Associated user account for the client.
        public ApplicationUser? User { get; set; }

        // List of notifications received by the client.
        public List<Notification>? Notifications { get; set; } = new List<Notification>();
    }
}