using FreelancerApiProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
    {
        public void Configure(EntityTypeBuilder<Freelancer> builder)
        {

            builder.Property(f => f.Name).IsRequired().HasMaxLength(50);
            builder.Property(f => f.Title).IsRequired(false).HasMaxLength(50);
            builder.Property(f => f.Address).IsRequired(false).HasMaxLength(50);
            builder.Property(f => f.Overview).IsRequired(false).HasMaxLength(500);

            // Relationships
            builder.HasMany(f => f.WorkingHistory)
                .WithOne(j => j.AcceptedFreelancer)
                .HasForeignKey(j => j.AcceptedFreelancerId);
            
            builder.HasMany(f => f.Notifications)
                .WithOne(n => n.Freelancer)
                .HasForeignKey(n => n.FreelancerId);


            builder.HasMany(f => f.Skills)
                .WithOne(fs => fs.Freelancer)
                .HasForeignKey(fs => fs.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            // Seed initial data
            builder.HasData(
                new Freelancer
                {
                    Id = 1, Name = "يوسف أحمد", Title = "مطور ويب", Address = "شارع التكنولوجيا، الرياض",
                    Overview = "لدي خبرة 5 سنوات في تطوير الويب باستخدام .NET وJavaScript.",
                    PersonalImage = "yousef_ahmed.jpg"
                },
                new Freelancer
                {
                    Id = 2, Name = "فاطمة خالد", Title = "مصممة جرافيك", Address = "شارع الفن، جدة",
                    Overview = "متخصصة في تصميم الشعارات والهويات البصرية.", PersonalImage = "fatima_khalid.jpg"
                },
                new Freelancer
                {
                    Id = 3, Name = "عمر محمود", Title = "مترجم محترف", Address = "شارع اللغات، القاهرة",
                    Overview = "خبرة 10 سنوات في الترجمة من وإلى العربية والإنجليزية.",
                    PersonalImage = "omar_mahmoud.jpg"
                },
                new Freelancer
                {
                    Id = 4, Name = "سارة علي", Title = "محللة بيانات", Address = "شارع الأعمال، دبي",
                    Overview = "خبيرة في تحليل البيانات باستخدام Excel وPython.", PersonalImage = "sara_ali.jpg"
                },
                new Freelancer
                {
                    Id = 5, Name = "أحمد سليمان", Title = "خبير تسويق رقمي", Address = "شارع التسويق، بيروت",
                    Overview = "محترف في إدارة الحملات الإعلانية الرقمية على وسائل التواصل الاجتماعي.",
                    PersonalImage = "ahmed_suleiman.jpg"
                },
                new Freelancer
                {
                    Id = 6, Name = "سلمى نور", Title = "مطور تطبيقات", Address = "شارع البرمجة، الكويت",
                    Overview = "متخصصة في تطوير تطبيقات الهواتف الذكية لنظامي iOS وAndroid.",
                    PersonalImage = "salma_noor.jpg"
                },
                new Freelancer
                {
                    Id = 7, Name = "زياد عبد الله", Title = "مدير مشاريع", Address = "شارع الإدارة، الدوحة",
                    Overview = "مدير مشاريع معتمد مع خبرة في إدارة المشاريع التقنية.",
                    PersonalImage = "ziad_abdullah.jpg"
                },
                new Freelancer
                {
                    Id = 8, Name = "هدى ياسين", Title = "معلقة صوتية", Address = "شارع الصوت، المنامة",
                    Overview = "لدي صوت مميز وخبرة في التسجيل الصوتي للإعلانات.", PersonalImage = "huda_yaseen.jpg"
                },
                new Freelancer
                {
                    Id = 9, Name = "مريم صالح", Title = "مستشارة أعمال", Address = "شارع الاستشارات، مسقط",
                    Overview = "أقدم استشارات في مجال إدارة الأعمال وتطوير الشركات.", PersonalImage = "maryam_saleh.jpg"
                },
                new Freelancer
                {
                    Id = 10, Name = "خالد حسن", Title = "مصمم داخلي", Address = "شارع التصميم، الرباط",
                    Overview = "محترف في تصميم الديكور الداخلي للمنازل والمكاتب.", PersonalImage = "khaled_hassan.jpg"
                }
            );
        }
    }
}