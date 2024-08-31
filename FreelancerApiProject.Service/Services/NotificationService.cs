using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Service.IServices;

namespace FreelancerApiProject.Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Notification>> GetByFreelancerId(int freelancerId)
        {
            var notifications = await _unitOfWork.NotificationRepository
                .FindAllAsync(criteria: n => n.FreelancerId == freelancerId);

            return notifications.OrderByDescending(n => n.SentTime)
                .ToList();
        }


        public async Task<List<Notification>> GetByClientId(int clientId)
        {
            var notifications = await _unitOfWork.NotificationRepository
                .FindAllAsync(criteria: n => n.ClientId == clientId);

            return notifications.OrderByDescending(n => n.SentTime)
                .ToList();
        }
    }
}