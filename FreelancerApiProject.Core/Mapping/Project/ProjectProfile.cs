using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Project.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;
using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Core.Mapping.Project;

public partial class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Data.Entities.Project, GetProjectResponse>();

        CreateMap<ProjectSkills, GetSkillResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Skill.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Skill.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Skill.Description));

        CreateMap<AddProjectCommand, Data.Entities.Project>()
            .ForMember(dest => dest.Skills, opt => opt.Ignore());


    }
}