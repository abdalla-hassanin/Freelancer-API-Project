using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;

namespace FreelancerApiProject.Service.IServices
{
    public interface IJobService
    {
        Task<List<Job>> GetAllAsync();

        Task<Job?> GetByIdAsync(int id);

        Task<string> CreateAsync(Job job, List<int>? skillIds);

        Task<string> UpdateAsync(Job job, List<int>? skillIds);

        Task<string> DeleteAsync(Job job);
        
        // New methods to add
        Task<List<Job>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Job>> GetAllByFreelancerIdAsync(int freelancerId);
        Task<List<Job>> GetAllByClientIdAsync(int clientId);
        Task<List<Job>> GetAllByTitleAsync(string title);
        Task<PaginatedListModel<Job>> GetAllPaginatedAsync(int pageNumber, int pageSize);

    }
}