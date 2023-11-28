namespace Domain.Products;

public interface IProductRepository
{
    // Task<List<Product>> GetAll();
    // Task<Product?> GetByIdAsync(ProductId id);
    Task Add(Product product);
}