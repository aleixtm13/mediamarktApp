using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Product product) => await _context.Products.AddAsync(product);

    public async Task<List<Product>> GetProducts(string searchText) => await _context.Products
        .Where(product => product.Name.Contains(searchText))
        .Include(product => product.ProductFamily)
        .ToListAsync();
}