using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Queries;

public class ProjectQueryHandler:ResponseHandler,
    IRequestHandler<GetProjectsQuery, Response<List<GetProjectResponse>>>,
    IRequestHandler<GetProjectsByFreelancerIdQuery, Response<List<GetProjectResponse>>>,
    IRequestHandler<GetProjectByIdQuery, Response<GetProjectResponse>>
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public ProjectQueryHandler(IProjectService projectService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
        _projectService = projectService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetProjectResponse>>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects =await _projectService.GetAllAsync();
        if (projects.Count == 0)
        {
            return Success(new List<GetProjectResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var projectsResponse = _mapper.Map<List<GetProjectResponse>>(projects);
        return Success(projectsResponse);
    }

    public async Task<Response<GetProjectResponse>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project =await _projectService.GetByIdAsync(request.Id);
        if (project is null)
        {
            return Success(new GetProjectResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var projectResponse = _mapper.Map<GetProjectResponse>(project);
        return Success(projectResponse);
    }

    public async Task<Response<List<GetProjectResponse>>> Handle(GetProjectsByFreelancerIdQuery request, CancellationToken cancellationToken)
    {
        var projects =await _projectService.GetAllByFreelancerIdAsync(request.FreelancerId);
        if (projects.Count == 0)
        {
            return Success(new List<GetProjectResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var projectsResponse = _mapper.Map<List<GetProjectResponse>>(projects);
        return Success(projectsResponse);
    }
}