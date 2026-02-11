using DDD.Application.Interfaces;
using DDD.Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DDD.Application.Products.Get
{
    internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResposne>
    {
        //private readonly IProductRepository _repository;
        private readonly IApplicationDbContext _context;

        public GetProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        //public GetProductQueryHandler(IProductRepository repository)
        //{
        //    _repository = repository;
        //}

        public async Task<ProductResposne> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context
                .Products
                .Where(p => p.Id == request.ProductId)
                .Select(p => new ProductResposne(
                    p.Id.Value,
                    p.Name,
                    p.Sku.Value,
                    p.Price.Currency,
                    p.Price.Amount
                )).FirstOrDefaultAsync(cancellationToken);

            if (product is null)
                throw new ProductNotFoundException(request.ProductId);
            return product;

            //var productId = new ProductId(request.ProductId);

            //var product = await _repository.GetByIdAsync(productId);

            //if (product is null)
            //    return null;

            //return new ProductResposne(
            //    product.Id.Value,
            //    product.Name,
            //    product.Sku.Value,
            //    product.Price.Currency,
            //    product.Price.Amount
            //);
        }
    }
}
