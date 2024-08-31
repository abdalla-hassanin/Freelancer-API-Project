using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface ISkillService 
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(int id);
    }
}
