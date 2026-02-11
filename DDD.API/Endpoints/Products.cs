using Carter;
using DDD.Application.Products.Create;
using DDD.Application.Products.Delete;
using DDD.Application.Products.Get;
using DDD.Application.Products.Update;
using DDD.Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Endpoints
{
    public class Products : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("products", async (CreateProductCommand command, ISender sender) =>
            {
                await sender.Send(command);
                return Results.Ok();
            });

            app.MapDelete("products/{id:guid}", async (Guid id, ISender sender) =>
            {
                try
                {
                    await sender.Send(new DeleteProductCommand(new ProductId(id)));
                    return Results.NoContent();
                }
                catch (ProductNotFoundException e)
                {
                    return Results.NotFound(e);
                }
            });

            app.MapPut("products/{id:guid}", async (Guid id, [FromBody] UpdateProductRequest
                request, ISender sender) =>
            {
                var command = new UpdateProductCommand(new ProductId(id), request.Name, request.Sku, request.Currency, request.Amount);
                await sender.Send(command);
                return Results.NoContent();
            });

            app.MapGet("product/{id:guid}", async (Guid id, ISender sender) =>
            {
                try
                {
                    return Results.Ok(await sender.Send(new GetProductQuery(new ProductId(id))));

                }
                catch (ProductNotFoundException e)
                {
                    return Results.NotFound(e);
                }
            });
        }


    }
}
