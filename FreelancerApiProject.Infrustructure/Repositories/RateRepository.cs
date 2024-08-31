using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class RateRepository : GenericRepository<Rate> , IRateRepository
    {
        public RateRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
