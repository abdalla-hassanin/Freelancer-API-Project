using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Infrustructure.Base;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobsPaginatedQuery : IRequest<Response<PaginatedListModel<GetJobResponse>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetJobsPaginatedQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}