using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class DeployActionEntityRegistration:EntityTypeConfigurationDependency<DeployAction>
{
    public override void Configure(EntityTypeBuilder<DeployAction> builder)
    {
        builder.HasKey(x=>x.DeployActionId);
    }
}