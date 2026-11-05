using Exile_Pinboard.Application.PinboardWidgets.Commands.CreatePinboardWidget;
using Exile_Pinboard.Application.PinboardWidgets.Queries;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Exile_Pinboard.Web.Endpoints;

public class PinboardWidgets : IEndpointGroup
{
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        //groupBuilder.RequireAuthorization();

        groupBuilder.MapGet(GetPinboardWidgets);
        groupBuilder.MapPost(CreatePinboardWidget);
    }

    [EndpointSummary("Get all pinboard widgets instanciated")]
    public static async Task<Ok<List<PinboardWidgetDto>>> GetPinboardWidgets(ISender sender, CancellationToken cancellationToken)
    {
        var widgets = await sender.Send(new GetPinboardWidgetsQuery(), cancellationToken);
        return TypedResults.Ok(widgets);
    }

    [EndpointSummary("Create a new pinboard widget")]
    public static async Task<Created<int>> CreatePinboardWidget(ISender sender, CreatePinboardWidgetCommand command, CancellationToken cancellationToken)
    {
        var id = await sender.Send(command, cancellationToken);
        return TypedResults.Created((string?)null, id);
    }
}
