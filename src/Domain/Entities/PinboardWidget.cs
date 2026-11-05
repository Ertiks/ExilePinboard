using System.Drawing;

namespace Exile_Pinboard.Domain.Entities;

internal class PinboardWidget : BaseEntity
{
    public required int WidgetDefinitionId { get; set; }
    public string? Name { get; set; }
    
    


    //POSITIONS / SCALE :
    public int posX { get; set; }
    public int posY { get; set; }
    public int sizeX { get; set; }
    public int sizeY { get; set; }



}
