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

            AddInitialData(builder);
        }

        private static void AddInitialData(EntityTypeBuilder<ProductFamily> builder)
        {
            builder.HasData(new ProductFamily(new ProductFamilyId(new Guid("1FA85F64-5717-4562-B3FC-2C963F66AFA6")), "Coffe machines"));
            builder.HasData(new ProductFamily(new ProductFamilyId(new Guid("2FA85F64-5717-4562-B3FC-2C963F66AFA6")), "Smartphones"));
            builder.HasData(new ProductFamily(new ProductFamilyId(new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6")), "TV"));
        }
    }
}
