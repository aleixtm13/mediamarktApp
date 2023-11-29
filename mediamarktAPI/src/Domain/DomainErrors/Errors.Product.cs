using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainErrors
{
    public static partial class Errors
    {
        public static class Product
        {
            public static Error ProductPriceIsNegative => Error.Validation("Product", "Product price value is negative");
        }
    }
}
