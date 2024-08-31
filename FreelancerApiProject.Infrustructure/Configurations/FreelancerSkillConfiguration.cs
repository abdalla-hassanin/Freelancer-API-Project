using FreelancerApiProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreelancerApiProject.Infrustructure.Configurations
{
    internal class FreelancerSkillConfiguration : IEntityTypeConfiguration<FreelancerSkills>
    {
        public void Configure(EntityTypeBuilder<FreelancerSkills> builder)
        {
            builder.HasKey(fs => new { fs.SkillId, fs.FreelancerId });

            builder.HasOne(fs => fs.Freelancer)
                      .WithMany(f => f.Skills)
                      .HasForeignKey(fs => fs.FreelancerId)
                      .OnDelete(DeleteBehavior.Cascade);
            


            builder.HasOne(fs => fs.Skill)
                .WithMany(s => s.Freelancers)
                .HasForeignKey(fs => fs.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasData(
                new FreelancerSkills { FreelancerId = 1, SkillId = 1 },
                new FreelancerSkills { FreelancerId = 2, SkillId = 2 },
                new FreelancerSkills { FreelancerId = 3, SkillId = 3 },
                new FreelancerSkills { FreelancerId = 4, SkillId = 4 },
                new FreelancerSkills { FreelancerId = 5, SkillId = 5 },
                new FreelancerSkills { FreelancerId = 6, SkillId = 6 },
                new FreelancerSkills { FreelancerId = 7, SkillId = 7 },
                new FreelancerSkills { FreelancerId = 8, SkillId = 8 },
                new FreelancerSkills { FreelancerId = 9, SkillId = 9 },
                new FreelancerSkills { FreelancerId = 10, SkillId = 10 }
            );

        }
    }
}