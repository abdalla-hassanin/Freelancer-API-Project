using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class ProposalRepository : GenericRepository<Proposal> , IProposalRepository
    {
        public ProposalRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}