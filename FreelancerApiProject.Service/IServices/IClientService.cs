using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();

        Task<Client?> GetByIdAsync(int id);

        Task<string> CreateAsync(Client client);

        Task<string> UpdateAsync(Client client);

        Task<string> DeleteAsync(Client client);
    }
}