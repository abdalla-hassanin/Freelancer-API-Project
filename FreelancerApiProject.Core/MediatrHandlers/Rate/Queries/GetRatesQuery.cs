using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;

public class GetRatesQuery: IRequest<Response<List<GetRateResponse>>>
{
    
}