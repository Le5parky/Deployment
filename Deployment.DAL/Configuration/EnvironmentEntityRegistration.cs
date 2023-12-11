using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Environment = Deployment.DAL.Entities.Environment;

namespace Deployment.DAL.Configuration;


public class EnvironmentEntityRegistration:EntityTypeConfigurationDependency<Environment>
{
    public override void Configure(EntityTypeBuilder<Environment> builder)
    {
        builder.HasKey(x => x.EnvironmentId);
        builder.HasOne(x=>x.DeployAction);
        builder.HasOne(x=>x.EnvironmentHost);
    }
}