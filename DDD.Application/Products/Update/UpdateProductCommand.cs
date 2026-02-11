using DDD.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Products.Update
{
    public record UpdateProductCommand(
        ProductId ProductId,
        string Name,
        string Sku,
        string Currency,
        decimal Amount
        ) : IRequest;
    public record UpdateProductRequest(
        string Name,
        string Sku,
        string Currency,
        decimal Amount
        );
}
