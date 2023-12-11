using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class HostEntityRegistration:EntityTypeConfigurationDependency<Host>
{
    public override void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.HasKey(x=>x.HostId);
    }
}