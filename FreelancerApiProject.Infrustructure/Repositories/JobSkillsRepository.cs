using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class JobSkillsRepository : GenericRepository<JobSkills> , IJobSkillsRepository
    {
        public JobSkillsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
