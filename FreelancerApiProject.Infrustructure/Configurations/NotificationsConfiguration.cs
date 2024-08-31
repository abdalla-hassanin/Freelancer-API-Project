using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class NotificationsConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Title).IsRequired().HasMaxLength(50);
            builder.Property(n => n.Description).IsRequired(false).HasMaxLength(2000);

            builder.HasOne(n => n.Client)
                      .WithMany(c => c.Notifications)
                      .HasForeignKey(c => c.ClientId);


            builder.HasOne(c => c.Freelancer)
                      .WithMany(c => c.Notifications)
                      .HasForeignKey(c => c.FreelancerId);

            builder.HasData(
                new Notification
                {
                    Id = 1, ClientId = 1, FreelancerId = null, Title = "تم قبول عرضك", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.AcceptedProposal, NotificationTriggerId = 1, IsRead = false,
                    Description = "تم قبول عرضك لتصميم الشعار."
                },
                new Notification
                {
                    Id = 2, ClientId = 2, FreelancerId = null, Title = "تم رفض عرضك", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.RejectedProposal, NotificationTriggerId = 2, IsRead = false,
                    Description = "عرضك لتطوير الموقع قد تم رفضه."
                },
                new Notification
                {
                    Id = 3, ClientId = null, FreelancerId = 1, Title = "مهمة جديدة", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.Welcome, NotificationTriggerId = 3, IsRead = false,
                    Description = "لديك مهمة جديدة لتطوير موقع ويب."
                },
                new Notification
                {
                    Id = 4, ClientId = null, FreelancerId = 2, Title = "تم تغيير حالة المشروع", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.NewProposalAdded, NotificationTriggerId = 4, IsRead = false,
                    Description = "تم تغيير حالة المشروع الخاص بك."
                },
                new Notification
                {
                    Id = 5, ClientId = 3, FreelancerId = null, Title = "عرض جديد متاح", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.NewProposalAdded, NotificationTriggerId = 5, IsRead = false,
                    Description = "هناك عرض جديد متاح لمشروعك."
                },
                new Notification
                {
                    Id = 6, ClientId = 4, FreelancerId = null, Title = "مراجعة المشروع", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.Welcome, NotificationTriggerId = 6, IsRead = false,
                    Description = "يرجى مراجعة المشروع المقدم."
                },
                new Notification
                {
                    Id = 7, ClientId = null, FreelancerId = 3, Title = "تحديث حالة المشروع", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.Welcome, NotificationTriggerId = 7, IsRead = false,
                    Description = "تم تحديث حالة المشروع الخاص بك."
                },
                new Notification
                {
                    Id = 8, ClientId = null, FreelancerId = 4, Title = "تمت الموافقة على العرض",
                    SentTime = DateTime.Now, Reason = NotificationReasonEnum.AcceptedProposal,
                    NotificationTriggerId = 8, IsRead = false, Description = "تمت الموافقة على عرضك لتحليل البيانات."
                },
                new Notification
                {
                    Id = 9, ClientId = 5, FreelancerId = null, Title = "تم تعيينك في المشروع", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.NewProposalAdded, NotificationTriggerId = 9, IsRead = false,
                    Description = "تم تعيينك لإدارة حملة تسويقية."
                },
                new Notification
                {
                    Id = 10, ClientId = null, FreelancerId = 5, Title = "عرض جديد متاح", SentTime = DateTime.Now,
                    Reason = NotificationReasonEnum.NewProposalAdded, NotificationTriggerId = 10, IsRead = false,
                    Description = "عرض جديد متاح لمشروع التصميم الداخلي."
                }

            );
        }
    }
}
