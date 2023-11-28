using Domain.Primitives;
using Domain.Products;
using ErrorOr;
using MediatR;

namespace Application.Products.Create;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<Unit>>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //TODO: add validation for existing product family

        var product = new Product(
            new ProductId(Guid.NewGuid()),
            request.Name,
            request.Descritpion,
            request.Price,
            new ProductFamilyId(request.ProductFamilyId));
        
        await _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}