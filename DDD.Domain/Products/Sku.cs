using System;
using System.Collections.Generic;
using System.Text;
namespace DDD.Domain.Products
{
    //Stock Keeping Unit
    public record Sku
    {
        private const int DefaultLength = 8;
        private Sku(string value) => Value = value;
        public string Value { get; init; }
        public static Sku? Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            if (value.Length != DefaultLength)
                return null;
            return new Sku(value);
        }

    }
}
