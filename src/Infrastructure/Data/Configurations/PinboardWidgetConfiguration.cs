using Exile_Pinboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exile_Pinboard.Infrastructure.Data.Configurations;

public class PinboardWidgetConfiguration : IEntityTypeConfiguration<PinboardWidget>
{
    public void Configure(EntityTypeBuilder<PinboardWidget> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(50);

        builder.HasOne<WidgetDefinition>()
            .WithMany()
            .HasForeignKey(w => w.WidgetDefinitionId)
            .OnDelete(DeleteBehavior.SetNull);
           
        // #Todo : ajouter la relation avec un pinboard
        //builder.HasOne<>.WithMany<>.HasForeignKey();
        //OnDelete en cascade 
    }
}
