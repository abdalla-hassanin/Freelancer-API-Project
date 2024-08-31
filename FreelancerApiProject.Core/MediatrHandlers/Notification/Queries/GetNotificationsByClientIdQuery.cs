using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Notification.Queries;

public class GetNotificationsByClientIdQuery: IRequest<Response<List<GetNotificationsResponse>>>
{
    public int ClientId { get; set; }

    public GetNotificationsByClientIdQuery(int clientId)
    {
        ClientId = clientId;
    }
}