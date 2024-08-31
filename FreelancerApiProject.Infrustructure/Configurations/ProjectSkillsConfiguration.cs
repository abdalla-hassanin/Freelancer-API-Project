using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class ProjetSkillsConfiguration : IEntityTypeConfiguration<ProjectSkills>
    {
        public void Configure(EntityTypeBuilder<ProjectSkills> builder)
        {

            builder.HasKey(e => new { e.SkillId, Project1Id = e.ProjectId });

            builder.HasOne(ps => ps.Project)
                      .WithMany(p => p.Skills)
                      .HasForeignKey(ps => ps.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ps => ps.Skill)
                .WithMany(s => s.Projects)
                .HasForeignKey(ps => ps.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasData(
                new ProjectSkills { ProjectId = 1, SkillId = 1 },
                new ProjectSkills { ProjectId = 2, SkillId = 2 },
                new ProjectSkills { ProjectId = 3, SkillId = 3 },
                new ProjectSkills { ProjectId = 4, SkillId = 4 },
                new ProjectSkills { ProjectId = 5, SkillId = 5 },
                new ProjectSkills { ProjectId = 6, SkillId = 6 },
                new ProjectSkills { ProjectId = 7, SkillId = 7 },
                new ProjectSkills { ProjectId = 8, SkillId = 8 },
                new ProjectSkills { ProjectId = 9, SkillId = 9 },
                new ProjectSkills { ProjectId = 10, SkillId = 10 }
            );

        }
    }
}
