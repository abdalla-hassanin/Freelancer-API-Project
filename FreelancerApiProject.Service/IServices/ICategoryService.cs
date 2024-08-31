using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<string> CreateAsync(Category category);

        Task<string> UpdateAsync(Category category);

        Task<string> DeleteAsync(Category category);
    }
}