using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configuration
{
    public class ProductFamilyConfiguration : IEntityTypeConfiguration<ProductFamily>
    {
        public void Configure(EntityTypeBuilder<ProductFamily> builder)
        {
            builder.HasKey(productFamily => productFamily.Id);
            builder.Property(productFamily => productFamily.Id)
                .HasConversion(productFamily => productFamily.Value,
                value => new ProductFamilyId(value));
            builder.HasMany(productFamily => productFamily.Products);
        }
    }
}
