using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;

public class SkillQueryHandler:ResponseHandler,
    IRequestHandler<GetSkillsQuery, Response<List<GetSkillResponse>>>,
    IRequestHandler<GetSkillByIdQuery, Response<GetSkillResponse>>
{
    private readonly ISkillService _skillService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public SkillQueryHandler(ISkillService skillService,
        IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
    {
      
        _skillService = skillService;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<Response<List<GetSkillResponse>>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills =await _skillService.GetAllAsync();
        if (skills.Count == 0)
        {
            return Success(new List<GetSkillResponse>(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var skillsResponse = _mapper.Map<List<GetSkillResponse>>(skills);
        return Success(skillsResponse);
    }

    public async Task<Response<GetSkillResponse>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill =await _skillService.GetByIdAsync(request.Id);
        if (skill is null)
        {
            return Success(new GetSkillResponse(), _stringLocalizer[SharedResourcesKeys.NoDataYet]);
        }
        var skillResponse = _mapper.Map<GetSkillResponse>(skill);
        return Success(skillResponse);
    }
}