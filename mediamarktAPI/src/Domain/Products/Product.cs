using Domain.Primitives;

namespace Domain.Products;

public sealed class Product : AggregateRoot 
{

    public Product(ProductId productId, string name, string description, ProductFamilyId productFamilyId, ProductFamily productFamily)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        ProductFamilyId = productFamilyId;
        ProductFamily = productFamily;
    }

    public ProductId ProductId {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public string Description {get; private set;} = string.Empty;

    public ProductFamilyId ProductFamilyId {get; private set;}
    public ProductFamily ProductFamily { get; private set;}
}