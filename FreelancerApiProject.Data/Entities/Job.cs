using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Data.Entities
{
    // Represents a job posted by a client on the platform.
    public class Job
    {
        public int Id { get; set; }

        // Title of the job. Required field.
        public string Title { get; set; }

        // The time when the job was posted.
        public DateTime PostTime { get; set; } = DateTime.Now;

        // The time when the job was approved. Optional.
        public DateTime? ApproveTime { get; set; } 

        // Detailed description of the job. Required field.
        public string Description { get; set; }

        // Minimum budget for the job.
        public decimal MinBudget { get; set; }

        // Maximum budget for the job.
        public decimal MaxBudget { get; set; }

        // Expected duration to complete the job, in days.
        public int DurationInDays { get; set; }

        // Required experience level for the job.
        public ExperienceStatusEnum ExperienceLevel { get; set; }

        // Skills required for the job.
        public List<JobSkills>? Skills { get; set; } = new List<JobSkills>();

        // Proposals submitted for this job.
        public List<Proposal>? Proposals { get; set; } = new List<Proposal>();

        // Rating given to the job after completion. Optional.
        public Rate? Rate { get; set; }

        // Current status of the job.
        public JobStatusEnum Status { get; set; } 

        // Foreign key to the client who posted the job.
        public int ClientId { get; set; }

        // The client who posted the job.
        public Client Client { get; set; }

        // Foreign key to the freelancer who accepted the job. Nullable.
        public int? AcceptedFreelancerId { get; set; }

        // The freelancer who accepted the job. Nullable.
        public Freelancer? AcceptedFreelancer { get; set; }

        // Foreign key to the category of the job.
        public int CategoryId { get; set; }

        // The category the job belongs to. Nullable.
        public Category? Category { get; set; }
    }
}
