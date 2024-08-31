using FreelancerApiProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(500);
            // Relationships
            builder.HasMany(c => c.Jobs)
                .WithOne(j => j.Category)
                .HasForeignKey(j => j.CategoryId);

            builder.HasData(
                new Category { Id = 1, Title = "تصميم جرافيك", Description = "خدمات تصميم شعارات وبوسترات وغيرها" },
                new Category { Id = 2, Title = "تطوير مواقع", Description = "تطوير مواقع ويب باستخدام تقنيات مختلفة" },
                new Category { Id = 3, Title = "كتابة وترجمة", Description = "خدمات كتابة وترجمة المقالات والمحتويات" },
                new Category { Id = 4, Title = "تحليل البيانات", Description = "خدمات تحليل البيانات والاستشارات" },
                new Category { Id = 5, Title = "تسويق رقمي", Description = "خدمات التسويق الرقمي والترويج" },
                new Category { Id = 6, Title = "تطوير تطبيقات", Description = "تطوير تطبيقات الهواتف الذكية" },
                new Category { Id = 7, Title = "إدارة مشاريع", Description = "خدمات إدارة المشاريع والتخطيط" },
                new Category { Id = 8, Title = "خدمات صوتية", Description = "تسجيل صوتي ومونتاج" },
                new Category { Id = 9, Title = "استشارات أعمال", Description = "تقديم استشارات في مجال الأعمال" },
                new Category { Id = 10, Title = "التصميم الداخلي", Description = "خدمات تصميم داخلي وديكور" }
            );
        }
    }
}