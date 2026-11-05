using Exile_Pinboard.Application.Common.Interfaces;
using Exile_Pinboard.Domain.Entities;

namespace Exile_Pinboard.Application.WidgetDefinitions.Commands.CreateWidgetDefinition;

public class CreateWidgetDefinitionCommand : IRequest<int>
{
    public required string Name { get; init; }
    public required string Code { get; init; }
    public string? Description { get; init; }
}

public class CreateWidgetDefinitionCommandHandler : IRequestHandler<CreateWidgetDefinitionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWidgetDefinitionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWidgetDefinitionCommand request, CancellationToken cancellationToken)
    {
        var entity = new WidgetDefinition
        {
            Name = request.Name,
            Code = request.Code,
            Description = request.Description
        };

        _context.WidgetDefinitions.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

}
