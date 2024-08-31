using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class FreelancerRepository : GenericRepository<Freelancer> , IFreelancerRepository
    {
        public FreelancerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
