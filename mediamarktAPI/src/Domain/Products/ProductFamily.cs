namespace Domain.Products;

public class ProductFamily 
{
    public ProductFamily(ProductFamilyId productFamilyId, string name, ICollection<Product> products)
    {
        ProductFamilyId = productFamilyId;
        Name = name;
        Products = products;
    }

    public ProductFamilyId ProductFamilyId {get; private set;}
    public string Name {get; private set;}
    public ICollection<Product> Products {get; private set;}
}