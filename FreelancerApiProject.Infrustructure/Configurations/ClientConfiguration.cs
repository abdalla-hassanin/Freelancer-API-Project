using FreelancerApiProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50)
                         .IsRequired();

            builder.Property(c => c.RegistrationTime)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.Property(c => c.Country)
                .HasMaxLength(100);

            builder.Property(c => c.Phone)
                .HasMaxLength(20);

            // Relationships
            builder.HasMany(c => c.Jobs)
                .WithOne(j => j.Client)
                .HasForeignKey(j => j.ClientId);

            builder.HasMany(c => c.Notifications)
                      .WithOne(n => n.Client)
                      .HasForeignKey(n => n.ClientId);

            // Seed initial data
            builder.HasData(
                new Client { Id = 1, Name = "محمد علي", Description = "مستثمر في مجال التكنولوجيا.", Image = "mohamed_ali.jpg", Country = "مصر", Phone = "0123456789", RegistrationTime = DateTime.Now },
                new Client { Id = 2, Name = "علياء سالم", Description = "كاتبة ومحررة.", Image = "alia_salem.jpg", Country = "السعودية", Phone = "0987654321", RegistrationTime = DateTime.Now },
                new Client { Id = 3, Name = "خالد يوسف", Description = "مدير شركة ناشئة.", Image = "khaled_youssef.jpg", Country = "الإمارات", Phone = "0123498765", RegistrationTime = DateTime.Now },
                new Client { Id = 4, Name = "ليلى أحمد", Description = "مصممة جرافيك.", Image = "laila_ahmed.jpg", Country = "الأردن", Phone = "0987123456", RegistrationTime = DateTime.Now },
                new Client { Id = 5, Name = "سامي حسن", Description = "خبير في التسويق الرقمي.", Image = "sami_hassan.jpg", Country = "لبنان", Phone = "0123987654", RegistrationTime = DateTime.Now },
                new Client { Id = 6, Name = "نورة عبد الرحمن", Description = "مستشارة أعمال.", Image = "noura_abdelrahman.jpg", Country = "الكويت", Phone = "0987123450", RegistrationTime = DateTime.Now },
                new Client { Id = 7, Name = "فيصل بن سعيد", Description = "محلل بيانات.", Image = "faisal_bin_saeed.jpg", Country = "قطر", Phone = "0123450987", RegistrationTime = DateTime.Now },
                new Client { Id = 8, Name = "حسين محمد", Description = "مدير مشاريع.", Image = "hussein_mohamed.jpg", Country = "البحرين", Phone = "0987650123", RegistrationTime = DateTime.Now },
                new Client { Id = 9, Name = "منى إبراهيم", Description = "كاتبة ومؤلفة.", Image = "mona_ibrahim.jpg", Country = "عمان", Phone = "0123987456", RegistrationTime = DateTime.Now },
                new Client { Id = 10, Name = "طارق عبد الله", Description = "مطور ويب.", Image = "tarek_abdullah.jpg", Country = "المغرب", Phone = "0987345612", RegistrationTime = DateTime.Now }

                );
        }
    }
}