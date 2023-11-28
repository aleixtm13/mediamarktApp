namespace Application.Products.Common
{
   public record ProductResponse(
       Guid Id,
       string Name,
       string Description,
       double Price,
       string ProductFamily
       );
}
