using Domain.Primitives;

namespace Domain.Products;

public sealed class Product : AggregateRoot 
{

    public Product(ProductId productId, string name, string description, double price, ProductFamilyId productFamilyId, ProductFamily productFamily)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Price = price;
        ProductFamilyId = productFamilyId;
        ProductFamily = productFamily;
    }

    public ProductId ProductId {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public string Description {get; private set;} = string.Empty;
    public double Price {get; private set;}
    public ProductFamilyId ProductFamilyId {get; private set;}
    public ProductFamily ProductFamily { get; private set;}
}