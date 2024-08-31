using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired(false).HasMaxLength(100);
            builder.Property(p => p.Link).IsRequired(false).HasMaxLength(150);

            builder.HasOne(p => p.Freelancer)
                     .WithMany(f => f.Portfolio)
                     .HasForeignKey(p => p.FreelancerId);

            builder.HasData(
                new Project { Id = 1, Title = "مشروع ويب متكامل", Description = "تصميم وتطوير موقع ويب متكامل باستخدام أحدث التقنيات.", Poster = "web_project.png", FreelancerId = 1, TimePublished = DateTime.Now, Link = "https://example.com/web_project", Images = new List<string> { "web1.png", "web2.png" } },
                new Project { Id = 2, Title = "شعار إبداعي", Description = "تصميم شعار مبتكر لشركة ناشئة.", Poster = "creative_logo.png", FreelancerId = 2, TimePublished = DateTime.Now, Link = "https://example.com/logo", Images = new List<string> { "logo1.png", "logo2.png" } },
                new Project { Id = 3, Title = "مقالات تقنية", Description = "كتابة مجموعة مقالات تقنية لموقع ويب.", Poster = "tech_articles.png", FreelancerId = 3, TimePublished = DateTime.Now, Link = "https://example.com/articles", Images = new List<string> { "article1.png", "article2.png" } },
                new Project { Id = 4, Title = "تحليل بيانات المبيعات", Description = "تحليل بيانات مبيعات شركة خلال العام الماضي.", Poster = "sales_analysis.png", FreelancerId = 4, TimePublished = DateTime.Now, Link = "https://example.com/analysis", Images = new List<string> { "analysis1.png", "analysis2.png" } },
                new Project { Id = 5, Title = "إدارة حملة إعلانية", Description = "إدارة حملة إعلانية لمتجر إلكتروني.", Poster = "ad_campaign.png", FreelancerId = 5, TimePublished = DateTime.Now, Link = "https://example.com/campaign", Images = new List<string> { "campaign1.png", "campaign2.png" } },
                new Project { Id = 6, Title = "تطبيق جوال", Description = "تطوير تطبيق جوال لتتبع اللياقة البدنية.", Poster = "mobile_app.png", FreelancerId = 6, TimePublished = DateTime.Now, Link = "https://example.com/app", Images = new List<string> { "app1.png", "app2.png" } },
                new Project { Id = 7, Title = "إدارة مشروع بناء", Description = "إدارة مشروع بناء موقع إلكتروني.", Poster = "project_management.png", FreelancerId = 7, TimePublished = DateTime.Now, Link = "https://example.com/project", Images = new List<string> { "project1.png", "project2.png" } },
                new Project { Id = 8, Title = "تسجيل صوتي", Description = "تسجيل صوتي لإعلان إذاعي.", Poster = "audio_recording.png", FreelancerId = 8, TimePublished = DateTime.Now, Link = "https://example.com/audio", Images = new List<string> { "audio1.png", "audio2.png" } },
                new Project { Id = 9, Title = "استشارة أعمال", Description = "تقديم استشارات أعمال لشركة صغيرة.", Poster = "business_consulting.png", FreelancerId = 9, TimePublished = DateTime.Now, Link = "https://example.com/consulting", Images = new List<string> { "consulting1.png", "consulting2.png" } },
                new Project { Id = 10, Title = "تصميم داخلي لمقهى", Description = "تصميم داخلي لمقهى بأسلوب عصري.", Poster = "interior_design.png", FreelancerId = 10, TimePublished = DateTime.Now, Link = "https://example.com/design", Images = new List<string> { "design1.png", "design2.png" } }
            );
        
        }
    }
}
