using Domain.Products;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductFamilyRepository : IProductFamilyRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductFamilyRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ProductFamily?> GetByIdAsync(ProductFamilyId productFamilyId) => await _context.ProductFamily.SingleOrDefaultAsync(productFamily => productFamily.Id.Equals(productFamilyId));
    }
}
