using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Product> Products {get; set;}
    DbSet<ProductFamily> ProductFamily { get; set;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}