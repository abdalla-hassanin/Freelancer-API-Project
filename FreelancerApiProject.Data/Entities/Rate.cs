namespace FreelancerApiProject.Data.Entities
{
    // Represents a rating and feedback given to a job.
    public class Rate
    {
        public int Id { get; set; }

        // Feedback provided along with the rating. Optional.
        public string? Feedback { get; set; }

        // The numeric value of the rating, typically on a scale. Nullable.
        public int? Value { get; set; }

        // Foreign key to the job that was rated.
        public int? JobId { get; set; }

        // The job this rating is associated with.
        public Job Job { get; set; }
    }
}