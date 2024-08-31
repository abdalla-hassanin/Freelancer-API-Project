using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Queries;

public class GetJobsByTitleQuery : IRequest<Response<List<GetJobResponse>>>
{
    public string Title { get; set; }

    public GetJobsByTitleQuery(string title)
    {
        Title = title;
    }
}