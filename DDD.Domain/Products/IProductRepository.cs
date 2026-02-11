namespace DDD.Domain.Products
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Remove(Product product);
        Task<Product?> GetByIdAsync(ProductId id);
        void Update(Product product);

    }
}
