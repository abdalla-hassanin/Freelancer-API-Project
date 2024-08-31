using FreelancerApiProject.Infrustructure.Base;
using FreelancerApiProject.Infrustructure.IRepositories;
using FreelancerApiProject.Infrustructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FreelancerApiProject.Infrustructure;

public static class ModuleInfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();

        services.AddScoped<IJobRepository, JobRepository>();
        services.AddScoped<IJobSkillsRepository, JobSkillsRepository>();

        services.AddScoped<IFreelancerRepository, FreelancerRepository>();
        services.AddScoped<IFreelancerSkillsRepository, FreelancerSkillsRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectSkillsRepository, ProjectSkillsRepository>();

        services.AddScoped<IProposalRepository, ProposalRepository>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<ISkillRepository, SkillRepository>();

        services.AddScoped<IRateRepository, RateRepository>();
        services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();


        return services;
    }
}