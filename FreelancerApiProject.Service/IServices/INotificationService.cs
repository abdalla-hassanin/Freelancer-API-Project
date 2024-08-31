using FreelancerApiProject.Data.Entities;

namespace FreelancerApiProject.Service.IServices
{
    public interface INotificationService
    {
        Task<List<Notification>> GetByFreelancerId(int freelancerId);
        Task<List<Notification>> GetByClientId(int clientId);

    }
}
