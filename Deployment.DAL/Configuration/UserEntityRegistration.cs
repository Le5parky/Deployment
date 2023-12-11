using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class UserEntityRegistration: EntityTypeConfigurationDependency<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x=>x.UserId);
    }
}