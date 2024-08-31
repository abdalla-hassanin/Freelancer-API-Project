using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;

public class GetRateByIdQuery: IRequest<Response<GetRateResponse>>
{
    public int Id { get; set; }

    public GetRateByIdQuery(int id)
    {
        Id = id;
    }
}
