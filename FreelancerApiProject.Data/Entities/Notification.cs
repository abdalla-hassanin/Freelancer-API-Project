using System.ComponentModel.DataAnnotations;
using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Data.Entities
{
    // Represents a notification sent to a client or freelancer.
    public class Notification
    {
        public int Id { get; set; }

        // Foreign key to the client who received the notification. Nullable.
        public int? ClientId { get; set; }

        // The client who received the notification. Nullable.
        public Client? Client { get; set; }

        // Foreign key to the freelancer who received the notification. Nullable.
        public int? FreelancerId { get; set; }

        // The freelancer who received the notification. Nullable.
        public Freelancer? Freelancer { get; set; }

        // Title of the notification.
        public string Title { get; set; }

        // Time when the notification was sent.
        public DateTime SentTime { get; set; }

        // Detailed description of the notification. Optional.
        public string? Description { get; set; }

        // Reason for sending the notification, used by the frontend to create a relevant URL.
        public NotificationReasonEnum Reason { get; set; }

        // ID of the entity that triggered the notification, used by the frontend for routing.
        public int? NotificationTriggerId { get; set; }

        // Indicates whether the notification has been read.
        public bool IsRead { get; set; } 
    }
}