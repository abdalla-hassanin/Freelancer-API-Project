using FreelancerApiProject.Data.Entities;
using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;

namespace FreelancerApiProject.Infrustructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context) { }

    }
}
