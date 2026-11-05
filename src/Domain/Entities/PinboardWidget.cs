namespace Exile_Pinboard.Domain.Entities;

public class PinboardWidget : BaseEntity
{
    //BASIC DATA :
    public required int? WidgetDefinitionId { get; set; }
    public required int PinboardId { get; set; }
    public string? Name { get; set; }


    //POSITIONS / SCALE :
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;
    public double Width { get; set; } = 100;
    public double Height { get; set; } = 100;
    public int ZIndex { get; set; } = 0;
}
