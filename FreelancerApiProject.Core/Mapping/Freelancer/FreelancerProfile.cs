using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;
using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Core.Mapping.Freelancer;

public partial class FreelancerProfile : Profile
{
    public FreelancerProfile()
    {
        CreateMap<Data.Entities.Freelancer, GetFreelancerResponse>();


        CreateMap<FreelancerSkills, GetSkillResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Skill.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Skill.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Skill.Description));

        // CreateMap<Data.Entities.Project, GetProjectResponse>();
        //
        // CreateMap<ProjectSkills, GetSkillResponse>()
        //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Skill.Id))
        //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Skill.Title))
        //     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Skill.Description));


        CreateMap<AddFreelancerCommand, Data.Entities.Freelancer>()
            .ForMember(dest => dest.Skills, opt => opt.Ignore());

    }
}