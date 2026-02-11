using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Domain.Products
{
    public record Money(string Currency, decimal Amount);
}
