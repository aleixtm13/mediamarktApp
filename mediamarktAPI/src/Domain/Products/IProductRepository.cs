namespace Domain.Products;

public interface IProductRepository
{
    // Task<List<Product>> GetAll();
    Task Add(Product product);
}