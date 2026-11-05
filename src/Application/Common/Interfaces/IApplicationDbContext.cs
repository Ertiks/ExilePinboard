using Exile_Pinboard.Domain.Entities;

namespace Exile_Pinboard.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    DbSet<WidgetDefinition> WidgetDefinitions { get; }
    DbSet<PinboardWidget> PinboardWidgets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

