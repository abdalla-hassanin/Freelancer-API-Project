using FreelancerApiProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(s => s.Title).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Description).IsRequired(false).HasMaxLength(100);

            builder.HasData(
                new List<Skill>()
                {
                    new Skill { Id = 1, Title = "التصميم الجرافيكي", Description = "مهارات في تصميم الشعارات، البوسترات، والمواد البصرية." },
                    new Skill { Id = 2, Title = "تطوير الويب", Description = "مهارات في تطوير مواقع الويب باستخدام HTML، CSS، JavaScript، و .NET." },
                    new Skill { Id = 3, Title = "الكتابة الإبداعية", Description = "مهارات في كتابة المحتوى الإبداعي والمقالات." },
                    new Skill { Id = 4, Title = "تحليل البيانات", Description = "مهارات في تحليل البيانات باستخدام Excel وPython." },
                    new Skill { Id = 5, Title = "التسويق الرقمي", Description = "مهارات في إدارة الحملات التسويقية على وسائل التواصل الاجتماعي." },
                    new Skill { Id = 6, Title = "تطوير التطبيقات", Description = "مهارات في تطوير تطبيقات الهواتف الذكية لنظامي iOS وAndroid." },
                    new Skill { Id = 7, Title = "إدارة المشاريع", Description = "مهارات في إدارة المشاريع وتنسيق الفرق." },
                    new Skill { Id = 8, Title = "التعليق الصوتي", Description = "مهارات في التعليق الصوتي والتسجيل الإذاعي." },
                    new Skill { Id = 9, Title = "الاستشارات الإدارية", Description = "مهارات في تقديم الاستشارات الإدارية وتطوير الأعمال." },
                    new Skill { Id = 10, Title = "التصميم الداخلي", Description = "مهارات في تصميم الديكور الداخلي للمنازل والمكاتب." }
                }
                );
        }
    }
}
