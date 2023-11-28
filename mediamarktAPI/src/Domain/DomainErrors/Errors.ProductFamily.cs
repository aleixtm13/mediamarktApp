using ErrorOr;

namespace Domain.DomainErrors
{
    public static partial class Errors
    {
        public static class ProductFamily
        {
            public static Error ProductFamilyDoesNotExists => Error.Validation("Product Family", "Product Family does not exists");
        }
    }
}
