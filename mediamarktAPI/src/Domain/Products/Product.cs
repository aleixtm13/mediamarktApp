using Domain.Primitives;

namespace Domain.Products;

public sealed class Product : AggregateRoot 
{

    public Product(ProductId id, string name, string description, double price, ProductFamilyId productFamilyId)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        ProductFamilyId = productFamilyId;
    }
 
    public ProductId Id {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public string Description {get; private set;} = string.Empty;
    public double Price {get; private set;}
    public ProductFamilyId ProductFamilyId {get; private set;}
    public ProductFamily ProductFamily { get; private set;}

    public static Product Create(ProductId id, string name, string description, double price, ProductFamilyId productFamilyId)
    {
        if (price < 0)
        {
            return null;
        }
        return new Product(id, name, description, price, productFamilyId);
    }
}