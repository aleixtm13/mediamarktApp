using Domain.Products;
using Domain.Primitives;
using Domain.DomainErrors;
using Application.Products.Create;

namespace Application.Planets.UnitTests.Create;

public class CreateProductCommandHandlerUnitTests
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly Mock<IProductFamilyRepository> _mockProductFamilyRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly CreateProductCommandHandler _handler;
    public CreateProductCommandHandlerUnitTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockProductFamilyRepository = new Mock<IProductFamilyRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateProductCommandHandler(_mockProductRepository.Object, _mockProductFamilyRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async void HandleCreateProductCommandHandler_WhenProductFamilyDoesNotExists()
    {
        // Arrange

        CreateProductCommand command = new("Product", "ProductDescription", 10, Guid.NewGuid());
        // Act
        var result = await _handler.Handle(command, default);
        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
        result.FirstError.Code.Should().Be(Errors.ProductFamily.ProductFamilyDoesNotExists.Code);
        result.FirstError.Description.Should().Be(Errors.ProductFamily.ProductFamilyDoesNotExists.Description);
    }

    [Fact]
    public async void HandleCreateProductCommandHandler_WhenProductPriceIsNegative()
    {
        // Arrange
        Guid tvProductFamilyId = new("3FA85F64-5717-4562-B3FC-2C963F66AFA6");
        var tvProductFamily = new ProductFamily(new ProductFamilyId(tvProductFamilyId), "TV");
        _mockProductFamilyRepository
            .Setup(repository => repository.GetByIdAsync(tvProductFamily.Id))
            .ReturnsAsync(tvProductFamily);
        var command = new CreateProductCommand("Product", "ProductDescription", -1, tvProductFamilyId);
        // Act
        var result = await _handler.Handle(command, default);
        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
        result.FirstError.Code.Should().Be(Errors.Product.ProductPriceIsNegative.Code);
        result.FirstError.Description.Should().Be(Errors.Product.ProductPriceIsNegative.Description);
    }
}