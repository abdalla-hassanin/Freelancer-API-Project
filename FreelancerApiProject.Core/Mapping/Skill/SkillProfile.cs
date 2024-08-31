using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;

namespace FreelancerApiProject.Core.Mapping.Skill;

public partial class SkillProfile:Profile
{
    public SkillProfile()
    {
        CreateMap<Data.Entities.Skill, GetSkillResponse>();
    }
    
}
