
using Exile_Pinboard.Application.WidgetDefinitions.Commands.CreateWidgetDefinition;
using Exile_Pinboard.Application.WidgetDefinitions.Queries.GetWidgetDefinitions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Exile_Pinboard.Web.Endpoints;

public class WidgetDefinitions : IEndpointGroup
{
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        //groupBuilder.RequireAuthorization();

        groupBuilder.MapGet(GetWidgetDefinitions);
        groupBuilder.MapPost(CreateWidgetDefinition);
    }

    [EndpointSummary("Get all widget definitions")]
    public static async Task<Ok<List<WidgetDefinitionDto>>> GetWidgetDefinitions(ISender sender, CancellationToken cancellationToken)
    {
        var definitions = await sender.Send(new GetWidgetDefinitionsQuery(), cancellationToken);
        return TypedResults.Ok(definitions);
    }

    [EndpointSummary("Create a new widget definition")]
    public static async Task<Created<int>> CreateWidgetDefinition(ISender sender, CreateWidgetDefinitionCommand command, CancellationToken cancellationToken)
    {

        var id = await sender.Send(command, cancellationToken);
        return TypedResults.Created($"/{nameof(WidgetDefinitions)}/{id}", id);
    }
}
