using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Handlers
{
    public class RateCommandHandler : ResponseHandler,
                                       IRequestHandler<AddRateCommand, Response<string>>,
                                       IRequestHandler<EditRateCommand, Response<string>>,
                                       IRequestHandler<DeleteRateCommand, Response<string>>
    {
        private readonly IRateService _rateService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public RateCommandHandler(IRateService rateService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _rateService= rateService;
            _mapper= mapper;
            _localizer= localizer;
        }



        public async Task<Response<string>> Handle(AddRateCommand request, CancellationToken cancellationToken)
        {
            var rateMapper = _mapper.Map<Data.Entities.Rate>(request);
           
            var result = await _rateService.CreateRate(rateMapper);
           
            return result == "Success" ? Created("") : BadRequest<string>(result);
            
        }

        public async Task<Response<string>> Handle(EditRateCommand request, CancellationToken cancellationToken)
        {
            var rate = await _rateService.GetById(request.Id);
            if (rate == null) return NotFound<string>("Rate not found in database");
            
            rate.Feedback = request.Feedback??rate.Feedback;
            rate.Value = request.Value??rate.Value;
            rate.JobId = request.JobId??rate.JobId;
        //    var rateMapper = _mapper.Map<Data.Entities.Rate>(request);
            var result = await _rateService.UpdateRate(rate);
            return result == "Success" ? Success((string)_localizer[SharedResourcesKeys.Updated]) : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteRateCommand request, CancellationToken cancellationToken)
        {
            var rate = await _rateService.GetById(request.Id);
            if (rate == null) return NotFound<string>();
            
            var result = await _rateService.DeleteRate(rate);
            return result == "Success" ? Deleted<string>() : BadRequest<string>();
        }

    }
}
