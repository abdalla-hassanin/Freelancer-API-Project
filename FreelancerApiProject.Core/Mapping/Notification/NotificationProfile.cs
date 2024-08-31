using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Notification.Queries;

namespace FreelancerApiProject.Core.Mapping.Notification;

public partial class NotificationProfile:Profile
{
    public NotificationProfile()
    {
        CreateMap<Data.Entities.Notification, GetNotificationsResponse>();
    }
}