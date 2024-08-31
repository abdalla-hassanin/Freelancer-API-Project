using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Core.MediatrHandlers.Notification.Queries;

public class GetNotificationsResponse
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public int FreelancerId { get; set; }


    public string Title { get; set; }

    public DateTime SentTime { get; set; }

    public string Description { get; set; }

    public NotificationReasonEnum Reason { get; set; }
    public int? NotificationTriggerId { get; set; }
    public bool IsRead { get; set; }
}