using Deployment.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deployment.DAL.Configuration;

public class ApplicationEntityRegistration: EntityTypeConfigurationDependency<Application>
{
    public override void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.HasKey(x => x.ApplicationId);
        builder.Property(x => x.Code)
                .HasMaxLength(8)
                .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(x => x.DropZone)
            .HasMaxLength(1024)
            .IsRequired();

        builder.Property(x => x.Tag)
            .HasMaxLength(32)
            .IsRequired();
    }
}