using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Notification.Queries;

public class GetNotificationsByFreelancerIdQuery: IRequest<Response<List<GetNotificationsResponse>>>
{
    public int FreelancerId { get; set; }

    public GetNotificationsByFreelancerIdQuery(int freelancerId)
    {
        FreelancerId = freelancerId;
    }
}