using FreelancerApiProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class JobSkillsConfiguration : IEntityTypeConfiguration<JobSkills>
    {
        public void Configure(EntityTypeBuilder<JobSkills> builder)
        {
            builder.HasKey(js => new { js.JobId, js.SkillId });

            builder.HasOne(js => js.Job)
                .WithMany(j => j.Skills)
                .HasForeignKey(js => js.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(js => js.Skill)
                .WithMany(s => s.Jobs)
                .HasForeignKey(js => js.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new JobSkills { JobId = 1, SkillId = 1 },
                new JobSkills { JobId = 2, SkillId = 2 },
                new JobSkills { JobId = 3, SkillId = 3 },
                new JobSkills { JobId = 4, SkillId = 4 },
                new JobSkills { JobId = 5, SkillId = 5 },
                new JobSkills { JobId = 6, SkillId = 6 },
                new JobSkills { JobId = 7, SkillId = 7 },
                new JobSkills { JobId = 8, SkillId = 8 },
                new JobSkills { JobId = 9, SkillId = 9 },
                new JobSkills { JobId = 10, SkillId = 10 }
            );

        }
    }
}