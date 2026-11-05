using Exile_Pinboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exile_Pinboard.Infrastructure.Data.Configurations;

public class WidgetDefinitionConfiguration : IEntityTypeConfiguration<WidgetDefinition>
{
    public void Configure(EntityTypeBuilder<WidgetDefinition> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Code)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(t => t.Code)
            .IsUnique();

        builder.Property(t => t.Description)
            .HasMaxLength(500);
    }

}
