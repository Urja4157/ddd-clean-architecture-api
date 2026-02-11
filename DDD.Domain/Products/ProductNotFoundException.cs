using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Products
{
    public sealed class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(ProductId productId)
            : base($"Product with ID {productId.Value} not found.")
        {
        }
    }
}
