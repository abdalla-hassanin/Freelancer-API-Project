using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;

namespace FreelancerApiProject.Infrustructure.IRepositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Client? GetClientWithJobs(int id);
    }
}