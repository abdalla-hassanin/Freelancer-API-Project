using FreelancerApiProject.Core.Base.Response;
using MediatR;

namespace FreelancerApiProject.Core.MediatrHandlers.Skill.Queries;

public class GetSkillByIdQuery: IRequest<Response<GetSkillResponse>>
{
    public int Id { get; set; }

    public GetSkillByIdQuery(int id)
    {
        Id = id;
    }
}
