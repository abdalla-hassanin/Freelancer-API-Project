using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;

public class FreelancerQueryHandler:ResponseHandler,
    IRequestHandler<GetFreelancersQuery, Response<List<GetFreelancerResponse>>>,
    IRequestHandler<GetFreelancerByIdQuery, Response<GetFreelancerResponse>>
{
    private readonly IFreelancerService _freelancerService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public FreelancerQueryHandler(IFreelancerService freelancerService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _freelancerService = freelancerService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetFreelancerResponse>>> Handle(GetFreelancersQuery request, CancellationToken cancellationToken)
    {
        var freelancers =await _freelancerService.GetAllAsync();
        if (freelancers.Count == 0)
        {
            return Success(new List<GetFreelancerResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var freelancersResponse = _mapper.Map<List<GetFreelancerResponse>>(freelancers);
        return Success(freelancersResponse);
    }

    public async Task<Response<GetFreelancerResponse>> Handle(GetFreelancerByIdQuery request, CancellationToken cancellationToken)
    {
        var freelancer =await _freelancerService.GetByIdAsync(request.Id);
        if (freelancer is null)
        {
            return Success(new GetFreelancerResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var freelancerResponse = _mapper.Map<GetFreelancerResponse>(freelancer);
        return Success(freelancerResponse);
    }

}