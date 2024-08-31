using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Data.Enums;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Price)
                      .HasColumnType("Money");

                builder.Property(p => p.Status)
                      .HasDefaultValue(ProposalStatusEnum.Waiting);

                builder.HasOne(p => p.Freelancer)
                      .WithMany(f => f.Proposals)
                      .HasForeignKey(p => p.FreelancerId);

                builder.HasOne(p => p.Job)
                      .WithMany(j => j.Proposals)
                      .HasForeignKey(p => p.JobId);


            builder.HasData(
                new Proposal { Id = 1, DeadLine = DateTime.Now.AddDays(10), Duration = 10, Price = 200, Status = ProposalStatusEnum.Waiting, FreelancerId = 1, JobId = 1, Description = "عرض لتصميم شعار مبتكر." },
                new Proposal { Id = 2, DeadLine = DateTime.Now.AddDays(20), Duration = 15, Price = 1500, Status = ProposalStatusEnum.Waiting, FreelancerId = 2, JobId = 2, Description = "عرض لتطوير موقع تجارة إلكترونية بميزات حديثة." },
                new Proposal { Id = 3, DeadLine = DateTime.Now.AddDays(7), Duration = 7, Price = 400, Status = ProposalStatusEnum.Waiting, FreelancerId = 3, JobId = 3, Description = "عرض لكتابة مقالات تقنية بجودة عالية." },
                new Proposal { Id = 4, DeadLine = DateTime.Now.AddDays(15), Duration = 15, Price = 800, Status = ProposalStatusEnum.Waiting, FreelancerId = 4, JobId = 4, Description = "عرض لتحليل بيانات السوق بدقة." },
                new Proposal { Id = 5, DeadLine = DateTime.Now.AddDays(20), Duration = 20, Price = 1200, Status = ProposalStatusEnum.Waiting, FreelancerId = 5, JobId = 5, Description = "عرض لإدارة حملة تسويقية فعالة." },
                new Proposal { Id = 6, DeadLine = DateTime.Now.AddDays(45), Duration = 40, Price = 3000, Status = ProposalStatusEnum.Waiting, FreelancerId = 6, JobId = 6, Description = "عرض لتطوير تطبيق جوال بميزات متقدمة." },
                new Proposal { Id = 7, DeadLine = DateTime.Now.AddDays(30), Duration = 25, Price = 2000, Status = ProposalStatusEnum.Waiting, FreelancerId = 7, JobId = 7, Description = "عرض لإدارة مشروع بناء موقع ويب." },
                new Proposal { Id = 8, DeadLine = DateTime.Now.AddDays(5), Duration = 3, Price = 400, Status = ProposalStatusEnum.Waiting, FreelancerId = 8, JobId = 8, Description = "عرض لتسجيل إعلان صوتي بجودة احترافية." },
                new Proposal { Id = 9, DeadLine = DateTime.Now.AddDays(10), Duration = 10, Price = 1000, Status = ProposalStatusEnum.Waiting, FreelancerId = 9, JobId = 9, Description = "عرض لتقديم استشارة في استراتيجيات الأعمال." },
                new Proposal { Id = 10, DeadLine = DateTime.Now.AddDays(25), Duration = 20, Price = 2500, Status = ProposalStatusEnum.Waiting, FreelancerId = 10, JobId = 10, Description = "عرض لتصميم داخلي لمقهى بأسلوب عصري." }
            );

        }
    }
}
