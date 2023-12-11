using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class TargetVersionEntityRegistration:EntityTypeConfigurationDependency<TargetVersion>
{
    public override void Configure(EntityTypeBuilder<TargetVersion> builder)
    {
        builder.HasKey(x => x.TargetVersionId);
    }
}