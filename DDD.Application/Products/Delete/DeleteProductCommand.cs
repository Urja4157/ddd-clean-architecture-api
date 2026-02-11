using DDD.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Products.Delete
{
    public record DeleteProductCommand(ProductId ProductId) : IRequest;
}
