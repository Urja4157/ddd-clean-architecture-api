using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Application.Products.Create
{
    public record CreateProductCommand(
        string Name, 
        string Sku, 
        string Currency, 
        decimal Amount) : IRequest;
    
}
