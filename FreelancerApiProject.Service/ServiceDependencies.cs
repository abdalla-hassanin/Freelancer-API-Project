using System.Reflection;
using FreelancerApiProject.Service.IServices;
using FreelancerApiProject.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FreelancerApiProject.Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();

        // Registering the Services inside the application container.
        services.AddScoped<IProposalService, ProposalService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IFreelancerService, FreelancerService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IRateService, RateService>();
        services.AddScoped<ISkillService, SkillService>();
        services.AddScoped<INotificationService, NotificationService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}