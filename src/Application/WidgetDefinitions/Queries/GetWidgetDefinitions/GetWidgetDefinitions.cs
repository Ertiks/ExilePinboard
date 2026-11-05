using Exile_Pinboard.Application.Common.Interfaces;

namespace Exile_Pinboard.Application.WidgetDefinitions.Queries.GetWidgetDefinitions;

//[Authorize]
public record GetWidgetDefinitionsQuery : IRequest<List<WidgetDefinitionDto>>;

public class GetWidgetDefinitionsQueryHandler : IRequestHandler<GetWidgetDefinitionsQuery, List<WidgetDefinitionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetWidgetDefinitionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WidgetDefinitionDto>> Handle(GetWidgetDefinitionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.WidgetDefinitions
            .OrderBy(t => t.Id)
            .ProjectTo<WidgetDefinitionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return entities;
    }

}
