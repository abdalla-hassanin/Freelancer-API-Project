using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;

public class RateQueryHandler:ResponseHandler,
    IRequestHandler<GetRatesQuery, Response<List<GetRateResponse>>>,
    IRequestHandler<GetRateByIdQuery, Response<GetRateResponse>>
{
    private readonly IRateService _rateService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public RateQueryHandler(IRateService rateService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _rateService = rateService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetRateResponse>>> Handle(GetRatesQuery request, CancellationToken cancellationToken)
    {
        var rates =await _rateService.GetAll();
        if (rates.Count == 0)
        {
            return Success(new List<GetRateResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var ratesResponse = _mapper.Map<List<GetRateResponse>>(rates);
        return Success(ratesResponse);
    }

    public async Task<Response<GetRateResponse>> Handle(GetRateByIdQuery request, CancellationToken cancellationToken)
    {
        var rate =await _rateService.GetById(request.Id);
        if (rate is null)
        {
            return Success(new GetRateResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var rateResponse = _mapper.Map<GetRateResponse>(rate);
        return Success(rateResponse);
    }
}