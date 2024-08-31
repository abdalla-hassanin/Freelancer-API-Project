using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Models;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Handlers
{
    public class FreelancerCommandHandler : ResponseHandler,
                                       IRequestHandler<AddFreelancerCommand, Response<string>>
                                        ,IRequestHandler<EditFreelancerCommand, Response<string>>
                                       ,IRequestHandler<DeleteFreelancerCommand, Response<string>>
    {
        private readonly IFreelancerService _freelancerService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public FreelancerCommandHandler(IFreelancerService freelancerService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _freelancerService= freelancerService;
            _mapper= mapper;
            _localizer= localizer;
        }



        public async Task<Response<string>> Handle(AddFreelancerCommand request, CancellationToken cancellationToken)
        {
            var freelancerMapper = _mapper.Map<Data.Entities.Freelancer>(request);
           
            var result = await _freelancerService.CreateAsync(freelancerMapper,request.SkillIds);
           
            return result == "Success" ? Created("") : BadRequest<string>(result);
            
        }

        public async Task<Response<string>> Handle(EditFreelancerCommand request, CancellationToken cancellationToken)
        {
            var freelancer = await _freelancerService.GetByIdAsync(request.Id);
            if (freelancer == null) return NotFound<string>("Freelancer not found in database");
            
            // Update the freelancer's properties
            freelancer.Title = request.Title ?? freelancer.Title;
            freelancer.Overview = request.Overview ?? freelancer.Overview;
            freelancer.Address = request.Address ?? freelancer.Address;
            freelancer.Name = request.Name ?? freelancer.Name;
            freelancer.PersonalImage = request.PersonalImage ?? freelancer.PersonalImage;
            
           
            
            var result = await _freelancerService.UpdateAsync(freelancer,request.SkillIds);
            return result == "Success" ? Success((string)_localizer[SharedResourcesKeys.Updated]) : BadRequest<string>();
        }
        
        public async Task<Response<string>> Handle(DeleteFreelancerCommand request, CancellationToken cancellationToken)
        {
            var freelancer = await _freelancerService.GetByIdAsync(request.Id);
            if (freelancer == null) return NotFound<string>();
            
            var result = await _freelancerService.DeleteAsync(freelancer);
            return result == "Success" ? Deleted<string>() : BadRequest<string>();
        }

    }
}
