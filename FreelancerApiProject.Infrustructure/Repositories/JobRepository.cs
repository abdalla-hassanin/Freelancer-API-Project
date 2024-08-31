using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}