using Domain.DomainErrors;
using Domain.Primitives;
using Domain.Products;
using ErrorOr;
using MediatR;

namespace Application.Products.Create;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Unit>>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductFamilyRepository _productFamilyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IProductFamilyRepository productFamilyRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _productFamilyRepository = productFamilyRepository ?? throw new ArgumentNullException(nameof(productFamilyRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var productFamily = await _productFamilyRepository.GetByIdAsync(new ProductFamilyId(request.ProductFamily));
        if (productFamily == null)
        {
            return Errors.ProductFamily.ProductFamilyDoesNotExists;
        }

        var product = Product.Create(new ProductId(Guid.NewGuid()),
            request.Name,
            request.Description,
            request.Price,
            new ProductFamilyId(request.ProductFamily));

        if(product == null)
        {
            return Errors.Product.ProductPriceIsNegative;
        }
        
        await _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}