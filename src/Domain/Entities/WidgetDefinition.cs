namespace Exile_Pinboard.Domain.Entities;

public class WidgetDefinition : BaseEntity
{
    public string Name { get; set; } = "";

    public string Code { get; set; } = "";

    public string? Description { get; set; }

    public bool IsEnabled { get; set; } = true;
}
