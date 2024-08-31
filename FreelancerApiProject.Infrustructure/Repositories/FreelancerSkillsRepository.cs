using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class FreelancerSkillsRepository : GenericRepository<FreelancerSkills>, IFreelancerSkillsRepository
    {
        public FreelancerSkillsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
