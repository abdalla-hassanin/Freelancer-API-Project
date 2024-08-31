using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Category.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Category.Queries;

namespace FreelancerApiProject.Core.Mapping.Category;

public partial class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Data.Entities.Category, GetCategoryResponse>()
            .ForMember(dest => dest.JobsUseThisCategory, opt => opt.MapFrom(src => src.Jobs.Count));
        //
        // CreateMap<CategorySkills, GetSkillResponse>()
        //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Skill.Id))
        //     .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Skill.Title))
        //     .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Skill.Description));

        CreateMap<AddCategoryCommand, Data.Entities.Category>();


    }
}