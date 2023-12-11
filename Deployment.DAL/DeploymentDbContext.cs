using Deployment.Common.Configuration;
using Deployment.DAL.Configuration;
using Deployment.DAL.Entities;
using Deployment.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

namespace Deployment.DAL;

public class DeploymentDbContext:DbContext
{
    private readonly IModelConfiguration _modelConfiguration;

    public DeploymentDbContext(DbContextOptions<DeploymentDbContext> options,
        IModelConfiguration modelConfiguration)
        : base(options)
    {
        _modelConfiguration = modelConfiguration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeploymentDbContext).Assembly);
        _modelConfiguration.ConfigureModel(modelBuilder);
    }
}