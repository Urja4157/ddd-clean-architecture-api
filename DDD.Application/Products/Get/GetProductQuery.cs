using DDD.Domain.Products;
using MediatR;

namespace DDD.Application.Products.Get
{
    public record GetProductQuery(ProductId ProductId) : IRequest<ProductResposne>;

    public record ProductResposne(
        Guid Id,
        string Name,
        string Sku,
        string Currency,
        decimal Amount);
}
