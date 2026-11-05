using Exile_Pinboard.Domain.Entities;


namespace Exile_Pinboard.Application.WidgetDefinitions.Queries.GetWidgetDefinitions;

public class WidgetDefinitionDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public bool IsEnabled { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<WidgetDefinition, WidgetDefinitionDto>();
        }
    }
}
