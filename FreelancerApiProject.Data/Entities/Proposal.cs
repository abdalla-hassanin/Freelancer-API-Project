using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Data.Entities
{
    // Represents a proposal submitted by a freelancer for a job.
    public class Proposal
    {
        public int Id { get; set; }

        // Deadline for the proposal, calculated after approval.
        public DateTime DeadLine { get; set; }

        // Time when the proposal was approved. Nullable.
        public DateTime? ApprovedTime { get; set; } = null;

        // Duration in days specified by the freelancer.
        public double Duration { get; set; }

        // Detailed description of the proposal. Optional.
        public string? Description { get; set; }

        // Proposed price for the job.
        public decimal Price { get; set; }

        // Current status of the proposal.
        public ProposalStatusEnum Status { get; set; } 

        // Links to repositories or other resources related to the proposal. Optional.
        public List<string>? ReposLinks { get; set; }

        // Images included with the proposal.
        public List<string>? Images { get; set; }

        // Foreign key to the freelancer who submitted the proposal.
        public int FreelancerId { get; set; }

        // The freelancer who submitted the proposal.
        public Freelancer Freelancer { get; set; }

        // Foreign key to the job the proposal is for.
        public int JobId { get; set; }

        // The job this proposal is associated with.
        public Job Job { get; set; }
    }
}