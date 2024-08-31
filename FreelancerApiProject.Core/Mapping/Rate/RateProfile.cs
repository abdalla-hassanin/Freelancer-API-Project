using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Queries;

namespace FreelancerApiProject.Core.Mapping.Rate;

public partial class RateProfile : Profile
{
    public RateProfile()
    {
        CreateMap<Data.Entities.Rate, GetRateResponse>();
        CreateMap<AddRateCommand, Data.Entities.Rate>();
        CreateMap<EditRateCommand, Data.Entities.Rate>();
    }
}