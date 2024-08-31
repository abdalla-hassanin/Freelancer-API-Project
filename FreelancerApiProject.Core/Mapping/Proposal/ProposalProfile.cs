using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;

namespace FreelancerApiProject.Core.Mapping.Proposal;

public partial class ProposalProfile : Profile
{
    public ProposalProfile()
    {
        CreateMap<Data.Entities.Proposal, GetProposalResponse>();
        
        
        CreateMap<AddProposalCommand, Data.Entities.Proposal>();

    }
}