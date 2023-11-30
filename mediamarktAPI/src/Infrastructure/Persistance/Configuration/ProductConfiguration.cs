

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

        AddInitialData(builder);
    }

    private static void AddInitialData(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(new Product(new ProductId(Guid.NewGuid()), "LG OLED65C35LA, OLED 4K", "LG TV Description", 1599, new ProductFamilyId(new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6"))));
        builder.HasData(new Product(new ProductId(Guid.NewGuid()), "Delonghi Dedica EC685.BK", "Delonghi Dedica Description", 199.99, new ProductFamilyId(new Guid("1FA85F64-5717-4562-B3FC-2C963F66AFA6"))));
        builder.HasData(new Product(new ProductId(Guid.NewGuid()), "iPhone 15 Pro Max", "iPhone 15 Pro Max Description", 1449.99, new ProductFamilyId(new Guid("2FA85F64-5717-4562-B3FC-2C963F66AFA6"))));
    }
}