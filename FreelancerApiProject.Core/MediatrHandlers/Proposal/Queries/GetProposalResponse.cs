using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Job.Queries;
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;

public class GetProposalResponse
{
    public int Id { get; set; }

    public DateTime DeadLine { get; set; }

    public DateTime ApprovedTime { get; set; } 

    public double Duration { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    // Current status of the proposal.
    public ProposalStatusEnum Status { get; set; } 

    public List<string>? ReposLinks { get; set; }

    public List<string>? Images { get; set; }

    public int FreelancerId { get; set; }
    
    public GetFreelancerResponse Freelancer { get; set; }

    public int JobId { get; set; }

    
   public GetJobResponse Job { get; set; }
}