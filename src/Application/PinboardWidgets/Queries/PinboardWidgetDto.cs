using Exile_Pinboard.Domain.Entities;

namespace Exile_Pinboard.Application.PinboardWidgets.Queries;

public class PinboardWidgetDto
{
    public int Id { get; set; }
    public int? WidgetDefinitionId { get; set; }
    public int PinboardId { get; set; }
    public string? Name { get; set; }

    public double X { get; set; }
    public double Y { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public int ZIndex { get; set; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PinboardWidget, PinboardWidgetDto>();
        }
    }
}
