using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
