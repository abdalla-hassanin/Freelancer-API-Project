using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FreelancerApiProject.Core;

public static class CoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        //Configuration Of Mediator
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        //Configuration Of Automapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}