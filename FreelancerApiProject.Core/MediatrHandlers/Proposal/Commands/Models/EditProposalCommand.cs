using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models
{
    public class EditProposalCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public double? Duration { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }
        
        public List<string>? ReposLinks { get; set; }

        public List<string>? Images { get; set; }

        public int? FreelancerId { get; set; }
        
        public int? JobId { get; set; }
    }
}
