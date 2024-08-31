using AutoMapper;
using FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Models;
using FreelancerApiProject.Core.MediatrHandlers.Client.Queries;

namespace FreelancerApiProject.Core.Mapping.Client;

public partial class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Data.Entities.Client, GetClientResponse>();
        
        
        CreateMap<AddClientCommand, Data.Entities.Client>();

    }
}