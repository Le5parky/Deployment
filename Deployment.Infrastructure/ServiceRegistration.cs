using Deployment.DAL;
using Deployment.Infrastructure.Automapper;
using Deployment.Infrastructure.Configuration;
using Deployment.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Deployment.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            string connectionString, ILoggerFactory logger)
        {

            services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();
            services.AddDbContext<DeploymentDbContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("Deployment.WebApp");
                    //typeof(ServiceRegistration).Assembly.FullName);
                }).UseLoggerFactory(logger);
            });

            services.AddAutoMapper(typeof(ApplicationMapping));
            return services;
        }
    }
}