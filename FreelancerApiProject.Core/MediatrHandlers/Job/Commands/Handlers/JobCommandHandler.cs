using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Models;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Handlers
{
    public class JobCommandHandler : ResponseHandler,
                                       IRequestHandler<AddJobCommand, Response<string>>
                                        ,IRequestHandler<EditJobCommand, Response<string>>
                                       ,IRequestHandler<DeleteJobCommand, Response<string>>
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public JobCommandHandler(IJobService jobService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _jobService= jobService;
            _mapper= mapper;
            _localizer= localizer;
        }



        public async Task<Response<string>> Handle(AddJobCommand request, CancellationToken cancellationToken)
        {
            var jobMapper = _mapper.Map<Data.Entities.Job>(request);
           
            var result = await _jobService.CreateAsync(jobMapper,request.SkillsIds);
           
            return result == "Success" ? Created("") : BadRequest<string>(result);
            
        }

        public async Task<Response<string>> Handle(EditJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobService.GetByIdAsync(request.Id);
            if (job == null) return NotFound<string>("Job not found in database");
           
            // Update the job's properties
            job.Title = request.Title ?? job.Title;
            job.Description = request.Description ?? job.Description;
            job.MinBudget = request.MinBudget ?? job.MinBudget;
            job.MaxBudget = request.MaxBudget ?? job.MaxBudget;
            job.DurationInDays = request.DurationInDays ?? job.DurationInDays;
            job.ExperienceLevel = request.ExperienceLevel ?? job.ExperienceLevel;
            job.Status = request.Status ?? job.Status;
            job.ClientId = request.ClientId?? job.ClientId;
            job.CategoryId = request.CategoryId?? job.CategoryId;
           
            
            var result = await _jobService.UpdateAsync(job,request.SkillsIds);
            return result == "Success" ? Success((string)_localizer[SharedResourcesKeys.Updated]) : BadRequest<string>();
        }
        
        public async Task<Response<string>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await _jobService.GetByIdAsync(request.Id);
            if (job == null) return NotFound<string>();
            
            var result = await _jobService.DeleteAsync(job);
            return result == "Success" ? Deleted<string>() : BadRequest<string>();
        }

    }
}
