using Deployment.DAL.Configuration;
using Deployment.DAL.Repositories;
using Deployment.DAL.Repositories.Interface;
using Deployment.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deployment.DAL;

public static class DalDiConfiguration
{
    public static void DalConfiguration(this IServiceCollection service)
    {
        //Register RegisterAssemblies
        service.RegisterAssemblies<EntityTypeConfigurationDependency, DeploymentDbContext>();
        
        //Register as Scoped
        service.AddTransient<DbContext>();
        
        //Register as Transient
        service.AddTransient(typeof(IRepository<>), typeof(AbstractRepository<>));
        service.AddTransient<IApplicationRepository, ApplicationRepository>();

    }
}