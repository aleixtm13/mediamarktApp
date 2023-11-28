using Application.Products.Common;
using Domain.Products;
using ErrorOr;
using MediatR;

namespace Application.Products.Get
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ErrorOr<IReadOnlyList<ProductResponse>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFamilyRepository _productFamilyRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<ErrorOr<IReadOnlyList<ProductResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            string searchText = !string.IsNullOrEmpty(request.SearchText) ? request.SearchText : string.Empty;
            IReadOnlyList<Product> products = await _productRepository.GetProducts(searchText);

            return products.Select(product => new ProductResponse(
                product.Id.Value,
                product.Name,
                product.Description,
                product.Price,
                product.ProductFamily.Name
                )).ToList();
        }
    }
}
