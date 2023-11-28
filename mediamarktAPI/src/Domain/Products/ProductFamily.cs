namespace Domain.Products;

public class ProductFamily 
{
    public ProductFamily(ProductFamilyId id, string name)
    {
        Id = id;
        Name = name;
    }

    public ProductFamilyId Id {get; private set;}
    public string Name {get; private set;}
    public ICollection<Product> Products {get; private set;}
}