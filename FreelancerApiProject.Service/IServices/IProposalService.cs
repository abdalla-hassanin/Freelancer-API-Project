using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface IProposalService
    {
        Task<List<Proposal>> GetAllAsync();

        Task<List<Proposal>> GetAllByJobIdAsync(int jobId);

        Task<List<Proposal>> GetAllByFreelancerIdAsync(int freelancerId);
        
        Task<Proposal?> GetByIdAsync(int id);

        Task<string> CreateAsync(Proposal proposal);

        Task<string> UpdateAsync(Proposal proposal);

        Task<string> DeleteAsync(Proposal proposal);
       
        Task<string> AcceptProposalAsync(Proposal proposal);
        Task<string> RejectProposalAsync(Proposal proposal);
    }
}