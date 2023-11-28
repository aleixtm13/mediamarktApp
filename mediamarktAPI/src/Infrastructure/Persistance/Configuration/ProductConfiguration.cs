

using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
       
       builder.HasKey(product => product.Id);
       builder.Property(product => product.Id)
       .HasConversion(productId => productId.Value,
                       value => new ProductId(value));

        builder.HasOne(product => product.ProductFamily)
        .WithMany(productFamily => productFamily.Products)
        .HasForeignKey(product => product.ProductFamilyId);
    }
}