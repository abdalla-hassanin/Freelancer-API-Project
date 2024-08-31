using FreelancerApiProject.Infrustructure.Context;
using FreelancerApiProject.Infrustructure.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace FreelancerApiProject.Infrustructure.Base  
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext Context { get; }
        private IDbContextTransaction? Transaction { get; set; }

        public IFreelancerRepository FreelancerRepository { get; }
        public IFreelancerSkillsRepository FreelancerSkillsRepository { get; }
        //public IFreelancerNotificationRepository freelancerNotificationRepository { get; private set; }
        public IClientRepository ClientRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IProjectSkillsRepository ProjectSkillsRepository { get; }
        public IProposalRepository ProposalRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public IRateRepository RateRepository { get; }
        public IJobRepository JobRepository { get; }
        public IJobSkillsRepository JobSkillsRepository { get; }
        public IApplicationUserRepository ApplicationUserRepository { get; } 


        public UnitOfWork
        (ApplicationDbContext context, IFreelancerRepository freelancerRepository,
        IFreelancerSkillsRepository freelancerSkillsRepository,
        IClientRepository clientRepository, INotificationRepository notificationRepository, ICategoryRepository categoryRepository,
        IProjectRepository projectRepository,
         IJobRepository jobRepository,
        IProjectSkillsRepository projectSkillsRepository, IProposalRepository proposalRepository, IJobSkillsRepository jobSkillsRepository,
 ISkillRepository skillRepository, IRateRepository rateRepository, IApplicationUserRepository applicationUserRepository)
        {
            Context = context;
            FreelancerRepository = freelancerRepository;
            FreelancerSkillsRepository = freelancerSkillsRepository;
            //this.freelancerNotificationRepository = freelancerNotificationRepository;
            ClientRepository = clientRepository;
            NotificationRepository = notificationRepository;
            CategoryRepository = categoryRepository;
            ProjectRepository = projectRepository;
            JobRepository = jobRepository;
            ProjectSkillsRepository = projectSkillsRepository;
            ProposalRepository = proposalRepository;
            JobSkillsRepository = jobSkillsRepository;
            SkillRepository = skillRepository;
            RateRepository = rateRepository;
            ApplicationUserRepository = applicationUserRepository;
        }
        // public TRepository GetRepository<TRepository>() where TRepository : class
        // {
        //     return (TRepository)Activator.CreateInstance(typeof(TRepository), Context);
        // }
        // returns num of affected entities in db
        public int Save()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        // as destructor >> called automatic when this request connection ends "if registered using addscoped"
        // >> release unmanaged resources like connection with db "like garbage collector but for unmanaged resources"
        public void Dispose()
        {
            Context.Dispose();
        }

        public void BeginTransaction()
        {
            if (Transaction == null)
            {
                Transaction = Context.Database.BeginTransaction();
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await Context.Database.BeginTransactionAsync();
        }
        public void Commit()
        {
            try
            {
                Save();
                Transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw; // Re-throw exception to propagate it
            }
        }

        public void Rollback()
        {
            Transaction?.Rollback();
            Transaction = null;
        }


    }
}