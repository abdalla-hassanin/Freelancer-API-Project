using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Models;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Handlers
{
    public class ClientCommandHandler : ResponseHandler,
                                       IRequestHandler<AddClientCommand, Response<string>>
                                        ,IRequestHandler<EditClientCommand, Response<string>>
                                       ,IRequestHandler<DeleteClientCommand, Response<string>>
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ClientCommandHandler(IClientService clientService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _clientService= clientService;
            _mapper= mapper;
            _localizer= localizer;
        }



        public async Task<Response<string>> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var clientMapper = _mapper.Map<Data.Entities.Client>(request);
           
            var result = await _clientService.CreateAsync(clientMapper);
           
            return result == "Success" ? Created("") : BadRequest<string>(result);
            
        }

        public async Task<Response<string>> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientService.GetByIdAsync(request.Id);
            if (client == null) return NotFound<string>("client not found in database");
           
            // Update the client's properties
            client.Name = request.Name ?? client.Name;
            client.Description = request.Description ?? client.Description;
            client.Image = request.Image ?? client.Image;
            client.Country = request.Country ?? client.Country;
            client.Phone = request.Phone ?? client.Phone;
           
            
            var result = await _clientService.UpdateAsync(client);
            return result == "Success" ? Success((string)_localizer[SharedResourcesKeys.Updated]) : BadRequest<string>();
        }
        
        public async Task<Response<string>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientService.GetByIdAsync(request.Id);
            if (client == null) return NotFound<string>();
            
            var result = await _clientService.DeleteAsync(client);
            return result == "Success" ? Deleted<string>() : BadRequest<string>();
        }

    }
}
