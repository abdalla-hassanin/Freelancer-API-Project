using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly DbSet<Client> _client;
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            _client = context.Set<Client>();
        }

        public Client ? GetClientWithJobs(int id)
        {
            return _client
                .Include(x => x.Jobs)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
