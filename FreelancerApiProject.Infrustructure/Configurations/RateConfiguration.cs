using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {

            builder.HasKey(r => r.Id);

            builder.HasCheckConstraint("CK_VALUE_RANGE", "[Value] BETWEEN 1 AND 5");


            builder.HasOne(r => r.Job)
                .WithOne(j => j.Rate)
                .HasForeignKey<Rate>(r => r.JobId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
                new Rate { Id = 1, Feedback = "خدمة ممتازة وسريعة.", Value = 5, JobId = 1 },
                new Rate { Id = 2, Feedback = "عمل جيد ولكن يحتاج لبعض التحسينات.", Value = 4, JobId = 2 },
                new Rate { Id = 3, Feedback = "خدمة متوسطة، غير متوقعة.", Value = 3, JobId = 3 },
                new Rate { Id = 4, Feedback = "جيد ولكن يحتاج لتحسين.", Value = 3, JobId = 4 },
                new Rate { Id = 5, Feedback = "عمل ممتاز وسريع.", Value = 5, JobId = 5 },
                new Rate { Id = 6, Feedback = "مبدع ومحترف في العمل.", Value = 5, JobId = 6 },
                new Rate { Id = 7, Feedback = "محترف في الإدارة ولكن الوقت كان أطول من المتوقع.", Value = 4, JobId = 7 },
                new Rate { Id = 8, Feedback = "خدمة متوسطة، كان هناك بعض الأخطاء.", Value = 3, JobId = 8 },
                new Rate { Id = 9, Feedback = "عمل ممتاز وتم تنفيذ المشروع كما هو مطلوب.", Value = 5, JobId = 9 },
                new Rate { Id = 10, Feedback = "إبداع في التصميم الداخلي وتفاصيل رائعة.", Value = 5, JobId = 10 }
            );

        }
    }
}
