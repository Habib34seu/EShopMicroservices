using BuildingBlocks.Pagination;
using Ordering.Application.Orders.Queries.GetOrders;


namespace Ordering.API.EndPoints;


/*
 * Accepts pagination parameters.
 * Constructs a GetOrdersQuery with thes parameters.
 * Retrieves the data and returns it in a paginated formet.
 */

//public record GetOrdersRequest(PaginationRequest PaginationRequest);

public record GetOrdersResponse(PaginatedResult<OrderDto> OrderDtos);
public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersQuery(request));
            var response = result.Adapt<GetOrdersResponse>();
            return Results.Ok(response);
        })
        .WithName("GetOrders")
        .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders")
        .WithDescription("Get Orders");
    }
}
