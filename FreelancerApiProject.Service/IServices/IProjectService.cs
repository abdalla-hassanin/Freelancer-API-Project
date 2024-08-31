using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<List<Project>> GetAllByFreelancerIdAsync(int freelancerId);

        Task<Project?> GetByIdAsync(int id);

        Task<string> CreateAsync(Project project, List<int>? requestSkillIDs);

        Task<string> UpdateAsync(Project project, List<int>? requestSkillIDs);

        Task<string> DeleteAsync(Project project);
    }
}