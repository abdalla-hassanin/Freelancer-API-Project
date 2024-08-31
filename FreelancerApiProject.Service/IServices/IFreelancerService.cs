using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface IFreelancerService
    {
        Task<List<Freelancer>> GetAllAsync();

        Task<Freelancer?> GetByIdAsync(int id);

        Task<string> CreateAsync(Freelancer freelancer,List<int>? requestSkillIds=null);

        Task<string> UpdateAsync(Freelancer freelancer,List<int>? requestSkillIds);

        Task<string> DeleteAsync(Freelancer freelancer);
    }
}