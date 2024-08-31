using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project> , IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
