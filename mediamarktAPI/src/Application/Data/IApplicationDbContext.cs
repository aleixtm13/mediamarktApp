using Domain.Planet;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Planet> Planets { get; set; }

    DbSet<Product> Products {get; set;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}