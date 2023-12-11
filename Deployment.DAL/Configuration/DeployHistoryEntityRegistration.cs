using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class DeployHistoryEntityRegistration:EntityTypeConfigurationDependency<DeployHistory>
{
    public override void Configure(EntityTypeBuilder<DeployHistory> builder)
    {
        builder.HasKey(x => x.DeployHistoryId);
    }
}