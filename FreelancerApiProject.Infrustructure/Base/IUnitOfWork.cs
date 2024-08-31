using FreelancerApiProject.Infrustructure.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace FreelancerApiProject.Infrustructure.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IFreelancerRepository FreelancerRepository { get; }
        //IFreelancerNotificationRepository freelancerNotificationRepository { get; }
        IFreelancerSkillsRepository FreelancerSkillsRepository { get; }
        // TRepository GetRepository<TRepository>() where TRepository : class;
        ICategoryRepository CategoryRepository { get; }

        IClientRepository ClientRepository { get; }
        INotificationRepository NotificationRepository { get; }

        IJobRepository JobRepository { get; }
        IJobSkillsRepository JobSkillsRepository { get; }

        IProjectRepository ProjectRepository { get; }
        IProjectSkillsRepository ProjectSkillsRepository { get; }

        IProposalRepository ProposalRepository { get; }

        ISkillRepository SkillRepository { get; }

        IRateRepository RateRepository { get; }

        public IApplicationUserRepository ApplicationUserRepository { get; }


        //------------------------------------------------------

        public int Save();

        public  Task<int> SaveAsync();

        void BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();

        void Commit();

        void Rollback();
    }
}