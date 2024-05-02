namespace Catalog.API.Products.GetProductById;

public record GetProductByIdReseponse(Product Product);
public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            var response = result.Adapt<GetProductByIdReseponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdReseponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product ById")
        .WithDescription("Get Product ById");
    }
}
