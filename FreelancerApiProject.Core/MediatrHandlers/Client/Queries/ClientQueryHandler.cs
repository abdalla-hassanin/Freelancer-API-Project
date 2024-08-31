using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Queries;

public class ClientQueryHandler:ResponseHandler,
    IRequestHandler<GetClientsQuery, Response<List<GetClientResponse>>>,
    IRequestHandler<GetClientByIdQuery, Response<GetClientResponse>>
{
    private readonly IClientService _clientService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public ClientQueryHandler(IClientService clientService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _clientService = clientService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetClientResponse>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var clients =await _clientService.GetAllAsync();
        if (clients.Count == 0)
        {
            return Success(new List<GetClientResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var clientsResponse = _mapper.Map<List<GetClientResponse>>(clients);
        return Success(clientsResponse);
    }

    public async Task<Response<GetClientResponse>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        var client =await _clientService.GetByIdAsync(request.Id);
        if (client is null)
        {
            return Success(new GetClientResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var clientResponse = _mapper.Map<GetClientResponse>(client);
        return Success(clientResponse);
    }

}