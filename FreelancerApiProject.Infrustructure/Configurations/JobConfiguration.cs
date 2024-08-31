using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            // Primary key
            builder.HasKey(j => j.Id);

            // Properties
            builder.Property(j => j.Title)
                .IsRequired()
                .HasMaxLength(100); // Adjust the length as needed

            builder.Property(j => j.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(j => j.MinBudget)
                .HasColumnType("decimal(18, 2)"); // Adjust the precision and scale as needed

            builder.Property(j => j.MaxBudget)
                .HasColumnType("decimal(18, 2)"); // Adjust the precision and scale as needed

            builder.Property(j => j.DurationInDays)
                .IsRequired();

            builder.Property(j => j.ExperienceLevel)
                .IsRequired();

            builder.Property(j => j.Status)
                .HasDefaultValue(JobStatusEnum.Active);

            // Relationships
            builder.HasOne(j => j.Client)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.ClientId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

            builder.HasOne(j => j.AcceptedFreelancer)
                .WithMany()
                .HasForeignKey(j => j.AcceptedFreelancerId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

            builder.HasOne(j => j.Category)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

            builder.HasMany(j => j.Skills)
                .WithOne(js => js.Job)
                .HasForeignKey(js => js.JobId)
                .OnDelete(DeleteBehavior.Cascade); // Cascades delete to JobSkills

            builder.HasMany(j => j.Proposals)
                .WithOne(p => p.Job)
                .HasForeignKey(p => p.JobId)
                .OnDelete(DeleteBehavior.Cascade); // Cascades delete to Proposals

            builder.HasOne(j => j.Rate)
                .WithOne(r => r.Job)
                .HasForeignKey<Rate>(r => r.JobId)
                .OnDelete(DeleteBehavior.Cascade); // Cascades delete to Rate
            
            // Seed Data
            builder.HasData(
                new Job { Id = 1, Title = "تصميم شعار لشركة", Description = "نحتاج لتصميم شعار جديد لشركتنا باستخدام تقنيات التصميم الحديثة.", MinBudget = 100, MaxBudget = 500, DurationInDays = 10, ExperienceLevel = ExperienceStatusEnum.Beginner, Status = JobStatusEnum.Active, ClientId = 1, CategoryId = 1 },
                new Job { Id = 2, Title = "تطوير موقع تجارة إلكترونية", Description = "تطوير موقع تجارة إلكترونية متكامل باللغتين العربية والإنجليزية.", MinBudget = 1500, MaxBudget = 3000, DurationInDays = 30, ExperienceLevel = ExperienceStatusEnum.Intermediate, Status = JobStatusEnum.Active, ClientId = 2, CategoryId = 2 },
                new Job { Id = 3, Title = "كتابة مقالات للسيو", Description = "كتابة مقالات متوافقة مع محركات البحث (SEO) في مجال التكنولوجيا.", MinBudget = 200, MaxBudget = 800, DurationInDays = 7, ExperienceLevel = ExperienceStatusEnum.Professional, Status = JobStatusEnum.Active, ClientId = 3, CategoryId = 3 },
                new Job { Id = 4, Title = "تحليل بيانات السوق", Description = "تحليل بيانات السوق لإنشاء تقرير شامل عن الأداء المالي للشركة.", MinBudget = 500, MaxBudget = 1000, DurationInDays = 15, ExperienceLevel = ExperienceStatusEnum.Intermediate, Status = JobStatusEnum.Active, ClientId = 4, CategoryId = 4 },
                new Job { Id = 5, Title = "إدارة حملة تسويقية", Description = "إدارة حملة تسويقية رقمية على منصات التواصل الاجتماعي.", MinBudget = 1000, MaxBudget = 2000, DurationInDays = 20, ExperienceLevel = ExperienceStatusEnum.Intermediate, Status = JobStatusEnum.Active, ClientId = 5, CategoryId = 5 },
                new Job { Id = 6, Title = "تطوير تطبيق جوال", Description = "تطوير تطبيق جوال متكامل لمنصة iOS وأندرويد.", MinBudget = 2000, MaxBudget = 5000, DurationInDays = 45, ExperienceLevel = ExperienceStatusEnum.Professional, Status = JobStatusEnum.Active, ClientId = 6, CategoryId = 6 },
                new Job { Id = 7, Title = "إدارة مشروع بناء موقع", Description = "إدارة مشروع بناء موقع شركة مع تنسيق الفرق المختلفة.", MinBudget = 1200, MaxBudget = 2500, DurationInDays = 30, ExperienceLevel = ExperienceStatusEnum.Professional, Status = JobStatusEnum.Active, ClientId = 7, CategoryId = 7 },
                new Job { Id = 8, Title = "تسجيل إعلان صوتي", Description = "تسجيل إعلان صوتي بجودة عالية لإذاعته على الراديو.", MinBudget = 300, MaxBudget = 600, DurationInDays = 5, ExperienceLevel = ExperienceStatusEnum.Beginner, Status = JobStatusEnum.Active, ClientId = 8, CategoryId = 8 },
                new Job { Id = 9, Title = "استشارة في استراتيجيات الأعمال", Description = "استشارة في استراتيجيات الأعمال لتحسين أداء الشركة.", MinBudget = 800, MaxBudget = 1500, DurationInDays = 10, ExperienceLevel = ExperienceStatusEnum.Intermediate, Status = JobStatusEnum.Active, ClientId = 9, CategoryId = 9 },
                new Job { Id = 10, Title = "تصميم داخلي لمقهى", Description = "تصميم داخلي لمقهى جديد بأسلوب عصري.", MinBudget = 1500, MaxBudget = 3500, DurationInDays = 25, ExperienceLevel = ExperienceStatusEnum.Professional, Status = JobStatusEnum.Active, ClientId = 10, CategoryId = 10 }
            );

        }
    }
}