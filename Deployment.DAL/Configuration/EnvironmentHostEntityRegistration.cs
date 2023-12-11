using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class EnvironmentHostEntityRegistration:EntityTypeConfigurationDependency<EnvironmentHost>
{
    public override void Configure(EntityTypeBuilder<EnvironmentHost> builder)
    {
        builder.HasKey(x => x.EnvironmentHostId);
    }
}