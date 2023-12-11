using Deployment.DomainModel.Managers;
using Deployment.DomainModel.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Deployment.DomainModel;

public static class DiDomainModelConfiguration
{
    public static void DomainModelConfiguration(this IServiceCollection service)
    {
        service.AddScoped<IApplicationManager, ApplicationManager>();
    }
}