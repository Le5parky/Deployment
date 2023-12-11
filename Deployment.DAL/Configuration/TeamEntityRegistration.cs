using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class TeamEntityRegistration:EntityTypeConfigurationDependency<Team>
{
    public override void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(x => x.TeamId);
        builder.HasMany(x => x.Users);
    }
}