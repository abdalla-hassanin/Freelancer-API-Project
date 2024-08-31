using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;

public class GetSkillsQuery: IRequest<Response<List<GetSkillResponse>>>
{
    
}