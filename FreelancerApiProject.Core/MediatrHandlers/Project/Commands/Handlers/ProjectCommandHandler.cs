using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Models;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Handlers
{
    public class ProjectCommandHandler : ResponseHandler,
                                       IRequestHandler<AddProjectCommand, Response<string>>
                                        ,IRequestHandler<EditProjectCommand, Response<string>>
                                       ,IRequestHandler<DeleteProjectCommand, Response<string>>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ProjectCommandHandler(IProjectService projectService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _projectService= projectService;
            _mapper= mapper;
            _localizer= localizer;
        }



        public async Task<Response<string>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
        {
            var projectMapper = _mapper.Map<Data.Entities.Project>(request);
           
            var result = await _projectService.CreateAsync(projectMapper,request.SkillIds);
           
            return result == "Success" ? Created("") : BadRequest<string>(result);
            
        }

        public async Task<Response<string>> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectService.GetByIdAsync(request.Id);
            if (project == null) return NotFound<string>("Project not found in database");
            
            // Update the project's properties
            project.Title = request.Title ?? project.Title;
            project.Description = request.Description ?? project.Description;
            project.Link = request.Link ?? project.Link;
            project.Poster = request.Poster ?? project.Poster;
            project.Images = request.Images ?? project.Images;
            project.TimePublished = request.TimePublished ?? project.TimePublished;
            
            var result = await _projectService.UpdateAsync(project,request.SkillIds);
            return result == "Success" ? Success((string)_localizer[SharedResourcesKeys.Updated]) : BadRequest<string>();
        }
        
        public async Task<Response<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectService.GetByIdAsync(request.Id);
            if (project == null) return NotFound<string>();
            
            var result = await _projectService.DeleteAsync(project);
            return result == "Success" ? Deleted<string>() : BadRequest<string>();
        }

    }
}
