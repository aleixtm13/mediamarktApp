namespace Domain.Products
{
    public interface IProductFamilyRepository
    {
        Task<ProductFamily?> GetByIdAsync(ProductFamilyId productFamilyId);
    }
}
