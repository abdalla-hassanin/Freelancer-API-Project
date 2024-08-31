using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class ProjectSkillsRepository : GenericRepository<ProjectSkills> , IProjectSkillsRepository
    {
        public ProjectSkillsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
