using Deployment.SharedKernel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace Deployment.Infrastructure.Configuration;

internal class SqlModelConfiguration : IModelConfiguration
{
    public void ConfigureModel(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
    }
}