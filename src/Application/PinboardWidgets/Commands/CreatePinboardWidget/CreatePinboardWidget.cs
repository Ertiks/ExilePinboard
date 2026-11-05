using Exile_Pinboard.Application.Common.Interfaces;
using Exile_Pinboard.Domain.Entities;

namespace Exile_Pinboard.Application.PinboardWidgets.Commands.CreatePinboardWidget;

public class CreatePinboardWidgetCommand : IRequest<int>
{
    //BASIC DATA :
    public required int WidgetDefinitionId { get; set; }
    public required int PinboardId { get; set; }
    public string? Name { get; set; }

    //POSITION / SCALING : 
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;
    public double Width { get; set; } = 100;
    public double Height { get; set; } = 100;
    public int ZIndex { get; set; }
}

public class CreatePinboardWidgetCommandHandler : IRequestHandler<CreatePinboardWidgetCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePinboardWidgetCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePinboardWidgetCommand command, CancellationToken cancellationToken)
    {
        var entity = new PinboardWidget
        {
            WidgetDefinitionId = command.WidgetDefinitionId,
            PinboardId = command.PinboardId,
            Name = command.Name,

            X = command.X,
            Y = command.Y,
            Width = command.Width,
            Height = command.Height,
            ZIndex = command.ZIndex
        };

        _context.PinboardWidgets.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
