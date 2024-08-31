using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Queries;

public class ProposalQueryHandler:ResponseHandler,
    IRequestHandler<GetProposalsQuery, Response<List<GetProposalResponse>>>,
    IRequestHandler<GetProposalsByJobIdQuery, Response<List<GetProposalResponse>>>,
    IRequestHandler<GetProposalsByFreelancerIdQuery, Response<List<GetProposalResponse>>>,
    IRequestHandler<GetProposalByIdQuery, Response<GetProposalResponse>>
{
    private readonly IProposalService _proposalService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public ProposalQueryHandler(IProposalService proposalService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _proposalService = proposalService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetProposalResponse>>> Handle(GetProposalsQuery request, CancellationToken cancellationToken)
    {
        var proposals =await _proposalService.GetAllAsync();
        if (proposals.Count == 0)
        {
            return Success(new List<GetProposalResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var proposalsResponse = _mapper.Map<List<GetProposalResponse>>(proposals);
        return Success(proposalsResponse);
    }

    public async Task<Response<GetProposalResponse>> Handle(GetProposalByIdQuery request, CancellationToken cancellationToken)
    {
        var proposal =await _proposalService.GetByIdAsync(request.Id);
        if (proposal is null)
        {
            return Success(new GetProposalResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var proposalResponse = _mapper.Map<GetProposalResponse>(proposal);
        return Success(proposalResponse);
    }
    public async Task<Response<List<GetProposalResponse>>> Handle(GetProposalsByJobIdQuery request, CancellationToken cancellationToken)
    {
        var proposals = await _proposalService.GetAllByJobIdAsync(request.JobId);
        if (proposals.Count == 0)
        {
            return Success(new List<GetProposalResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var proposalsResponse = _mapper.Map<List<GetProposalResponse>>(proposals);
        return Success(proposalsResponse);
    }

    public async Task<Response<List<GetProposalResponse>>> Handle(GetProposalsByFreelancerIdQuery request, CancellationToken cancellationToken)
    {
        var proposals = await _proposalService.GetAllByFreelancerIdAsync(request.FreelancerId);
        if (proposals.Count == 0)
        {
            return Success(new List<GetProposalResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var proposalsResponse = _mapper.Map<List<GetProposalResponse>>(proposals);
        return Success(proposalsResponse);
    }

}