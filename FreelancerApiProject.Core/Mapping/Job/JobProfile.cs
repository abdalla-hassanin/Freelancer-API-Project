using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Job.Queries;
using FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;
using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Core.Mapping.Job;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Data.Entities.Job, GetJobResponse>()
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
            .ForMember(dest => dest.AcceptedFreelancerName,
                opt => opt.MapFrom(src => src.AcceptedFreelancer != null ? src.AcceptedFreelancer.Name : null))
            .ForMember(dest => dest.CategoryTitle,
                opt => opt.MapFrom(src => src.Category != null ? src.Category.Title : null));

        
        CreateMap<JobSkills, GetSkillResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Skill.Id))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Skill.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Skill.Description));

        CreateMap<AddJobCommand, Data.Entities.Job>();
    }
}