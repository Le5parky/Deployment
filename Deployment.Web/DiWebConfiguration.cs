using Deployment.Common.Configuration;
using Deployment.DAL;
using Deployment.DependencyInjection.Extensions;
using Deployment.DomainModel;
using Deployment.Infrastructure;
using Deployment.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Deployment.Web;

public static class DiWebConfiguration
{
    public static void DiConfiguration(this WebApplicationBuilder builder)
    {
        var contextLoggerFactory = LoggerFactory
                                    .Create(b => b.AddConsole()
                                        .SetMinimumLevel(LogLevel.Information));

        string connectionString = builder.Configuration
            .GetConnectionString("ConnectionString");


        builder.Services.AddInfrastructure(connectionString!, contextLoggerFactory);
        builder.Services.AddConfiguration();
        
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        builder.Services.DalConfiguration();
        builder.Services.DomainModelConfiguration();

        builder.Services.AddTransient<ApplicationService>();
        builder.Services.AddTransient<CheckboxService>();

        builder.Services.AddSingleton<Configuration>()
            .ReUseSingleton<Configuration, IGitConfiguration>()
            .ReUseSingleton<Configuration, IConnectionStringConfiguration>();
    }

    public static void AddConfiguration(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        services.AddSingleton(configuration);
    }
}
