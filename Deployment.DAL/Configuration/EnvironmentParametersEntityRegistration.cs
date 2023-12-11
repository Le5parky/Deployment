using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class EnvironmentParametersEntityRegistration:EntityTypeConfigurationDependency<EnvironmentParameters>
{
    public override void Configure(EntityTypeBuilder<EnvironmentParameters> builder)
    {
        builder.HasKey(x => x.EnvironmentParametersId);
    }
}