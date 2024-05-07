﻿namespace Basket.API.Basket.GetBasket;


//public record GetBasketRequest();
public record GetBasketResponse(ShoppingCart Cart);
public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}",async(string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            var resonse = result.Adapt<GetBasketResponse>();

            return Results.Ok(resonse);
        })
        .WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Basket")
        .WithDescription("Get Basket"); 
    }
}
