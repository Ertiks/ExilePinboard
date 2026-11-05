using Exile_Pinboard.Application.Common.Interfaces;

namespace Exile_Pinboard.Application.PinboardWidgets.Queries;

public record GetPinboardWidgetsQuery : IRequest<List<PinboardWidgetDto>>;

public class GetPinboardWidgetsQueryHandler : IRequestHandler<GetPinboardWidgetsQuery, List<PinboardWidgetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPinboardWidgetsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<PinboardWidgetDto>> Handle(GetPinboardWidgetsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _context.PinboardWidgets
            .OrderBy(w => w.Id)
            .ProjectTo<PinboardWidgetDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return entities;
    }
}
